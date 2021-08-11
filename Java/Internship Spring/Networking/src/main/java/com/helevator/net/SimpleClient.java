package com.helevator.net;

import java.io.*;
import java.net.Socket;

public class SimpleClient {
    public static void main(String[] args) throws IOException {
        Socket s = new Socket("localhost", 5000);
        InputStream inputStream = s.getInputStream();
        OutputStream outputStream = s.getOutputStream();

        PrintWriter printWriter = new PrintWriter(outputStream);
        BufferedReader bufferedReader = new BufferedReader(new InputStreamReader(inputStream));

        printWriter.println("Hello im a client\n");
        printWriter.flush();

        String line;
        while ((line = bufferedReader.readLine()) != null) {
            System.out.println(line);
        }
    }
}