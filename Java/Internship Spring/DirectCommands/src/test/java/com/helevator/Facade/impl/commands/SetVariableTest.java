package com.helevator.Facade.impl.commands;


import com.helevator.Facade.impl.storage.VariableRepository;
import org.junit.jupiter.api.AfterEach;
import org.junit.jupiter.api.Assertions;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;

class SetVariableTest extends AbstractCommandTest {
    @BeforeEach
    public void beforeEach() {
        this.variableRepo = new VariableRepository();

        this.exe = new SetVariable(this.variableRepo);
    }

    @AfterEach
    public void tearDown() {
        this.exe = null;
    }

    @Test
    public void testSetAddCorrectly() {
        var sizeBefore = this.variableRepo.getAll().size();

        this.exe.execute(new String[] {"random", "string", "randomString"});

        var sizeAfter = this.variableRepo.getAll().size();

        Assertions.assertEquals(sizeBefore + 1, sizeAfter);
    }

    @Test
    public void testShouldThrowAnErrorIfInputIsNull() {
        Assertions.assertThrows(NullPointerException.class, () -> this.exe.execute(null));
    }
}