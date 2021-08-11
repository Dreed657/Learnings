package com.helevator.Facade.impl.commands;

import com.helevator.Facade.api.Command;

public class CountWords extends Command<Integer> {
    private final String name = "Count-words";
    private final String params = "<words[]>";
    private final String description = "Counts words in array!";

    public CountWords() {
        this.setName(this.name);
        this.setParams(this.params);
        this.setDescription(this.description);
    }

    @Override
    public Integer execute(String[] args) {
        return args.length;
    }
}
