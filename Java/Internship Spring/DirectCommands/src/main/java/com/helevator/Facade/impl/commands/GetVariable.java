package com.helevator.Facade.impl.commands;

import com.helevator.Facade.api.Command;
import com.helevator.Facade.api.storage.Repository;
import com.helevator.Facade.impl.storage.Variable;
import com.helevator.Facade.impl.storage.VariableRepository;

public class GetVariable extends Command<String> {
    private final String name = "Get";
    private final String params = "<name>";
    private final String description = "Gets an variable for registry!";

    private final Repository<String, Variable> variableRepository;

    public GetVariable(Repository repository) {
        this.variableRepository = repository;
        this.setName(this.name);
        this.setParams(this.params);
        this.setDescription(this.description);
    }

    @Override
    public String execute(String[] args) {
        var name = args[0];

        var variable = this.variableRepository.getByName(name);

        return variable.toString();
    }
}
