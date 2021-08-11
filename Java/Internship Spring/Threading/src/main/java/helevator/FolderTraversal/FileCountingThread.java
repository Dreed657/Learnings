package helevator.FolderTraversal;

import java.io.File;

public class FileCountingThread implements Runnable {
    private final File file;

    public FileCountingThread(File file) {
        this.file = file;
    }

    @Override
    public void run() {
        long start = System.currentTimeMillis();
        int result = FileUtils.countFilesRecursively(this.file);
        long total = System.currentTimeMillis() - start;
        System.out.println(String.format("Thread counted: %s, files in %s for %s ms.", result, this.file.getAbsoluteFile(), total));
    }
}
