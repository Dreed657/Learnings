package com.helecloud.Structural;

public class IOBuilder {
    public IO buildFileIO(String inputPath, String outputPath) {
        return new FileIO(inputPath, outputPath);
    }

    public IO buildConsoleIO(){
        return new ConsoleIO();
    }
}
