package com.Helevator.ads.queues.ArrayListQueue;

import org.junit.jupiter.api.*;

public class CustomArrayListArrayListQueueTest {
    private CustomArrayListArrayListQueue queue;

    @BeforeEach
    public void setUp() throws Exception {
        this.queue = new CustomArrayListArrayListQueue();
    }

    @AfterEach
    public void tearDown() {
        this.queue = null;
    }

    @Test
    void testAddShouldIncreaseSize() {
        this.queue.Add(1);
        this.queue.Add(2);
        this.queue.Add(3);

        var sizeBefore = this.queue.Size();

        this.queue.Add(4);
        var got = this.queue.Size();
        var want = 4;

        Assertions.assertEquals(got, want,"Size of the queue wasn't increased");
        Assertions.assertNotEquals(got, sizeBefore, "Size of the queue wasn't increased");
    }

    @Test
    void testPollShouldRemoveAndReturnFirst() {
        this.queue.Add(1);
        this.queue.Add(2);
        this.queue.Add(3);

        var sizeBefore = this.queue.Size();

        var got = this.queue.Poll();
        var want = 1;

        var sizeAfter = this.queue.Size();

        Assertions.assertEquals(got, want, "Should return first item, but it didn't");
        Assertions.assertNotEquals(sizeBefore, sizeAfter, "Queue should have decreased in value");
    }

    @Test
    void testPollShouldReturnZeroIfQueueIsEmpty() {
        var got = this.queue.Poll();
        var want = 0;

        Assertions.assertEquals(got, want, "Should return 0, when empty");
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
    void testSizeShouldReturnCorrectly() {
        //Arrange
        this.queue.Add(2);
        this.queue.Add(2);
        this.queue.Add(2);

        //Act
        var got = this.queue.Size();
        var want = 3;

        // Assert
        Assertions.assertEquals(got, want, "Size not returning correctly");
    }
}
