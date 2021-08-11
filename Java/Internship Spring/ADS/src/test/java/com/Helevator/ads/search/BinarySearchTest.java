package com.Helevator.ads.search;

import com.Helevator.ads.search.contracts.Searcher;
import org.junit.jupiter.api.AfterAll;
import org.junit.jupiter.api.AfterEach;
import org.junit.jupiter.api.BeforeEach;

class BinarySearchTest extends AbstractSearchingTests {
    @BeforeEach
    public void beforeEach() {
        this.searcher = new BinarySearch<>();
    }

    @AfterEach
    public void tearDown() {
        this.searcher = null;
    }
}