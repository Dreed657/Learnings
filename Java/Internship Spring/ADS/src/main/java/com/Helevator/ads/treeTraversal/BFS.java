package com.Helevator.ads.treeTraversal;

import com.Helevator.ads.trees.BinarySearchTreeImpl;

import java.util.*;
import java.util.function.Consumer;

public class BFS<T> {
    private final Map<T, List<T>> adjacencyList;

    public BFS(Map<T, List<T>> adjacencyList) {
        this.adjacencyList = adjacencyList;
    }

    public void traverse(T root, Consumer<T> consumer) {
        var visited = new HashSet<T>();

        var queue = new LinkedList<T>();
        queue.add(root);

        while (!queue.isEmpty()) {
            var temp = queue.poll();
            consumer.accept(temp);

            visited.add(temp);

            var adjacentVertices = adjacencyList.getOrDefault(temp, Collections.emptyList());
            for (T adjacent : adjacentVertices) {
                if (!visited.contains(adjacent)) {
                    queue.add(adjacent);
                }
            }
        }
    }
}
