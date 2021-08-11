package com.helevator.Facade.api.storage;

import java.util.Collection;

public interface Repository<K, V> {
    Collection<V> getAll();
    V getByName(K name);
    V add(K name, V value);
    boolean remove(K name);
}
