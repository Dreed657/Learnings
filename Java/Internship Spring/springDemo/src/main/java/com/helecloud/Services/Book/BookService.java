package com.helecloud.Services.Book;

import com.helecloud.Dto.Book.BookCreateModel;
import com.helecloud.Dto.Book.BookUpdateModel;
import com.helecloud.Dto.Book.BookViewModel;
import com.helecloud.Models.Book;

import java.util.List;

public interface BookService {
    List<BookViewModel> getAll();
    List<Book> getAllWithIds();
    BookViewModel getById(String id);
    BookViewModel save(BookCreateModel inputModel);
    BookViewModel update(BookUpdateModel inputModel);
    boolean delete(String id);
}
