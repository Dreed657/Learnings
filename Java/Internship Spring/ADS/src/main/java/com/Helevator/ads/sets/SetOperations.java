package com.Helevator.ads.sets;

import java.util.Set;

public interface SetOperations<E> {
    Set<E> getUnion(Set<E> s1, Set<E> s2);

    Set<E> getIntersection(Set<E> s1, Set<E> s2);

    Set<E> getSymmetricalDifference(Set<E> s1, Set<E> s2);
}
