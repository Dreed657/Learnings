package com.Helevator.ads.treeTraversal;

import java.util.*;

public abstract class GraphTest {
    public static Map<String, List<String>> createGraph() {
        Map<String, List<String>> graph = new HashMap<>();

        graph.put("A", Arrays.asList("B", "C"));
        graph.put("B", Collections.singletonList("E"));
        graph.put("C", Collections.singletonList("B"));
        graph.put("D", Arrays.asList("C", "E", "F"));
        graph.put("E", Collections.singletonList("G"));
        graph.put("F", Collections.singletonList("G"));

        return graph;
    }
}
