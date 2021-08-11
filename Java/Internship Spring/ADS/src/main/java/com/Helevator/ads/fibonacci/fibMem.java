package com.Helevator.ads.fibonacci;

import java.util.*;

public class fibMem {
    private final Map<Integer, Integer> _meme;

    public fibMem() {
        this._meme = new HashMap<>();
    }

    public int getFibonacci(int n) {
        if (n <= 1) {
            return n;
        }

        if (this._meme.containsKey(n)) {
            return this._meme.get(n);
        }

        int value = getFibonacci(n - 1) + getFibonacci(n - 2);
        this._meme.put(n, value);

        return value;
    }
}
