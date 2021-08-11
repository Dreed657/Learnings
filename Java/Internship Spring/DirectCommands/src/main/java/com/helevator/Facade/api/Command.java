package com.helevator.Facade.api;

public abstract class Command<T> implements Executable<T> {
    protected String name;
    protected String description;
    protected String params;

    public String getName() {
        return this.name;
    }

    protected void setName(String name) {
        this.name = name;
    }

    public String getDescription() {
        return this.description;
    }

    protected void setDescription(String description) {
        this.description = description;
    }

    public String getParams() {
        return this.params;
    }

    protected void setParams(String params) {
        this.params = params;
    }

    @Override
    public String getInfo() {
        return String.format("%s %s - %s", this.name, this.params, this.description);
    }
}
