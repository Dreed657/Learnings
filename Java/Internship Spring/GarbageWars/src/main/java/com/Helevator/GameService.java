package com.Helevator;

import java.io.IOException;
import java.net.URI;
import java.net.http.HttpClient;
import java.net.http.HttpRequest;
import java.net.http.HttpResponse;
import java.net.http.HttpTimeoutException;
import java.time.Duration;
import java.time.temporal.ChronoUnit;
import java.util.Arrays;
import java.util.List;
import java.util.stream.Collectors;

public class GameService {

    private HttpClient http;

    private final String NAME = "Stoyan";
    private final String SERVER = "http://localhost";
//    private final String SERVER = "http://195.24.57.107";
    private final String PORT = "8080";

    public GameService() {
        this.http = HttpClient.newHttpClient();
    }

    // GET
    // http://server:port/api/sector/[id]/objects
    public List<String> getObjectNodes(String sector) throws IOException, InterruptedException {
        HttpRequest request = HttpRequest.newBuilder(URI.create(SERVER + ":" + PORT + "/api/sector/" + sector + "/objects")).GET().build();

        HttpResponse<String> response = http.send(request, HttpResponse.BodyHandlers.ofString());

        //System.out.println(response.body());

        return Arrays.stream(response.body().split("\n")).collect(Collectors.toList());
    }

    // GET
    // http://server:port/api/sector/[id]/roots
    public List<String> getRootNodes(String sector) throws IOException, InterruptedException {
        HttpRequest request = HttpRequest.newBuilder(URI.create(SERVER + ":" + PORT + "/api/sector/" + sector + "/roots")).GET().build();

        HttpResponse<String> response = http.send(request, HttpResponse.BodyHandlers.ofString());

        //System.out.println(response.body());

        return Arrays.stream(response.body().split("\n")).collect(Collectors.toList());
    }

    // POST
    // http://server:port/api/sector/[id]/company/[your-company-name]/trajectory
    public void trajectoryNode(String section, String trajectory) throws IOException, InterruptedException {
        HttpRequest request = HttpRequest
                .newBuilder(URI.create(SERVER + ":" + PORT + "/api/sector/"+ section +"/company/" + NAME + "/trajectory"))
//                .timeout(Duration.of(4, ChronoUnit.SECONDS))
                .POST(HttpRequest.BodyPublishers.ofString("trajectory=" + trajectory))
                .header("Content-Type", "application/x-www-form-urlencoded")
                .build();

        try {
            HttpResponse<String> response = http.send(request, HttpResponse.BodyHandlers.ofString());
            System.out.println(response.statusCode());
        } catch (HttpTimeoutException e) {
            System.out.println(e.getMessage());
        }
    }
}
