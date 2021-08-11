package com.Helevator.ads.sets;


import org.junit.jupiter.api.*;
import org.junit.jupiter.api.Assertions;

import java.util.HashSet;
import java.util.Set;

public class OperatorsTests {
    private Operators<Integer> operators;
    private final Set<Integer> s1;
    private final Set<Integer> s2;

    public OperatorsTests() {
        this.s1 = new HashSet<Integer>();
        s1.add(1);
        s1.add(2);
        s1.add(3);
        s1.add(4);
        s1.add(5);

        this.s2 = new HashSet<Integer>();
        s2.add(3);
        s2.add(5);
    }

    @BeforeEach
    public void setUp() throws Exception {
        this.operators = new Operators<Integer>();
    }

    @AfterEach
    public void tearDown() {
        this.operators = null;
    }

    @Test
    void testGetUnion() {
        var got = this.operators.getUnion(this.s1, this.s2);

        var want = new HashSet<Integer>();
        want.add(1);
        want.add(2);
        want.add(3);
        want.add(4);
        want.add(5);

        Assertions.assertEquals(got, want, "getUnion should return correctly");
    }

    @Test
    void testGetIntersection() {
        var got = this.operators.getIntersection(this.s1, this.s2);
        var want = new HashSet<Integer>();
        want.add(3);
        want.add(5);

        Assertions.assertEquals(got, want, "getIntersection should return correctly");
    }

    @Test
    void testGetSymmetricalDifference() {
        var got = this.operators.getSymmetricalDifference(this.s1, this.s2);
        var want = new HashSet<Integer>();
        want.add(1);
        want.add(2);
        want.add(4);

        Assertions.assertEquals(got, want, "getSymmetricalDifference should return correctly");
    }
}
