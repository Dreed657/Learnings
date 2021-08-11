package helevator.FolderTraversal;

import java.io.File;

public class FileUtils {
    public static int countFilesRecursively(File file) {
        int result = 0;
        if (file.isDirectory()) {
            File[] files = file.listFiles();

            if (files != null) {
                for (File tmp : files) {
                    if (tmp.isDirectory()) {
                        result += countFilesRecursively(tmp);
                    } else {
                        result++;
                    }
                }
            }
        } else {
            result++;
        }
        return result;
    }
}
