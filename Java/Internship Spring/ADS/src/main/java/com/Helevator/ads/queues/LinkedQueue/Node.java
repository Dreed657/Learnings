package com.Helevator.ads.queues.LinkedQueue;

public class Node {
    public int Data;
    Node Next;

    public Node() {
        this(0);
    }

    public Node(Integer data) {
        this.Data = data;
    }

    public Node(Integer data, Node next) {
        this.Data = data;
        this.Next = next;
    }
}
