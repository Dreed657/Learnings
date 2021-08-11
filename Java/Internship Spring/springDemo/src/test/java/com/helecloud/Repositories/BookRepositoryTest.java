package com.helecloud.Repositories;

import com.github.javafaker.Faker;
import com.helecloud.Models.Book;
import org.junit.jupiter.api.AfterEach;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;

import java.util.List;

import static org.assertj.core.api.AssertionsForClassTypes.*;

class BookRepositoryTest {

    private BookRepository bookRepository;

    private final Faker faker = new Faker();

    @BeforeEach
    void setUp() {
        this.bookRepository = new BookRepository();
    }

    @AfterEach
    void tearDown() {
        this.bookRepository = null;
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
        var actual = bookRepository.getAll();

        // Assert
        assertThat(actual.size()).isEqualTo(expected.size());
        assertThat(actual).isEqualTo(expected);
    }

    @Test
    void getById() {
        var expected = new Book("1", faker.book().title(), faker.book().publisher());
        bookRepository.save(expected);

        var actual = bookRepository.getById("1");

        assertThat(actual).isEqualTo(expected);
    }

    @Test
    void getByIdShouldReturnNullIfDoesNotExists() {
        var actual = bookRepository.getById("1");
        assertThat(actual).isNull();
    }

    @Test
    void saveShouldThrowExceptionWhenProvidedInvalidEntity() {
        assertThatThrownBy(() -> {
            bookRepository.save(null);
        }).isInstanceOf(IllegalArgumentException.class)
            .hasMessageContaining("Invalid entity provided!");
    }

    @Test
    void saveShouldThrowExceptionWhenProvidedInvalidEntityId() {
        assertThatThrownBy(() -> {
            var book = new Book(null, faker.book().title(), faker.book().publisher());
            bookRepository.save(book);
        }).isInstanceOf(IllegalArgumentException.class)
                .hasMessageContaining("Entity must provide valid id!");
    }

    @Test
    void saveShouldAddCorrectly() {
        var sizeBefore = bookRepository.getAll().size();

        var expected = new Book("1", faker.book().title(), faker.book().publisher());
        var actual = bookRepository.save(expected);

        var sizeAfter = bookRepository.getAll().size();

        assertThat(sizeAfter).isNotEqualTo(sizeBefore);
        assertThat(actual).isEqualTo(expected);
    }

    @Test
    void updateShouldThrowExceptionWhenProvidedInvalidEntity() {
        assertThatThrownBy(() -> {
            bookRepository.update(null);
        }).isInstanceOf(IllegalArgumentException.class)
                .hasMessageContaining("Invalid entity provided!");
    }

    @Test
    void updateShouldThrowExceptionWhenProvidedInvalidEntityId() {
        assertThatThrownBy(() -> {
            var book = new Book(null, faker.book().title(), faker.book().publisher());
            bookRepository.update(book);
        }).isInstanceOf(IllegalArgumentException.class)
                .hasMessageContaining("Entity must provide valid id!");
    }

    @Test
    void updateShouldReturnNullIfEntityNotFound() {
        var expected = new Book("1", "Random", "Random");
        var actual = bookRepository.update(expected);

        assertThat(actual).isNull();
    }

    @Test
    void updateShouldUpdateEntityCorrectly() {
        var book = new Book("1", faker.book().title(), faker.book().publisher());
        bookRepository.save(book);

        var expected = new Book("1", "Random", "Random");
        var actual = bookRepository.update(expected);

        assertThat(actual).isEqualTo(expected);
    }

    @Test
    void deleteShouldReturnTrueIfSuccessful() {
        var book = new Book("1", faker.book().title(), faker.book().publisher());
        bookRepository.save(book);

        var actual = bookRepository.delete("1");

        assertThat(actual).isTrue();
    }

    @Test
    void deleteShouldReturnFalseIfNotSuccessful() {
        var actual = bookRepository.delete("1");

        assertThat(actual).isFalse();
    }
}