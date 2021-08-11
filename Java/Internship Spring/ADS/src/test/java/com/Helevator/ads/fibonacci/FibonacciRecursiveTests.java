package com.Helevator.ads.fibonacci;

import org.junit.jupiter.api.*;

public class FibonacciRecursiveTests {
    private fibRec instance;

    @BeforeEach
    public void beforeEach() {
        this.instance = new fibRec();
    }

    @AfterEach
    public void tearDown() {
        this.instance = null;
    }

    @Test
    public void testRecursiveFibonacciWorksCorrectly() {
        var got = this.instance.getFibonacci(10);
        var want = 55;

        Assertions.assertEquals(got, want);
    }
}
