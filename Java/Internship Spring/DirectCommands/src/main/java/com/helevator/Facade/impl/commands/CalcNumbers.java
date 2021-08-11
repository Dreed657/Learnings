package com.helevator.Facade.impl.commands;

import com.helevator.Facade.api.Command;
import com.helevator.Facade.impl.storage.VariableRepository;

public class CalcNumbers extends Command<String> {
    private final String name = "Calc";
    private final String params = "<variable1> <variable2> <operation> <variable3>";
    private final String description = "Do a calculation with variables!";

    private final VariableRepository variableRepository;

    public CalcNumbers(VariableRepository repository) {
        this.variableRepository = repository;
        this.setName(this.name);
        this.setParams(this.params);
        this.setDescription(this.description);
    }

    @Override
    public String execute(String[] args) {
        return null;
    }
}
