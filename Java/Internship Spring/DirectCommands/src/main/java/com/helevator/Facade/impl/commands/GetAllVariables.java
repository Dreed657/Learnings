package com.helevator.Facade.impl.commands;

import com.helevator.Facade.api.Command;
import com.helevator.Facade.api.storage.Repository;
import com.helevator.Facade.impl.storage.Variable;

public class GetAllVariables extends Command<String> {
    private final String name = "GetAll";
    private final String description = "Returns all registered commands in registry!";

    private final Repository<String, Variable> variableRepository;

    public GetAllVariables(Repository repository) {
        this.variableRepository = repository;
        this.setName(this.name);
        this.setDescription(this.description);
    }

    @Override
    public String execute(String[] args) {
        var sb = new StringBuilder();
        var variables = this.variableRepository.getAll();

        if (variables.size() == 0) {
            throw new NullPointerException("No variables stored");
        } else {
            for (Variable variable : variables) {
                sb.append(variable.toString()).append("\n");
            }
        }

        return sb.toString();
    }
}
