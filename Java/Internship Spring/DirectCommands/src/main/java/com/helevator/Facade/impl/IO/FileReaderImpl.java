package com.helevator.Facade.impl.IO;

import com.helevator.Facade.api.IO.Reader;

import java.io.*;

public class FileReaderImpl implements Reader {
    private BufferedReader bufferedReader;

    public FileReaderImpl(String filePath) {
        var file = new File(filePath);
        try {
            var fileReader = new FileReader(file);
            this.bufferedReader = new BufferedReader(fileReader);
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
}
