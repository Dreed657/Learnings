package com.helevator.Facade.impl.commands;

import org.junit.jupiter.api.*;

class ReverseTest extends AbstractCommandTest{
    @BeforeEach
    public void beforeEach() {
        this.exe = new Reverse();
    }

    @AfterEach
    public void tearDown() {
        this.exe = null;
    }

    @Test
    public void testMethodWorkCorrectly() {
        var actual = this.exe.execute(new String[] {"agfa", "hfdg"});
        var expected = "gdfh afga";

        Assertions.assertEquals(expected, actual);
    }

    @Test
    public void testShouldThrowAnErrorIfInputIsNull() {
        Assertions.assertThrows(NullPointerException.class, () -> this.exe.execute(null));
    }
}