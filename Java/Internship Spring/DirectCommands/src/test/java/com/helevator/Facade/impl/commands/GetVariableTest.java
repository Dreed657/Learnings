package com.helevator.Facade.impl.commands;

import com.helevator.Facade.impl.factory.VariableFactory;
import com.helevator.Facade.impl.storage.VariableRepository;
import org.junit.jupiter.api.AfterEach;
import org.junit.jupiter.api.Assertions;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;


class GetVariableTest extends AbstractCommandTest {

    @BeforeEach
    public void beforeEach() {
        this.variableRepo = new VariableRepository();

        this.variableRepo.add("randomString", VariableFactory.create("string", "random"));

        this.exe = new GetVariable(this.variableRepo);
    }

    @AfterEach
    public void tearDown() {
        this.exe = null;
    }

    @Test
    public void testGetShouldReturnAllStoredVariables() {
        var expected = this.variableRepo.getByName("randomString");
        var actual = this.exe.execute(new String[] { "randomString" });
;
        Assertions.assertEquals(expected.toString(), actual.toString());
    }
}