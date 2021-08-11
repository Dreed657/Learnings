package com.helecloud.Structural;

import java.util.Scanner;

public class ConsoleIO implements IO {
    private final Scanner _scanner = new Scanner(System.in);

    @Override
    public String read() {
        return this._scanner.nextLine();
    }

    @Override
    public void write(String output) {
        System.out.println(output);
    }
}
