package com.company;

import java.io.BufferedReader;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.net.HttpURLConnection;
import java.net.URL;
import java.util.Scanner;

public class Main {

    public static void main(String[] args) {
        var scanner = new Scanner(System.in);
        var target = new Target("localhost", 5000, "healthcheck", Protocol.Http);
        System.out.println(target.toString());

        System.out.print("Request count: ");
        var count = Integer.parseInt(scanner.next());

        for (var i = 0; i < count; i++) {
            HttpURLConnection connection = null;
            try {
                var start = System.currentTimeMillis();
                var url = new URL(target.GetUrl());

                connection = (HttpURLConnection)url.openConnection();
                connection.setRequestMethod("GET");

                InputStream is = connection.getInputStream();
                BufferedReader rd = new BufferedReader(new InputStreamReader(is));
                StringBuilder response = new StringBuilder(); // or StringBuffer if Java version 5+
                String line;
                while ((line = rd.readLine()) != null) {
                    response.append(line);
                    response.append('\r');
                }
                rd.close();

                var finish = System.currentTimeMillis();
                var timeElapsed = finish - start;

                var message = String.format("Response: %s - %s ms", response.toString(), timeElapsed);
                System.out.println(message);
            } catch (Exception e) {
                e.printStackTrace();
            } finally {
                if (connection != null) {
                    connection.disconnect();
                }
            }
        }
    }
}
