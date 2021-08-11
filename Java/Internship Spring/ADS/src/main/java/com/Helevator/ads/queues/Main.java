package com.Helevator.ads.queues;

import com.Helevator.ads.queues.LinkedQueue.CustomLinkedQueue;

public class Main {
    public static void main(String[] args) {
        var CustomQueue = new CustomLinkedQueue();

        System.out.println("Adding 1, 2, 3");
        CustomQueue.Add(1);
        CustomQueue.Add(2);
        CustomQueue.Add(3);

        System.out.println(String.format("Total size: %s", CustomQueue.Size()));

        System.out.println("Removing 1, 2, 3");
        CustomQueue.Poll();
        CustomQueue.Poll();
        CustomQueue.Poll();

        System.out.println(String.format("Total size: %s", CustomQueue.Size()));

        System.out.println("Should return 0 (if empty)");
        System.out.println(CustomQueue.Poll());
    }
}
