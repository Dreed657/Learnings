package com.Helevator;

import java.io.IOException;

public class TraverseRunner implements Runnable {
    private String sector;
    private String traversal;

    public TraverseRunner(String sector, String traversal) {
        this.sector = sector;
        this.traversal = traversal;
    }

    @Override
    public void run() {
        var service = new GameService();

        System.out.println(String.format("Trying:  s%s n %s", this.sector, this.traversal));

        try {
            service.trajectoryNode(this.sector, this.traversal);
        } catch (IOException | InterruptedException e) {
            e.printStackTrace();
        }
    }
}
