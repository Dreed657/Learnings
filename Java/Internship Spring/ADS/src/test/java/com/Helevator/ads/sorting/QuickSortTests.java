package com.Helevator.ads.sorting;

import org.junit.jupiter.api.*;

public class QuickSortTests extends AbstractSortingTests {
    @BeforeEach
    public void beforeEach() {
        this.sorter = new BubbleSort();
    }

    @AfterEach
    public void tearDown() {
        this.sorter = null;
    }
}
