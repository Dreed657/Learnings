package com.helevator.net;

import java.io.*;
import java.net.ServerSocket;
import java.net.Socket;

public class SimpleServer {

    ServerSocket serverSocket;
    private static final int PORT = 5000;

    private Socket init() throws IOException {
        serverSocket = new ServerSocket(PORT);
        System.out.println("Server is listening on: " + PORT);
        return serverSocket.accept();
    }

    public static void main(String[] args) throws IOException {
        SimpleServer simpleServer = new SimpleServer();
        Socket clientConnection = simpleServer.init();

        System.out.println("Connected client"+ clientConnection);

        InputStream inputStream = clientConnection.getInputStream();
        OutputStream outputStream = clientConnection.getOutputStream();

        PrintWriter printWriter = new PrintWriter(outputStream);
        BufferedReader bufferedReader = new BufferedReader(new InputStreamReader(inputStream));

        String line;

        while ((line = bufferedReader.readLine()) != null) {
            System.out.println(line);
            printWriter.println("You said: " + line);
            printWriter.flush();
        }
    }
}
