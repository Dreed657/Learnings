package com.Helevator.ads.queues.ArrayListQueue;

import com.Helevator.ads.queues.ICustomQueue;

import java.util.ArrayList;

public class CustomArrayListArrayListQueue implements ICustomQueue {
    private ArrayList<Integer> _queue;

    public CustomArrayListArrayListQueue() {
        this._queue = new ArrayList<Integer>();
    }

    @Override
    public void Add(int element) {
        this._queue.add(element);
    }

    @Override
    public int Peek() {
        return this._queue.get(0);
    }

    @Override
    public int Poll() {
        if (this._queue.size() == 0) {
            return 0;
        }

        return this._queue.remove(0);
    }

    @Override
    public int Size() {
        return this._queue.size();
    }
}
