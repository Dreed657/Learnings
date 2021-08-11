package com.helevator.Chatty.Server;

import com.helevator.Chatty.Server.Enums.ChatCommands;
import com.helevator.Chatty.Server.Enums.ChatResponses;
import com.helevator.Chatty.Server.Exeptions.ChatException;

import java.io.*;
import java.net.InetAddress;
import java.net.ServerSocket;
import java.net.Socket;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;
import java.util.concurrent.Executors;
import java.util.concurrent.ThreadPoolExecutor;

public class ChatServer implements Runnable {
    private static final String APP_NAME = "Chatty";
    private static final String APP_VERSION = "0.0069";

    // Welcome message on connection
    public static final String APP_ABOUT = APP_NAME + " " + APP_VERSION + " Started on: " + new Date();

    private boolean running = false;
    private ServerSocket socket = null;

    // MAX_CLIENTS that can connect to the server, after that will send message and close any new connections;
    private static final int MAX_CLIENTS = 2;
    private final ThreadPoolExecutor threadPool = (ThreadPoolExecutor)Executors.newCachedThreadPool();

    // Server keeps track of all connected users data; (Usernames, rooms)
    private final List<String> chatUsers = new ArrayList<>();
    private final List<RequestHandler> chatHandles = new ArrayList<>();

    public ChatServer(int port) throws IOException {
        this.socket = new ServerSocket(port);
    }

    @Override
    public void run() {
        this.running = true;
        System.out.println("Server is listening on: " + this.socket.getLocalPort());

        while (this.running) {
            try {
                var conn = this.socket.accept();
                var handler = new RequestHandler(conn);

                if (this.threadPool.getTaskCount() < MAX_CLIENTS) {
                    this.threadPool.submit(handler);
                    this.chatHandles.add(handler);

                    System.out.println(conn);
                } else {
                    var output = new OutputStreamWriter(conn.getOutputStream());
                    output.write("Server is full!\n");
                    output.flush();

                    conn.close();
                }
            } catch (IOException e) {
                System.err.println(e.getMessage());
            }
        }
    }

    private void msg(String user, String dest, String msg) throws IOException, ChatException {
        synchronized (this.chatHandles) {
            if ('#' == dest.charAt(0))
            {
                // Send a message to all members in the specified room;
                StringBuffer outMsg = new StringBuffer();
                outMsg.append(user).append(' ');
                outMsg.append(dest).append(' ');
                outMsg.append(msg);

                for (RequestHandler chatHandle : chatHandles) {
                    RequestHandler handle = (RequestHandler) chatHandle;
                    if (handle.hasRoom(dest)) {
                        handle.send(ChatResponses.TOROOM, outMsg.toString());
                    }
                }
            }
            else
            {
                // Send message to an user;
                StringBuffer outMsg = new StringBuffer();
                outMsg.append(user).append(' ');
                outMsg.append(msg);

                for (RequestHandler chatHandle : chatHandles) {
                    RequestHandler handle = (RequestHandler) chatHandle;
                    if (handle.isUser(dest)) {
                        handle.send(ChatResponses.TOUSER, outMsg.toString());
                        return;
                    }
                }

                throw new ChatException("Specified User Not Found: " + dest);
            }
        }
    }

    // TODO: Research shutdown mechanisms;
    public synchronized void Shutdown() {
        this.running = false;
    }

    // Fake AUTH aka just add username to connected users;
    private boolean login(String username) {
        synchronized (this.chatUsers) {
            if (!this.chatUsers.contains(username)) {
                return this.chatUsers.add(username);
            } else {
                return false;
            }
        }
    }

    // Remove user from connected users and closes connection;
    private boolean logout(String username) {
        synchronized (this.chatUsers) {
            if (!this.chatUsers.contains(username)) {
                return this.chatUsers.remove(username);
            } else {
                return false;
            }
        }
    }

    public class RequestHandler implements Runnable {

        // (bytes) maximum buffer allowed client for input
        private static final int MAX_BUFFER_SIZE = 2048;

        // (5 minutes) time to wait for valid command
        private static final int MAX_TIME_WAIT = 5 * 60 * 1000;

        private Socket _sock = null;
        private InetAddress _addr = null;

        private String _username = null;

        private final List<String> _chatRooms = new ArrayList<>();

        OutputStreamWriter writer = null;

        public RequestHandler(Socket sock) {
            this._sock = sock;
            this._addr = this._sock.getInetAddress();
        }

