package com.helevator.Facade.impl.commands;

import com.helevator.Facade.impl.factory.VariableFactory;
import com.helevator.Facade.impl.storage.Variable;
import com.helevator.Facade.impl.storage.VariableRepository;
import org.junit.jupiter.api.AfterEach;
import org.junit.jupiter.api.Assertions;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;

import java.util.Collection;


class GetAllVariablesTest extends AbstractCommandTest {

    @BeforeEach
    public void beforeEach() {
        this.variableRepo = new VariableRepository();

        this.variableRepo.add("randomString", VariableFactory.create("string", "random"));
        this.variableRepo.add("randomNumber", VariableFactory.create("number", "123"));

        this.exe = new GetAllVariables(this.variableRepo);
    }

    @AfterEach
    public void tearDown() {
        this.exe = null;
    }

    @Test
    public void testGetShouldReturnAllStoredVariables() {
        var expected = this.getAll();
        var actual = this.exe.execute(null);

        Assertions.assertEquals(expected, actual);
    }

    @Test
    public void testGetShouldThrowWhenNoVariablesStores() {
        Assertions.assertThrows(NullPointerException.class, () -> new GetAllVariables(null).execute(null));
    }

    private String getAll() {
        var sb = new StringBuilder();
        var variables = (Collection<Variable>)this.variableRepo.getAll();

        for (Variable variable : variables) {
            sb.append(variable.toString()).append("\n");
        }

        return sb.toString();
    }
}