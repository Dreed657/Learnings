package com.Helevator.ads.treeTraversal;

import org.junit.jupiter.api.Assertions;
import org.junit.jupiter.api.Test;

import java.util.List;
import java.util.Map;

import static com.Helevator.ads.treeTraversal.GraphTest.createGraph;

public class DFSTest {
    @Test
    public void testTraverseShouldReturnDFSOrderNodes() {
        Map<String, List<String>> graph = createGraph();
        DFS<String> dfs = new DFS<>(graph);
        StringBuilder sb = new StringBuilder();

        dfs.traverse("A", sb::append);

        Assertions.assertEquals("GEBCA", sb.toString());
    }
}
