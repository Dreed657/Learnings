package com.helevator.Facade.impl.factory;

import org.junit.jupiter.api.Assertions;
import org.junit.jupiter.api.Test;

class VariableFactoryTest {
    @Test
    public void testCreateStringVariable() {
        var variable = VariableFactory.create("string", "test");

        Assertions.assertEquals(variable.getType(), "String");
        Assertions.assertEquals(variable.getValue(), "test");
    }

    @Test
    public void testCreateIntegerVariable() {
        var variable = VariableFactory.create("number", "123");

        Assertions.assertEquals(variable.getType(), "Integer");
        Assertions.assertEquals(variable.getValue(), 123);
    }

    @Test
    public void testCreateNumberVariableWithWrongType() {
        Assertions.assertThrows(IllegalArgumentException.class, () -> VariableFactory.create("number", "test"));
    }

    @Test
    public void testCreateShouldThrowAnErrorWhenEnteredInvalidType() {
        Assertions.assertThrows(IllegalArgumentException.class, () -> VariableFactory.create("random", "number"));
    }

    @Test
    public void testCreateShouldThrowAnErrorWhenEnteredNullValue() {
        Assertions.assertThrows(IllegalArgumentException.class, () -> VariableFactory.create("number", null));
    }
}