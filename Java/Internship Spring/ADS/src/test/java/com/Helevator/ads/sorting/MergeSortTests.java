package com.Helevator.ads.sorting;

import org.junit.jupiter.api.*;

public class MergeSortTests extends AbstractSortingTests {
    @BeforeEach
    public void beforeEach() {
        this.sorter = new MergeSort();
    }

    @AfterEach
    public void tearDown() {
        this.sorter = null;
    }
}
