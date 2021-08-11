package com.Helevator.ads.trees.contracts;

import java.util.List;

public interface Tree<T> {
    T getValue();

    List<Tree<T>> getChildren();

    void add(T element);
}
