package com.Helevator.ads.sets;

import java.util.HashSet;
import java.util.Set;

public class Operators<E> implements SetOperations<E> {
    @Override
    public Set<E> getUnion(Set<E> s1, Set<E> s2) {
        var tmp = new HashSet<E>(s1);
        tmp.addAll(s2);

        return s1;
    }

    @Override
    public Set<E> getIntersection(Set<E> s1, Set<E> s2) {
        var tmp = new HashSet<E>(s1);
        tmp.retainAll(s2);

        return tmp;
    }

    @Override
    public Set<E> getSymmetricalDifference(Set<E> s1, Set<E> s2) {
        var symmetricDiff = new HashSet<E>(s1);
        symmetricDiff.addAll(s2);

        var tmp = new HashSet<E>(s1);
        tmp.retainAll(s2);
        symmetricDiff.removeAll(tmp);

        return symmetricDiff;
    }
}
