package com.Helevator.ads.search;

public class Main {
    public static void main(String[] args) {
        Integer[] arr = { 2, 3, 4, 10, 40 };
        var element = 10;

        var searcher = new BinarySearch<Integer>();

        var result = searcher.contains(arr, element);

        System.out.println("Result: " + result);
    }
}
