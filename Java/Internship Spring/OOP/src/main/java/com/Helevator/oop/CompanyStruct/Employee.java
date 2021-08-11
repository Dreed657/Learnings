package com.Helevator.oop.CompanyStruct;


import java.util.List;

public abstract class Employee {

    private String name;

    public Employee(String name) {
        this.name = name;
    }

    final String name() {
        return name;
    }

    abstract String position();

    abstract String accept(Visitor v);

    public static void main(String[] args) {
        Intern intern = new Intern("Ivan");
        Intern intern2 = new Intern("Ivan2");
        Intern intern3 = new Intern("Ivan3");
        Engineer engineer = new Engineer("Pesho");
        Manager manager = new Manager("Stoyan", List.of(engineer, intern, intern2, intern3));
        var json = new JsonExporterVisitor().visit(manager);
        System.out.println(json);
    }

    public static void printReportingStructure(Manager e) {
        System.out.println("{");
        System.out.println(formatAsFakeJson(e.position(), e.name()));
        System.out.println("\t[");
        for (Employee employee : e.directReports) {
            System.out.println("\t" + formatAsFakeJson(employee.position(), employee.name()));
        }
        System.out.println("\t]");
        System.out.println("}");
    }

    private static String formatAsFakeJson(String key, String value){
        return String.format("\t{ \'%s\' : \'%s\' },", key, value);
    }
}



class Intern extends Employee {

    public Intern(String name) {
        super(name);
    }

    @Override
    String position() {
        return "Intern";
    }

    @Override
    String accept(Visitor v) {
        return v.visit(this);
    }
}

class Engineer extends Employee {

    public Engineer(String name) {
        super(name);
    }

    @Override
    String position() {
        return "Engineer";
    }

    @Override
    String accept(Visitor v) {
        return v.visit(this);
    }
}

class Manager extends Employee {

    List<Employee> directReports;

    public Manager(String name, List<Employee> directReports) {
        super(name);
        this.directReports = directReports;
    }

    @Override
    String position() {
        return "Manager";
    }

    @Override
    String accept(Visitor v) {
        return v.visit(this);
    }
}

