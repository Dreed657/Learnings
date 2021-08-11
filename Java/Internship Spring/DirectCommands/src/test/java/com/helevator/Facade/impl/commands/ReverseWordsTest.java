package com.helevator.Facade.impl.commands;

import org.junit.jupiter.api.*;

class ReverseWordsTest extends AbstractCommandTest {
    @BeforeEach
    public void beforeEach() {
        this.exe = new ReverseWords();
    }

    @AfterEach
    public void tearDown() {
        this.exe = null;
    }

    @Test
    public void testMethodWorkCorrectly() {
        var actual = this.exe.execute(new String[] {"asd", "asd"});
        var expected = "dsa dsa";

        Assertions.assertEquals(expected, actual);
    }

    @Test
    public void testShouldThrowAnErrorIfInputIsNull() {
        Assertions.assertThrows(NullPointerException.class, () -> this.exe.execute(null));
    }
}