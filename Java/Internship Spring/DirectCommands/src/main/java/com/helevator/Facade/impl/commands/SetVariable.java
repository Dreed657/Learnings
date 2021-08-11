package com.helevator.Facade.impl.commands;

import com.helevator.Facade.api.Command;
import com.helevator.Facade.api.storage.Repository;
import com.helevator.Facade.impl.factory.VariableFactory;

public class SetVariable extends Command<String> {
    private final String name = "Set";
    private final String params = "<name> <type> <value>";
    private final String description = "Sets variable into the registry!";

    private final Repository variableRepository;

    public SetVariable(Repository repository) {
        this.variableRepository = repository;
        this.setName(this.name);
        this.setParams(this.params);
        this.setDescription(this.description);
    }

    @Override
    public String execute(String[] args) {
        var name = args[0];
        var type = args[1];
        var value = args[2];

        var variable = VariableFactory.create(type, value);
        this.variableRepository.add(name, variable);

        return "Ok";
    }
}
