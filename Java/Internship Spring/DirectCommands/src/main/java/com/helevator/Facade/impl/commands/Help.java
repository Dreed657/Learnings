package com.helevator.Facade.impl.commands;

import com.helevator.Facade.api.Command;
import com.helevator.Facade.api.Executable;
import com.helevator.Facade.api.storage.Repository;

public class Help extends Command<String> {
    private final String name = "Help";
    private final String description = "Show info about all registered commands!";

    private final Repository<String, Executable> repository;

    public Help(Repository<String, Executable> repository) {
        this.repository = repository;
        this.setName(this.name);
        this.setDescription(this.description);
    }

    @Override
    public String execute(String[] args) {
        var sb = new StringBuilder();
        var commands = this.repository.getAll();

        for (Executable executable : commands) {
            sb.append(executable.getInfo()).append("\n");
        }

        return sb.toString().trim();
    }
}
