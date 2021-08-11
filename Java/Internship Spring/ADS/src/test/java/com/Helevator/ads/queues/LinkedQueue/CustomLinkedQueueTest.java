package com.Helevator.ads.queues.LinkedQueue;

import org.junit.jupiter.api.*;

public class CustomLinkedQueueTest {
    private CustomLinkedQueue queue;

    @BeforeEach
    public void setUp() throws Exception {
        this.queue = new CustomLinkedQueue();
    }

    @AfterEach
    public void tearDown() {
        this.queue = null;
    }

    @Test
    void testAddShouldWorkCorrectly() {
        this.queue.Add(123);
        this.queue.Add(213);
        this.queue.Add(143);

        // Check if added successfully at first position
        var gotFromPeek = this.queue.Peek();
        var wantFromPeek = 123;

        var gotFromPoll = this.queue.Poll();
        var wantFromPoll = 123;

        Assertions.assertEquals(gotFromPeek, wantFromPeek, "Should return the element in first position with peak");
        Assertions.assertEquals(gotFromPoll, wantFromPoll, "Should return the element in first position with poll");
    }

    @Test
    void testAddShouldIncreaseSize() {
        this.queue.Add(123);
        this.queue.Add(51);
        this.queue.Add(15);

        var sizeBefore = this.queue.Size();

        this.queue.Add(1);

        var sizeAfter = this.queue.Size();

        Assertions.assertNotEquals(sizeBefore, sizeAfter, "Add should increase queue size by 1");
    }

    @Test
    void testPollShouldWorkCorrectly() {
        this.queue.Add(1);
        this.queue.Add(2);
        this.queue.Add(3);

        var got = this.queue.Poll();
        var want = 1;

        Assertions.assertEquals(got, want, "Should return first value");
    }

    @Test
    void testPollShouldDecreaseSize() {
        this.queue.Add(1);
        this.queue.Add(2);
        this.queue.Add(3);

        var sizeBefore = this.queue.Size();

        var got = this.queue.Poll();
        var want = 1;

        var sizeAfter = this.queue.Size();

        Assertions.assertEquals(got, want, "Should return first value");
        Assertions.assertNotEquals(sizeBefore, sizeAfter, "Size should decrease after poll");
    }

    // This test is a bit pointless, because current
    // queue interface encapsulates direct access to front
    // node to check if it is back to null
    @Test
    void testPollAfterPollLastElementSizeShouldBeZero() {
        this.queue.Add(1);

        var sizeBefore = this.queue.Size();
        this.queue.Poll();
        var sizeAfter = this.queue.Size();

        Assertions.assertNotEquals(sizeBefore, sizeAfter, "Size should decrease after poll last element");
    }

    @Test
    void testPollShouldReturnZeroIfQueueIsEmpty() {
        var got = this.queue.Poll();
        var want = 0;

        Assertions.assertEquals(got, want, "Should return zero when queue is empty!");
    }

    @Test
    void testPeekShouldReturnFirst()
    {
        this.queue.Add(1);
        this.queue.Add(2);
        this.queue.Add(3);

        var got = this.queue.Peek();
        var want = 1;

        Assertions.assertEquals(got, want, "Peek didn't return correctly");
    }

    @Test
    void testPeekShouldReturnZeroIfQueueIsEmpty()
    {
        var got = this.queue.Peek();
        var want = 0;

        Assertions.assertEquals(got, want, "Peek didn't return correctly");
    }

    @Test
    void testSizeShouldReturnCorrectly() {
        this.queue.Add(2);

        var got = this.queue.Size();
        var want = 1;

        Assertions.assertEquals(got, want, "Size not returning correctly");
    }
}
