package com.Helevator.ads.trees;

import org.junit.jupiter.api.*;

public class BinarySearchTreeTests {

    @Test
    public void testAddInTree() {
        var tree = createBinarySearchTree();

        Assertions.assertEquals(13, tree.getLeft().getValue());
        Assertions.assertEquals(30, tree.getRight().getValue());
        Assertions.assertEquals(2, tree.getLeft().getLeft().getValue());
        Assertions.assertEquals(15, tree.getLeft().getRight().getValue());
        Assertions.assertEquals(7, tree.getLeft().getLeft().getRight().getValue());
        Assertions.assertEquals(27, tree.getRight().getLeft().getValue());
        Assertions.assertEquals(34, tree.getRight().getRight().getValue());
    }

    @Test
    public void testContainsShouldReturnTrueIfFound() {
        var tree = createBinarySearchTree();
        var actual = tree.contains(7);

        Assertions.assertTrue(actual);
    }

    @Test
    public void testContainsShouldReturnFalseIfNotFound() {
        var tree = createBinarySearchTree();
        var actual = tree.contains(50);

        Assertions.assertFalse(actual);
    }

    private static BinarySearchTreeImpl<Integer> createBinarySearchTree() {
        var tree = new BinarySearchTreeImpl<>(22);

        int[] values = {13, 30, 2, 7, 15, 27, 34};
        for (int value : values) {
            tree.add(value);
        }

        return tree;
    }
}
