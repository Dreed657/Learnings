package com.helecloud.Controllers;

import com.helecloud.Services.File.FileService;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import java.io.IOException;
import java.util.List;

@RestController
@RequestMapping("api/files")
public class FileController {

    private final FileService fileService;

    public FileController(FileService fileService) {
        this.fileService = fileService;
    }

    @GetMapping()
    public List<String> getFileLines() throws IOException {
        return this.fileService.parseFile("text.txt");
    }
}
