package com.Helevator.oop.CompanyStruct;

import java.util.stream.Collectors;

public interface Visitor {
    String visit(Intern intern);
    String visit(Engineer engineer);
    String visit(Manager manager);
}

class JsonExporterVisitor implements  Visitor {

    @Override
    public String visit(Intern intern) {
        return String.format("{ 'name': %s, 'position': %s }", intern.name(), intern.position());
    }

    @Override
    public String visit(Engineer engineer) {
        return String.format("{ 'name': %s, 'position': %s }", engineer.name(), engineer.position());
    }

    @Override
    public String visit(Manager manager) {
        var directReports = manager
                                            .directReports
                                            .stream()
                                            .map(e -> e.accept(this))
                                            .collect(Collectors.joining(","));

        return String.format("{ 'name': %s, 'position': %s, 'directReports': [ %s ] }", manager.name(), manager.position(), directReports);
    }
}
