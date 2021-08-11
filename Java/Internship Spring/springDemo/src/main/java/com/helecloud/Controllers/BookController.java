package com.helecloud.Controllers;

import com.helecloud.Dto.Book.BookCreateModel;
import com.helecloud.Dto.Book.BookUpdateModel;
import com.helecloud.Dto.Book.BookViewModel;
import com.helecloud.Models.Book;
import com.helecloud.Services.Book.BookService;
import lombok.RequiredArgsConstructor;
import lombok.extern.log4j.Log4j2;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import javax.validation.Valid;
import java.util.List;

@Log4j2
@RestController
@RequiredArgsConstructor
@RequestMapping("api/book")
public class BookController {

    private final BookService service;

    @GetMapping("/")
    public List<BookViewModel> getAll() {
        return service.getAll();
    }

    // For debug purposes only to get Ids in api client
    // Add authorization
    @GetMapping("/getAllWithIds")
    public List<Book> getAllWithIds() {
        return service.getAllWithIds();
    }

    @GetMapping("/byId")
    public ResponseEntity<BookViewModel> getById(@RequestParam String id) {
        return ResponseEntity.ok().body(service.getById(id));
    }

    @DeleteMapping("/")
    public ResponseEntity<Boolean> delete(@RequestParam String id) {
        return ResponseEntity.ok().body(service.delete(id));
    }

    @PostMapping("/create")
    public ResponseEntity<BookViewModel> create(@Valid @RequestBody BookCreateModel entity) {
        try {
            return ResponseEntity.ok().body(service.save(entity));
        } catch (IllegalArgumentException e) {
            return ResponseEntity.notFound().build();
        }
    }

    @PostMapping("/update")
    public ResponseEntity<BookViewModel> update(@Valid @RequestBody BookUpdateModel entity) {
        try {
            return ResponseEntity.ok().body(service.update(entity));
        } catch (IllegalArgumentException e) {
            return ResponseEntity.notFound().build();
        }
    }
}
