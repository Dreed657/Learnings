package com.helecloud.Services.Book;

import com.helecloud.Dto.Book.BookCreateModel;
import com.helecloud.Dto.Book.BookUpdateModel;
import com.helecloud.Dto.Book.BookViewModel;
import com.helecloud.Models.Book;
import com.helecloud.Repositories.BookRepository;
import lombok.RequiredArgsConstructor;
import lombok.extern.log4j.Log4j2;
import org.springframework.stereotype.Service;

import java.util.List;
import java.util.UUID;
import java.util.stream.Collectors;

@Service
@RequiredArgsConstructor
@Log4j2
public class BookServiceImpl implements BookService {

    // Book validation constants
    private final int BOOK_MINIMUM_NAME_LENGTH = 5;
    private final int BOOK_MINIMUM_DESCRIPTION_LENGTH = 5;
    
    private final BookRepository repo;

    public List<BookViewModel> getAll(){
        return repo.getAll()
                .stream()
                .map(e -> new BookViewModel(e.getName(), e.getDescription()))
                .collect(Collectors.toList());
    }

    public List<Book> getAllWithIds(){
        return repo.getAll();
    }

    public BookViewModel getById(String id) {
        var entity = repo.getById(id);

        return new BookViewModel(entity.getName(), entity.getDescription());
    }

    public BookViewModel save(BookCreateModel inputModel) {
        var entity = new Book(UUID.randomUUID().toString(), inputModel.getName(), inputModel.getDescription());
        var created = repo.save(entity);

        return new BookViewModel(created.getName(), created.getDescription());
    }

    public BookViewModel update(BookUpdateModel inputModel) {
        var entity = new Book(inputModel.getId(), inputModel.getName(), inputModel.getDescription());
        var updated = repo.update(entity);

        return new BookViewModel(updated.getName(), updated.getDescription());
    }

    public boolean delete(String id) {
        return repo.delete(id);
    }

    // Getto way of validation -_-
//    private void validateBook(Book book) {
//        if (book.getName().length() < BOOK_MINIMUM_NAME_LENGTH) {
//            throw new IllegalArgumentException("Book name must be less then " + BOOK_MINIMUM_NAME_LENGTH + " characters");
//        }
//
//        if (book.getDescription().length() < BOOK_MINIMUM_DESCRIPTION_LENGTH) {
//            throw new IllegalArgumentException("Book description must be less then " + BOOK_MINIMUM_DESCRIPTION_LENGTH + " characters");
//        }
//    }
}
