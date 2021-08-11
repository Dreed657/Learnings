package com.Helevator.ads.sorting;

public class QuickSort extends AbstractSorter {

    /**
     * Quick sort algorithm
     * @param arr unsorted input array
     * @return sorted array
     */
    @Override
    public int[] sort(int[] arr) {
        if (arr == null) {
            throw new NullPointerException();
        }

        quickSort(arr, 0, arr.length - 1);
        return arr;
    }

    private static void quickSort(int[] arr, int left, int right) {
        if (left < right) {
            // pivot is partitioning index of arr
            int pivot = partition(arr, left, right);

            // separately sort elements before
            // partition and after partition
            quickSort(arr, left, pivot - 1);
            quickSort(arr, pivot + 1, right);
        }
    }

    private static int partition(int[] arr, int left, int right) {
        // pivot
        int pivotIndex = (right + left) / 2;
        int pivot = arr[pivotIndex];

        // swaps pivot to the most right index
        swap(arr, pivotIndex, right);
        pivotIndex = right;

        int smallestIndex = left;

        for (int i = left; i <= right - 1; i++) {

            // If current element is smaller
            // than the pivot
            if (arr[i] < pivot) {

                // Increment index of
                // smaller element
                smallestIndex++;
                swap(arr, smallestIndex, i);
            }
        }

        swap(arr, smallestIndex, pivotIndex);
        return smallestIndex;
    }
}
