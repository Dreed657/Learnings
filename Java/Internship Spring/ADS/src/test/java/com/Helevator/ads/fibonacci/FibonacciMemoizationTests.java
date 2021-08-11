package com.Helevator.ads.fibonacci;

import org.junit.jupiter.api.*;

import static org.junit.jupiter.api.Assertions.*;

class FibonacciMemoizationTests {
    private fibMem instance;

    @BeforeEach
    public void beforeEach() {
        this.instance = new fibMem();
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