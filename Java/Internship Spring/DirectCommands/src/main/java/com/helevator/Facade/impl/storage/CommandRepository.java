package com.helevator.Facade.impl.storage;

import com.helevator.Facade.api.Executable;
import com.helevator.Facade.api.storage.Repository;

import java.util.Collection;
import java.util.HashMap;
import java.util.Locale;
import java.util.Map;

public class CommandRepository implements Repository<String, Executable> {

    private final Map<String, Executable> Commands;

    public CommandRepository() {
        this.Commands = new HashMap<>();
    }

    @Override
    public Collection<Executable> getAll() {
        return this.Commands.values();
    }

    @Override
    public Executable getByName(String name) {
        var command = this.Commands.get(name.toLowerCase(Locale.ROOT));

        if (command == null) {
            throw new IllegalArgumentException("Command not found!");
        }

        return command;
    }

    @Override
    public Executable add(String name, Executable value) {
        if (value == null) {
            throw new IllegalArgumentException("Invalid command!");
        }

        if (this.Commands.get(name) != null) {
            throw new IllegalArgumentException(String.format("Command '%s' already exists!", name));
        }

        return this.Commands.put(name.toLowerCase(Locale.ROOT), value);
    }

    @Override
    public boolean remove(String name) {
        if (this.Commands.get(name) == null) {
            throw new IllegalArgumentException("Command not found!");
        }

        this.Commands.remove(name);

        return true;
    }
}
