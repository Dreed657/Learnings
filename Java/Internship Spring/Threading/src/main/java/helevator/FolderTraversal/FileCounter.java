package helevator.FolderTraversal;

import java.io.File;
import java.util.Arrays;
import java.util.List;
import java.util.stream.Collectors;

public class FileCounter {

    public static void concurrentFileCount(File... files) throws InterruptedException {
        List<Thread> threadList = Arrays.stream(files)
                .map(FileCountingThread::new)
                .map(Thread::new)
                .collect(Collectors.toList());

        System.out.println("Starting concurrent file count ...");

        var startTime = System.currentTimeMillis();
        threadList.forEach(Thread::start);
        threadList.forEach(t -> {
            try {
                t.join();
            } catch (InterruptedException e) {
                throw new RuntimeException();
            }
        });

        var totalTime = System.currentTimeMillis() - startTime;

        System.out.println(String.format("Concurrent count took: %s ms", totalTime));
    }

    public static void sequentialFileCount(File... files) throws InterruptedException {
        List<Thread> threadList = Arrays.stream(files)
                .map(FileCountingThread::new)
                .map(Thread::new)
                .collect(Collectors.toList());

        System.out.println("Starting sequential file count ...");

        var startTime = System.currentTimeMillis();

        for (Thread t : threadList) {
            t.start();
            t.join();
        }

        var totalTime = System.currentTimeMillis() - startTime;

        System.out.println(String.format("Sequential count took: %s ms", totalTime));
    }
}
