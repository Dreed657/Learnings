package com.helevator.Facade.impl.commands;

import com.helevator.Facade.api.Command;

public class ReverseWords extends Command<String> {
    private final String name = "Reverse-Words <words[]>";
    private final String description = "Reverses array of words!";

    public ReverseWords() {
        this.setName(this.name);
        this.setDescription(this.description);
    }

    @Override
    public String execute(String[] args) {
        StringBuilder sb = new StringBuilder();

        for (String word : args) {
            sb.append(word).append(" ");
        }

        return sb.reverse().toString().trim();
    }
}
