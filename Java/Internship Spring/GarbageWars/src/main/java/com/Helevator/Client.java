package com.Helevator;

import java.util.concurrent.Executors;
import java.util.stream.IntStream;

public class Client {
    public static void main(String[] args) {
        int MAX_SECTION = 10;

        var pool = Executors.newFixedThreadPool(MAX_SECTION);

        IntStream.range(1, 11).mapToObj(i -> new SectorRunner(String.valueOf(i))).map(pool::submit);

//        var runner = new SectorRunner("8");
//        pool.submit(runner);

        pool.shutdown();
    }
}
