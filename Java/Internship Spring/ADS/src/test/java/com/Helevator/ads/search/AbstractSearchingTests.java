package com.Helevator.ads.search;

import com.Helevator.ads.search.contracts.Searcher;
import org.junit.jupiter.api.*;

public abstract class AbstractSearchingTests {
    protected Searcher<Integer> searcher;
    protected Integer[] array = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};

    @Test
    public void testContainsShouldThrowExceptionIfArrayIsNull() {
        Assertions.assertThrows(NullPointerException.class, () -> this.searcher.contains(null, 1));
    }

    @Test
    public void testContainsShouldReturnTrueIsElementIsFound() {
        boolean actual = this.searcher.contains(array,10);

        Assertions.assertTrue(actual);
    }

    @Test
    public void testContainsShouldReturnFalseIfElementIsNotFound() {
        boolean actual = this.searcher.contains(array,20);

        Assertions.assertFalse(actual);
    }
}
