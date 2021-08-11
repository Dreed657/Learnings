package com.helevator.Facade.impl.IO;

import com.helevator.Facade.api.IO.Reader;

import java.util.Scanner;

public class ConsoleReaderImpl implements Reader {
    private final Scanner scanner;

    public ConsoleReaderImpl() {
        this.scanner = new Scanner(System.in);
    }

    @Override
    public String read() {
        return this.scanner.nextLine();
    }
}
