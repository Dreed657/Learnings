package com.Helevator.ads.search;


import com.Helevator.ads.search.contracts.Searcher;

public class BinarySearch<T extends Comparable<T>>  implements Searcher<T> {

    @Override
    public boolean contains(T[] array, T element) {
        if (array == null) {
            throw new NullPointerException();
        }

        return search(array, element, 0, array.length - 1);
    }

    private boolean search(T[] arr, T element, int left, int right) {
        if (right <= left) {
            return arr[left].equals(element);
        }

        int mid = left + (right - left) / 2;

        if (arr[mid].equals(element)) {
            return true;
        }

        if (element.compareTo(arr[mid]) < 0) {
            return search(arr, element, left, mid - 1);
        } else {
            return search(arr, element, mid + 1, right);
        }
    }
}
