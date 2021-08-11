package com.Helevator.ads.trees;

import com.Helevator.ads.trees.contracts.BinarySearchTree;
import com.Helevator.ads.trees.contracts.Tree;

import java.util.ArrayList;
import java.util.List;

public class BinarySearchTreeImpl<T extends Comparable<T>> implements BinarySearchTree<T> {
    private final T value;
    private BinarySearchTree<T> left;
    private BinarySearchTree<T> right;

    public BinarySearchTreeImpl(T value) {
        this.value = value;
    }

    @Override
    public T getValue() {
        return value;
    }

    @Override
    public List<Tree<T>> getChildren() {
        var children = new ArrayList<Tree<T>>();

        if (left != null) {
            children.add(left);
        }
        if (right != null) {
            children.add(right);
        }

        return children;
    }

    @Override
    public BinarySearchTree<T> getLeft() {
        return left;
    }

    @Override
    public BinarySearchTree<T> getRight() {
        return right;
    }

    @Override
    public boolean contains(T element) {
        if(element.compareTo(value) == 0){
            return true;
        }

        if(element.compareTo(value) < 0 ){
            return left != null && left.contains(element);
        } else if(element.compareTo(value) >= 0 ){
            return right != null && right.contains(element);
        }

        return false;
    }

    @Override
    public void add(T element) {
        if (element.compareTo(value) < 0) {
            if (getLeft() == null) {
                this.left = new BinarySearchTreeImpl<>(element);
            } else {
                getLeft().add(element);
            }
        } else if (element.compareTo(value) >= 0) {
            if (getRight() == null) {
                this.right = new BinarySearchTreeImpl<>(element);
            } else {
                getRight().add(element);
            }
        }
    }
}
