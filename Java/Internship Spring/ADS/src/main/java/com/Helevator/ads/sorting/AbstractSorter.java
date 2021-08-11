package com.Helevator.ads.sorting;

import com.Helevator.ads.sorting.contracts.Sorter;

public abstract class AbstractSorter implements Sorter {

    // A utility function to swap two elements
    protected static void swap(int[] arr, int i, int j) {
        int tmp = arr[i];
        arr[i] = arr[j];
        arr[j] = tmp;
    }
}
