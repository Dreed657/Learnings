package com.helevator.Facade.impl.storage;

import com.helevator.Facade.api.storage.Repository;

import java.util.Collection;
import java.util.HashMap;
import java.util.Map;

public class VariableRepository implements Repository<String, Variable> {
    private final Map<String, Variable> Variables;

    public VariableRepository() {
        this.Variables = new HashMap<>();
    }

    @Override
    public Collection<Variable> getAll() {
        return this.Variables.values();
    }

    @Override
    public Variable getByName(String name) {
        var variable = this.Variables.get(name);

        if (variable == null) {
            throw new IllegalArgumentException(String.format("Variable with name: '%s' not found!", name));
        }

        return variable;
    }

    @Override
    public Variable add(String name, Variable value) {
        if (value == null) {
            throw new IllegalArgumentException("Invalid variable!");
        }

        if (this.Variables.get(name) != null) {
            throw new IllegalArgumentException(String.format("Variable with name: '%s' already exists!", name));
        }

        return this.Variables.put(name, value);
    }

    @Override
    public boolean remove(String name) {
        if (this.Variables.get(name) == null) {
            throw new IllegalArgumentException("Variable not found!");
        }

        this.Variables.remove(name);

        return true;
    }
}
