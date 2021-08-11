package com.helecloud.Services.Book;

import com.github.javafaker.Faker;
import com.helecloud.Dto.Book.BookCreateModel;
import com.helecloud.Dto.Book.BookUpdateModel;
import com.helecloud.Dto.Book.BookViewModel;
import com.helecloud.Models.Book;
import com.helecloud.Repositories.BookRepository;
import org.junit.jupiter.api.AfterEach;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;

import java.util.List;
import java.util.stream.Collectors;

import static org.assertj.core.api.AssertionsForClassTypes.*;

class BookServiceImplTest {

    private BookRepository bookRepository;
    private BookService bookService;

    private final Faker faker = new Faker();

    @BeforeEach
    void setUp() {
        this.bookRepository = new BookRepository();
        this.bookService = new BookServiceImpl(this.bookRepository);
    }

    @AfterEach
    void tearDown() {
        this.bookRepository = null;
        this.bookService = null;
    }

    @Test
    void getAll() {
        // Arrange
        var expected = List.of(
                new Book("1", faker.book().title(), faker.book().publisher()),
                new Book("2", faker.book().title(), faker.book().publisher())
        );
        expected.forEach(b -> bookRepository.save(b));

        // Act
        var convertedExpected = expected
                .stream()
                .map(b -> new BookViewModel(b.getName(), b.getDescription()))
                .collect(Collectors.toList());
        var actual = bookService.getAll();

        // Assert
        assertThat(actual.size()).isEqualTo(convertedExpected.size());
        assertThat(actual)
                .isEqualTo(convertedExpected);
    }

    @Test
    void getAllWithIds() {
        var expected = List.of(
                new Book("1", faker.book().title(), faker.book().publisher()),
                new Book("2", faker.book().title(), faker.book().publisher())
        );
        expected.forEach(b -> bookRepository.save(b));

        var actual = bookService.getAllWithIds();

        assertThat(actual.size()).isEqualTo(expected.size());
        assertThat(actual).isEqualTo(expected);
    }

    @Test
    void getById() {
        var book = new Book("1", "Random", "Random Random Random Random Random");
        bookRepository.save(book);

        var expected = new BookViewModel("Random", "Random Random Random Random Random");
        var actual = bookService.getById("1");

        assertThat(actual).isEqualTo(expected);
    }

    @Test
    void save() {
        var input = new BookCreateModel(faker.book().title(), faker.book().publisher());

        var output = bookService.save(input);

        var expected = new Book(null, input.getName(), input.getDescription());
        var actual = new Book(null, output.getName(), output.getDescription());

        assertThat(actual.getName()).isEqualTo(expected.getName());
        assertThat(actual.getDescription()).isEqualTo(expected.getDescription());
    }

    @Test
    void update() {
        var book = new Book("1", faker.book().title(), faker.book().publisher());
        bookRepository.save(book);

        var updateModel = new BookUpdateModel("1", "Random", "Random");
        var actual = bookService.update(updateModel);

        var expected = new BookViewModel("Random", "Random");

        assertThat(actual)
                .isEqualToComparingFieldByField(expected)
                .isEqualTo(expected);
    }

    @Test
    void deleteShouldReturnTrueIfSuccessful() {
        var book = new Book("1", faker.book().title(), faker.book().publisher());
        bookRepository.save(book);

        var actual = bookService.delete("1");

        assertThat(actual).isTrue();
    }

    @Test
    void deleteShouldReturnFalseIfNotSuccessful() {
        var actual = bookService.delete("1");

        assertThat(actual).isFalse();
    }
}