package com.Helevator;

import java.io.IOException;
import java.util.Arrays;
import java.util.concurrent.Executors;
import java.util.stream.Collectors;

public class SectorRunner implements Runnable {

    private String sector;

    public SectorRunner(String sector) {
        this.sector = sector;
    }

    @Override
    public void run() {
        var service = new GameService();
        var MAX_CLIENTS = 2500;
        var sectorPool = Executors.newFixedThreadPool(MAX_CLIENTS);

        try {
            var roots = service.getRootNodes(this.sector);
            var edges = service.getObjectNodes(this.sector);

            for (String traverse : edges) {
                var traverseNodes = Arrays.stream(traverse.split(" ")).collect(Collectors.toList());

                if (roots.stream().noneMatch(traverseNodes::contains)) {
                    var runnable = new TraverseRunner(this.sector, traverse);
                    sectorPool.submit(runnable);
                }
            }
        } catch (IOException | InterruptedException e) {
            e.printStackTrace();
        }

        sectorPool.shutdown();
    }
}
