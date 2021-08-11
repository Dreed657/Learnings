package com.Helevator.ads.fibonacci;

public class fibRec {
    public int getFibonacci(int n) {
        if (n <= 1) {
            return n;
        }

        return getFibonacci(n - 1) + getFibonacci(n - 2);
    }
}
