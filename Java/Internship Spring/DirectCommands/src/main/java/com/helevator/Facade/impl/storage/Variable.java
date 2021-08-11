package com.helevator.Facade.impl.storage;

import java.util.Locale;

public class Variable<T> {
    private final T value;

    public Variable(T value) {
        this.value = value;
    }

    public T getValue() {
        return this.value;
    }

    public String getType() {
        return this.value.getClass().getSimpleName();
    }

    @Override
    public String toString() {
        return String.format("[%s] %s", this.value.getClass().getSimpleName().toLowerCase(Locale.ROOT), this.value);
    }
}
