package com.Helevator.ads.treeTraversal;

import java.util.*;
import java.util.function.Consumer;

public class DFS<T> {
    private final Map<T, List<T>> adjacencyList;

    public DFS(Map<T, List<T>> adjacencyList) {
        this.adjacencyList = adjacencyList;
    }

    public void traverse(T start, Consumer<T> consumer) {
        DFSTraversal(start, consumer, new HashSet<>());
    }

    private void DFSTraversal(T start, Consumer<T> consumer, Set<T> visited) {
        visited.add(start);

        List<T> adjacentVertices = adjacencyList.getOrDefault(start, Collections.emptyList());
        for (T adjacent : adjacentVertices) {
            if (!visited.contains(adjacent)) {
                DFSTraversal(adjacent, consumer, visited);
            }
        }

        consumer.accept(start);
    }
}
