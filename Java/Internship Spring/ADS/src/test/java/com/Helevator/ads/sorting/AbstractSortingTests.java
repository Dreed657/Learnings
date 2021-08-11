package com.Helevator.ads.sorting;

import com.Helevator.ads.sorting.contracts.Sorter;
import org.junit.jupiter.api.Assertions;
import org.junit.jupiter.api.*;

import java.util.Random;

public abstract class AbstractSortingTests {
    protected Sorter sorter;

    // Those test are stolen :0
    @Test
    public void testEmptyArray() {
        int[] arr = new int[0];

        int[] sortedArr = sorter.sort(arr);

        Assertions.assertTrue(isSorted(sortedArr));
    }

    @Test
    public void testArrayOneElement() {
        int[] arr = {1};

        int[] sortedArr = sorter.sort(arr);

        Assertions.assertTrue(isSorted(sortedArr));
    }

    @Test
    public void testSimpleArray() {
        int[] arr = {5, 2, 4, 1, 8};

        int[] sortedArr = sorter.sort(arr);

        Assertions.assertTrue(isSorted(sortedArr));
    }

    @Test
    public void testBigRandomArray() {
        int[] arr = new int[100];
        Random random = new Random();

        for (int i = 0; i < arr.length; i++) {
            arr[i] = random.nextInt(100);
        }

        int[] sortedArr = sorter.sort(arr);

        Assertions.assertTrue(isSorted(sortedArr));
    }

    @Test
    public void testSortedArray() {
        int[] arr = {0, 1, 2, 3, 4, 5};

        int[] sortedArr = sorter.sort(arr);

        Assertions.assertTrue(isSorted(sortedArr));
    }

    @Test
    public void testInversedArray() {
        int[] arr = {10, 9, 8, 7, 6, 5, 4, 3, 2, 1};

        int[] sortedArr = sorter.sort(arr);

        Assertions.assertTrue(isSorted(sortedArr));
    }

    private boolean isSorted(int[] arr) {
        for (int i = 0; i < arr.length -1; i++) {
            if (arr[i] > arr[i+1]) {
                return false;
            }
        }
        return true;
    }

    @Test
    public void bubbleSortTestNull() {
        Assertions.assertThrows(NullPointerException.class, () -> sorter.sort(null));
    }
}
