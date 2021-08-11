package com.helevator.Facade.impl.IO;

import com.helevator.Facade.api.IO.Writer;

public class ConsoleWriterImpl implements Writer {
    @Override
    public void write(String input) {
        System.out.println(input);
    }
}
