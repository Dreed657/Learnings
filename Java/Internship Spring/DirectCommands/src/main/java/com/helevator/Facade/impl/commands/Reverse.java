package com.helevator.Facade.impl.commands;

import com.helevator.Facade.api.Command;

public class Reverse extends Command<String> {
    private final String name = "Reverse <words[]>";
    private final String params = "<words[]>";
    private final String description = "Reverses each word in the array!";

    public Reverse() {
        this.setName(this.name);
        this.setParams(this.params);
        this.setDescription(this.description);
    }

    @Override
    public String execute(String[] args) {
        var sb = new StringBuilder();

        for (String word : args) {
            sb.append(word.toCharArray()).append(" ");
        }

        return sb.reverse().toString().trim();
    }
}
