package com.helevator.Facade.api;

public interface Executable<T> {
    T execute(String[] args);
    String getInfo();
}
