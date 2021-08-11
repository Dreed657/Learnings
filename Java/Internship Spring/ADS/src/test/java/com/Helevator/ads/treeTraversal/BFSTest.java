package com.Helevator.ads.treeTraversal;

import org.junit.jupiter.api.Assertions;
import org.junit.jupiter.api.Test;

import java.util.List;
import java.util.Map;

import static com.Helevator.ads.treeTraversal.GraphTest.createGraph;

public class BFSTest {

    @Test
    void testTraverseShouldReturnBFSOrderNodes() {
        Map<String, List<String>> graph = createGraph();
        BFS<String> bfs = new BFS<>(graph);
        StringBuilder sb = new StringBuilder();

        bfs.traverse("A", sb::append);

        Assertions.assertEquals("ABCEG", sb.toString());
    }
}
