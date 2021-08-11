package com.helevator.controller;

import com.helevator.model.dto.*;
import com.helevator.service.BookService;
import lombok.RequiredArgsConstructor;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
@RequestMapping("/books")
@RequiredArgsConstructor
public class BookController {
    private final BookService service;

    @GetMapping("/{id}")
    public ResponseEntity<BookDto> getById(@PathVariable Integer id) {
        return ResponseEntity.ok().body(service.getById(id));
    }

    @GetMapping("/")
    public ResponseEntity<List<BookDto>> listUsers() {
        return ResponseEntity.ok().body(service.getBooks());
    }

    @PostMapping("/")
    public ResponseEntity<BookDto> create(@RequestBody BookInputDto model) {
        return ResponseEntity.ok().body(service.create(model));
    }
}
