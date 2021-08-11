package com.helevator.Facade;

import com.helevator.Facade.api.Engine;
import com.helevator.Facade.api.IO.Reader;
import com.helevator.Facade.api.IO.Writer;
import com.helevator.Facade.impl.EngineImpl;
import com.helevator.Facade.impl.IO.ConsoleReaderImpl;
import com.helevator.Facade.impl.IO.ConsoleWriterImpl;
import com.helevator.Facade.impl.IO.FileReaderImpl;

public class App {
    public static void main(String[] args) {
        final String filePath = "/home/dreed657/dev/helevator_2021/Stoyan/DirectCommands/src/main/java/com/helevator/Facade/input.txt";

        Reader reader = new FileReaderImpl(filePath);

//        Reader reader = new ConsoleReaderImpl();
        Writer writer = new ConsoleWriterImpl();

        Engine Engine = new EngineImpl(reader, writer);
        Engine.Run();
    }
}
