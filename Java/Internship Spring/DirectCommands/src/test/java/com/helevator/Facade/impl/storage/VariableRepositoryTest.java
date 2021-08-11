package com.helevator.Facade.impl.storage;

import com.helevator.Facade.api.storage.Repository;
import com.helevator.Facade.impl.factory.VariableFactory;
import org.junit.jupiter.api.AfterEach;
import org.junit.jupiter.api.Assertions;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;

class VariableRepositoryTest {
    private Repository<String, Variable> repository;

    @BeforeEach
    public void beforeEach() {
        this.repository = new VariableRepository();

        this.repository.add("randomString", VariableFactory.create("string", "random"));
        this.repository.add("randomNumber", VariableFactory.create("number", "123"));
    }

    @AfterEach
    public void afterEach() {
        this.repository = null;
    }

    @Test
    public void testGetAllWorksCorrectly() {
        var actual = this.repository.getAll().size();

        Assertions.assertEquals(2, actual);
    }

    @Test
    public void testGetByNameWorksCorrectly() {
        var actual = this.repository.getByName("randomString");

        Assertions.assertEquals("random", actual.getValue());
        Assertions.assertEquals("String", actual.getType());
    }

    @Test
    public void testGetByNameShouldThrowsAnErrorIfNotFound() {
        Assertions.assertThrows(IllegalArgumentException.class, () -> this.repository.getByName("random"));
    }

    @Test
    public void testAddWorksCorrectly() {
        var variable = VariableFactory.create("string", "asdasd");

        var sizeBefore = this.repository.getAll().size();

        this.repository.add("var1", variable);
        var actual = this.repository.getByName("var1");

        var sizeAfter = this.repository.getAll().size();

        Assertions.assertEquals(sizeBefore + 1, sizeAfter);
        Assertions.assertEquals(variable, actual);
    }

    @Test
    public void testAddShouldThrowsAnErrorIfAlreadyExists() {
        Assertions.assertThrows(IllegalArgumentException.class, () -> this.repository.add("randomString", null));
    }

    @Test
    public void testAddShouldThrowsAnErrorIfProvideInvalidCommand() {
        Assertions.assertThrows(IllegalArgumentException.class, () -> this.repository.add("random", null));
    }

    @Test
    public void testRemoveShouldWorkCorrectly() {
        var sizeBefore = this.repository.getAll().size();

        var actual = this.repository.remove("randomString");

        var sizeAfter = this.repository.getAll().size();

        Assertions.assertEquals(sizeBefore - 1, sizeAfter);
        Assertions.assertTrue(actual);
    }

    @Test
    public void testRemoveShouldReturnTrueOnSuccess() {
        var actual = this.repository.remove("randomString");

        Assertions.assertTrue(actual);
    }

    @Test
    public void testRemoveShouldThrowAnErrorIfVariableNotFound() {
        Assertions.assertThrows(IllegalArgumentException.class, () -> this.repository.remove("random"));
    }
}