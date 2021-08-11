package com.Helevator.ads.sorting;

import com.Helevator.ads.sorting.contracts.Sorter;

public class MergeSort implements Sorter {

    /**
     * Merge sort algorithm
     * @param arr unsorted input array
     * @return sorted array
     */
    @Override
    public int[] sort(int[] arr) {
        if (arr == null) {
            throw new NullPointerException();
        }

        mergeSort(arr, 0, arr.length - 1);
        return arr;
    }

    private void mergeSort(int[] arr, int left, int right) {
        if (left < right) {
            // Find the middle point
            int mid = (left + right) / 2;

            // Sort first and second halves
            mergeSort(arr, left, mid);
            mergeSort(arr, mid + 1, right);

            // Merge the sorted halves
            merge(arr, left, mid, right);
        }
    }

    private void merge(int[] arr, int left, int mid, int right) {
        // Allocating new memory for tmp sorting
        int length = right - left + 1;
        var tmp = new int[length];

        // Initial indexes
        int i = left;
        int j = mid + 1;
        int k = 0;

        while(i <= mid && j <= right) {
            if(arr[i] <= arr[j]) {
                tmp[k] = arr[i];
                k += 1;
                i += 1;
            } else {
                tmp[k] = arr[j];
                k += 1;
                j += 1;
            }
        }

        // Copy remaining element for first halve
        while(i <= mid) {
            tmp[k] = arr[i];
            k += 1;
            i += 1;
        }

        // Copy remaining element for second halve
        while(j <= right) {
            tmp[k] = arr[j];
            k += 1;
            j += 1;
        }

        for(i = left; i <= right; i += 1) {
            arr[i] = tmp[i - left];
        }
    }
}
