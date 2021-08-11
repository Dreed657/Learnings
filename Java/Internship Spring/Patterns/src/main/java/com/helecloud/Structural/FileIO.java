package com.helecloud.Structural;

import java.io.*;

public class FileIO implements IO {
    private BufferedReader bufferedReader;
    private BufferedWriter bufferedWriter;

    public FileIO(String inputPath, String outputPath) {
        var input = new File(inputPath);
        var output = new File(outputPath);
        try {
            this.bufferedReader = new BufferedReader(new FileReader(input));
            this.bufferedWriter = new BufferedWriter(new FileWriter(output));
        } catch (IOException e) {
            e.printStackTrace();
        }
    }

    @Override
    public String read() {
        try {
            return this.bufferedReader.readLine();
        } catch (IOException e) {
            e.printStackTrace();
        }

        return null;
    }

    @Override
    public void write(String output) {
        try {
            this.bufferedWriter.write(output.toCharArray());
        } catch (IOException e) {
            e.printStackTrace();
        }
    }
}
