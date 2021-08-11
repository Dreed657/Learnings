package com.helevator.Chatty;

import com.helevator.Chatty.Server.ChatServer;

import java.io.IOException;

public class App {
    public static void main(String[] args) throws IOException  {
        int port = 5000;

        var server = new ChatServer(port);
        var thmain = new Thread(server);

        thmain.start();
    }
}
