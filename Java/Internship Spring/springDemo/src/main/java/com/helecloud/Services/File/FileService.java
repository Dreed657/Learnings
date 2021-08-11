package com.helecloud.Services.File;

import org.springframework.core.io.ClassPathResource;
import org.springframework.stereotype.Service;

import java.io.ByteArrayOutputStream;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.ArrayList;
import java.util.List;

@Service
public class FileService {
    public List<String> parseFile(String fileName) throws IOException {
        var result = new ArrayList<String>();
        var file = new ClassPathResource(fileName);
        var stream = file.getInputStream();

        InputStreamReader reader = new InputStreamReader(stream);
        var buffer = new ByteArrayOutputStream(4096);
        int c = -1;

        int count = 1;

        while ((c = reader.read()) != -1) {
            if ((char)c == '\n') {
                String output = buffer.toString().trim();
                int wordCount = output.split(" ").length;
                String formatted = String.format("%s# %s (words: %s)", count, output, wordCount);
                result.add(formatted);
                buffer.reset();
                count++;
            } else if ((char)c != '\r'){
                buffer.write((char)c);
            }
        }

        return result;
    }
}
