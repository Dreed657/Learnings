package com.Helevator.ads.queues;

public interface ICustomQueue {
    void Add(int element);

    int Peek();

    int Poll();

    int Size();
}
