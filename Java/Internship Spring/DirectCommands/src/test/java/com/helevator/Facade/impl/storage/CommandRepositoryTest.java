package com.helevator.Facade.impl.storage;

import com.helevator.Facade.api.Command;
import com.helevator.Facade.api.Executable;
import com.helevator.Facade.api.storage.Repository;
import com.helevator.Facade.impl.commands.CountWords;
import com.helevator.Facade.impl.commands.Reverse;
import com.helevator.Facade.impl.commands.ReverseWords;
import com.helevator.Facade.impl.commands.SetVariable;
import org.junit.jupiter.api.AfterEach;
import org.junit.jupiter.api.Assertions;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;

import java.util.Locale;

class CommandRepositoryTest {
    private Repository<String, Executable> repository;

    @BeforeEach
    public void beforeEach() {
        this.repository = new CommandRepository();

        this.repository.add("reverse", new Reverse());
        this.repository.add("reverse-words", new ReverseWords());
        this.repository.add("count-words", new CountWords());
    }

    @AfterEach
    public void afterEach() {
        this.repository = null;
    }

    @Test
    public void testGetAllWorksCorrectly() {
        var actual = this.repository.getAll().size();

        Assertions.assertEquals(3, actual);
    }

    @Test
    public void testGetByNameWorksCorrectly() {
        var actual = (Command)this.repository.getByName("count-words");

        Assertions.assertEquals("count-words", actual.getName().toLowerCase(Locale.ROOT));
    }

    @Test
    public void testGetByNameShouldThrowsAnErrorIfNotFound() {
        Assertions.assertThrows(IllegalArgumentException.class, () -> this.repository.getByName("random"));
    }

    @Test
    public void testAddWorksCorrectly() {
        var command = new SetVariable(null);

        var sizeBefore = this.repository.getAll().size();

        this.repository.add("set", command);
        var actual = this.repository.getByName("set");

        var sizeAfter = this.repository.getAll().size();

        Assertions.assertEquals(sizeBefore + 1, sizeAfter);
        Assertions.assertEquals(command, actual);
    }

    @Test
    public void testAddShouldThrowsAnErrorIfAlreadyExists() {
        Assertions.assertThrows(IllegalArgumentException.class, () -> this.repository.add("count-words", null));
    }

    @Test
    public void testAddShouldThrowsAnErrorIfProvideInvalidCommand() {
        Assertions.assertThrows(IllegalArgumentException.class, () -> this.repository.add("random", null));
    }

    @Test
    public void testRemoveShouldWorkCorrectly() {
        var sizeBefore = this.repository.getAll().size();

        var actual = this.repository.remove("count-words");

        var sizeAfter = this.repository.getAll().size();

        Assertions.assertEquals(sizeBefore - 1, sizeAfter);
        Assertions.assertTrue(actual);
    }

    @Test
    public void testRemoveShouldReturnTrueOnSuccess() {
        var actual = this.repository.remove("count-words");

        Assertions.assertTrue(actual);
    }

    @Test
    public void testRemoveShouldThrowAnError() {
        Assertions.assertThrows(IllegalArgumentException.class, () -> this.repository.remove("random"));
    }
}