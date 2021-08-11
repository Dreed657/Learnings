package com.helevator.service;

import com.helevator.model.dto.BookDto;
import com.helevator.model.dto.BookInputDto;
import com.helevator.model.entity.Address;
import com.helevator.model.entity.Author;
import com.helevator.model.entity.Book;
import com.helevator.model.entity.Edition;
import com.helevator.repostiory.AuthorRepository;
import com.helevator.repostiory.BookRepository;
import com.helevator.repostiory.EditionRepository;
import lombok.RequiredArgsConstructor;
import org.modelmapper.ModelMapper;
import org.springframework.stereotype.Service;

import java.util.List;
import java.util.stream.Collectors;

@Service
@RequiredArgsConstructor
public class BookService {

    private final BookRepository bookRepository;

    private final AuthorRepository authorRepository;

    private final EditionRepository editionRepository;

    private final ModelMapper mapper;

    public BookDto getById(Integer id) {
        var book = bookRepository.getById(id);

        return mapper.map(book, BookDto.class);
    }

    public List<BookDto> getBooks() {
        return bookRepository.findAll()
                .stream().map(b -> mapper.map(b, BookDto.class))
                .collect(Collectors.toList());
    }

    public BookDto create(BookInputDto model) {
        var authors = model.getAuthors()
                .stream()
                .map(a -> mapper.map(a, Author.class))
                .collect(Collectors.toSet());

        authorRepository.saveAll(authors);

        var editions = model.getEditions()
                .stream()
                .map(a -> mapper.map(a, Edition.class))
                .collect(Collectors.toSet());

        editionRepository.saveAll(editions);

        var book = new Book();

        book.setTitle(model.getTitle());
        book.setGenre(model.getGenre());
        book.setAuthors(authors);
        book.setEditions(editions);

        bookRepository.save(book);

        return mapper.map(book, BookDto.class);
    }
}
