package helevator.FolderTraversal;

import java.io.File;

public class App {
    public static void main(String[] args) {
        File var = new File("/var");
        File usr = new File("/usr");

        try {
            FileCounter.sequentialFileCount(var, usr);
            FileCounter.concurrentFileCount(var, usr);
        } catch (Exception e) {
            System.out.println(e.getMessage());
            e.printStackTrace();
        }
    }
}
