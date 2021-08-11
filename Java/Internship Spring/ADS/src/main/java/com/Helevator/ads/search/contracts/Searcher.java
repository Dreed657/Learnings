package com.Helevator.ads.search.contracts;

public interface Searcher<T extends Comparable<T>> {
    boolean contains(T[] array, T element);
}