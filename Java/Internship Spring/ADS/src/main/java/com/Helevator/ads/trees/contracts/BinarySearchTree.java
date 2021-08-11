package com.Helevator.ads.trees.contracts;

public interface BinarySearchTree<T extends Comparable<T>> extends Tree<T> {
    // root
    T getValue();

    // get the left sub-tree
    BinarySearchTree<T> getLeft();

    // get the right sub-tree
    BinarySearchTree<T> getRight();

    // check if the tree contains the element
    boolean contains(T element);
}