        @Override
        public void run() {
            try {
                InputStream input = this._sock.getInputStream();
                OutputStream output = this._sock.getOutputStream();

                InputStreamReader reader = new InputStreamReader(input);
                this.writer = new OutputStreamWriter(output);

                var buffer = new ByteArrayOutputStream(MAX_BUFFER_SIZE);
                int c = -1;
                var ts = System.currentTimeMillis();

                send(ChatResponses.OK, ChatServer.APP_ABOUT);

                while (this._sock.isConnected() && (c = reader.read()) != -1) {
                    if (MAX_BUFFER_SIZE == buffer.size()) {
                        buffer.reset();
                    }

                    if ((System.currentTimeMillis() - ts) > MAX_TIME_WAIT) {
                        send(ChatResponses.TIMEOUT, "Timeout!");
                        this._sock.close();
                        return; // not needed?
                    }

                    if ((char)c != '\r') {
                        buffer.write((char)c);
                    }

                    if ((char)c == '\n') {
                        System.out.println("Client \'" + this._sock.getPort() + "\' reading: " + buffer.toString());

                        try {
                            processRequest(buffer.toString());
                            send(ChatResponses.OK, null);
                        } catch (ChatException e) {
                            send(ChatResponses.ERROR, e.getMessage());
                            e.printStackTrace();
                        }

                        buffer.reset();
                        ts = System.currentTimeMillis();
                    }
                }

            } catch (IOException io)
            {
                System.err.println("ChatServer: " + io.getMessage() + " for host " + _addr.getHostAddress());
            }
        }

        // Updates current connection response message
        protected synchronized void send(ChatResponses response, String text) throws IOException {
            if (this.writer != null) {
                this.writer.write(response.toString());
                this.writer.write(' ');

                if (text != null) {
                    this.writer.write(text);
                }

                this.writer.write("\r\n");
                this.writer.flush();
            }
        }

        public boolean isUser(String username) {
            return (this._username != null && this._username.equals(username));
        }

        public boolean hasRoom(String room) {
            synchronized (this._chatRooms) {
                return this._chatRooms.contains(room);
            }
        }

        // TODO: Implement DirectCommands mechanisms in here!
        private void processRequest(String msg) throws ChatException {
            var args = msg.trim().split(" ");

            ChatCommands command = null;
            if (args.length == 0) {
                throw new ChatException("Invalid Message for Processing");
            }

            try {
                command = ChatCommands.valueOf(args[0]);
            } catch (IllegalArgumentException e) {
                throw  new ChatException("Invalid Command (" + args[0] + ")");
            }

            var length = args.length;

            if (length == 1) {
                if (command == ChatCommands.LOGOUT) {
                    if (this._username != null) {
                        logout(this._username);
                        this._username = null;
                    }

                    try {
                        this._sock.close();
                    } catch (IOException e) {
                        System.err.println(e.getMessage());
                    }

                    return;
                }
            } else if (length == 2) {
                if (this._username != null) {
                    if (command == ChatCommands.JOIN) {
                        String room = args[1];

                        join(room);
                        return;
                    } else if (command == ChatCommands.LEAVE) {
                        String room = args[1];

                        leave(room);
                        return;
                    }
                } else {
                    if (command == ChatCommands.LOGIN) {
                        String username = args[1];
                        if (login(username)) {
                            this._username = username;
                            return;
                        } else {
                            throw new ChatException("Username not accepted");
                        }
                    } else {
                        throw new ChatException("You mush be logged to use this command");
                    }
                }
            } else {
                if (this._username != null && command == ChatCommands.MSG) {
                    StringBuffer messageText = new StringBuffer();
                    String room = args[1];

                    for (int idx = 2; idx < args.length; idx++)
                    {
                        messageText.append(args[idx]).append(' ');
                    }

                    try
                    {
                        msg(this._username, room, messageText.toString());
                        return;
                    } catch (IOException io)
                    {
                        throw new ChatException(io.getMessage());
                    }
                }
            }

            throw new ChatException("Specified Command Invalid");
        }

        private void join(String room) throws ChatException {
            if ('#' == room.charAt(0)) {
                synchronized (this._chatRooms) {
                    if (this._chatRooms.contains(room)) {
                        throw new ChatException("Already joined to " + room);
                    }

                    this._chatRooms.add(room);
                }
            } else {
                throw new ChatException("Join Name Must Begin with '#'");
            }
        }

        private void leave(String room) throws ChatException {
            synchronized (this._chatRooms) {
                if (this._chatRooms.contains(room)) {
                    this._chatRooms.remove(room);
                } else {
                    throw new ChatException("Not Joined to " + room);
                }
            }
        }
    }
}
