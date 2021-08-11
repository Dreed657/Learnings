package com.helevator.Facade.impl.commands;

import org.junit.jupiter.api.*;

class CountWordsTest extends AbstractCommandTest {
    @BeforeEach
    public void beforeEach() {
        this.exe = new CountWords();
    }

    @AfterEach
    public void tearDown() {
        this.exe = null;
    }

    @Test
    public void testMethodWorkCorrectly() {
        var actual = this.exe.execute(new String[] {"asd", "asd"});
        var expected = 2;

        Assertions.assertEquals(expected, actual);
    }

    @Test
    public void testShouldThrowAnErrorIfInputIsNull() {
        Assertions.assertThrows(NullPointerException.class, () -> this.exe.execute(null));
    }
}