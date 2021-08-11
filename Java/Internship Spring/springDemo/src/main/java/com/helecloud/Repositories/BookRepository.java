package com.helecloud.Repositories;

import com.helecloud.Models.Book;
import org.springframework.stereotype.Repository;

import java.util.*;

@Repository
public class BookRepository {
    private final Map<String, Book> books;

    public BookRepository() {
        this.books = new HashMap<>();
    }

    public List<Book> getAll(){
        return new ArrayList<>(books.values());
    }

    public Book getById(String id) {
        return books.getOrDefault(id, null);
    }

    public Book save(Book entity) {
        if (entity == null)
        {
            throw new IllegalArgumentException("Invalid entity provided!");
        }

        if (entity.getId() == null || entity.getId().isEmpty()) {
            throw new IllegalArgumentException("Entity must provide valid id!");
        }

        books.put(entity.getId(), entity);

        return getById(entity.getId());
    }

    public Book update(Book entity) {
        if (entity == null)
        {
            throw new IllegalArgumentException("Invalid entity provided!");
        }

        if (entity.getId() == null || entity.getId().isEmpty()) {
            throw new IllegalArgumentException("Entity must provide valid id!");
        }

        var book = getById(entity.getId());

        if (book == null) {
            return null;
        } else {
            books.put(entity.getId(), entity);
            return getById(entity.getId());
        }
    }

    public boolean delete(String id) {
        return books.remove(id) != null;
    }
}
