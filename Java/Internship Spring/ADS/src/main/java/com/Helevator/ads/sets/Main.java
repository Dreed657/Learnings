package com.Helevator.ads.sets;

import java.util.HashSet;

public class Main {
    public static void main(String[] args) {
        var s1 = new HashSet<Integer>();
        s1.add(1);
        s1.add(2);
        s1.add(3);
        s1.add(4);
        s1.add(5);

        var s2 = new HashSet<Integer>();
        s2.add(3);
        s2.add(5);

        System.out.println(String.format("Set 1: %s", s1));
        System.out.println(String.format("Set 2: %s", s2));

        var Operations = new Operators<Integer>();

        var union = Operations.getUnion(s1, s2);
        var interception = Operations.getIntersection(s1, s2);
        var symmetricalDiff = Operations.getSymmetricalDifference(s1, s2);

        System.out.println(String.format("Union: %s", union));
        System.out.println(String.format("Interception: %s", interception));
        System.out.println(String.format("Symmetrical Difference: %s", symmetricalDiff));
    }
}
