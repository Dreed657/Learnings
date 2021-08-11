package com.Helevator.ads.sorting;

public class BubbleSort extends AbstractSorter {

    /**
     * Bubble sort algorithm
     * @param arr unsorted input array
     * @return sorted array
     */
    @Override
    public int[] sort(int[] arr) {
        if (arr == null) {
            throw new NullPointerException();
        }

        // counting how many items are already sorted - i
        for (int i = 0; i < arr.length - 1; i++) {
            boolean swapped = false;

            // iteration over unsorted items
            for (int j = 0; j < arr.length - 1 - i; j++) {
                if (arr[j] > arr[j + 1]) {
                    swap(arr, j, j + 1);
                    swapped = true;
                }
            }

            // stops the for loop after iteration without swapping
            if (!swapped) break;
        }

        // returns the sorted array
        return arr;
    }
}
