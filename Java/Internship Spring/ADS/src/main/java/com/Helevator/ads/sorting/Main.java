package com.Helevator.ads.sorting;

import com.Helevator.ads.sorting.contracts.Sorter;

public class Main {

    // This method is used for manual testing in the IDE
    public static void main(String[] args) {
        int[] arr = {135, 31, 11, 23, 613, 22, 5};

        Sorter mergeSorter = new MergeSort();
        Sorter bubbleSorter = new BubbleSort();
        Sorter quickSorter = new QuickSort();

        // Merge Sort
        System.out.println("Merge sorted: ");
        printArray(arr, mergeSorter);

        // Bubble Sort
        System.out.println("Bubble sorted: ");
        printArray(arr, bubbleSorter);

        // Quick Sort
        System.out.println("Quick sorted: ");
        printArray(arr, quickSorter);
    }

    private static void printArray(int[] arr, Sorter sorter) {

        // TODO: Find better way for calculating the time
        var start = System.nanoTime();
        var sortedArray = sorter.sort(arr);
        var end = System.nanoTime();
        var result = end - start;

        for (var i = 0; i < sortedArray.length; i++) {
            System.out.print(sortedArray[i] + " ");
        }

        System.out.println(String.format("[%s ns]", result));
    }
}
