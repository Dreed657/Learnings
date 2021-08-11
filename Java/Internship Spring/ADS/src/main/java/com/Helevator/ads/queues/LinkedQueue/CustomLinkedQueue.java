package com.Helevator.ads.queues.LinkedQueue;

import com.Helevator.ads.queues.ICustomQueue;

public class CustomLinkedQueue implements ICustomQueue {
    private Node front;

    private int size;

    // Should this constructor put new nodes
    // with default value of 0 or leave them as nulls?
    public CustomLinkedQueue() {
        this.front = null;
    }

    @Override
    public void Add(int element) {
        if (this.isEmpty()) {
            // TODO: Init in constructor?
            this.front = new Node(element);
            this.front.Next = new Node(element);
        } else {
            this.front.Next = new Node(element);
        }

        this.size++;
    }

    @Override
    public int Peek() {
        if (this.front == null) {
            return 0;
        }

        return this.front.Data;
    }

    @Override
    public int Poll() {
        if (this.front == null) {
            return 0;
        } else if (this.Size() == 1) {
            var tmp = this.front.Data;
            this.front = null;
            this.size--;

            return tmp;
        } else {
            var tmp = this.front;
            this.front = this.front.Next;
            this.size--;

            return tmp.Data;
        }
    }

    @Override
    public int Size() {
        return this.size;
    }

    private boolean isEmpty() {
        if (this.front == null && this.size == 0) {
            return true;
        } else {
            return false;
        }
    }

    // Took more descriptive approach
    // private boolean isEmpty() { return this.front == null;}
}
