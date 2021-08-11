package com.helecloud.Structural;

public class App {
    public static void main(String[] args) {
        var inputFile = "/home/dreed657/dev/helevator_2021/Stoyan/Patterns/src/main/java/com/helecloud/Structural/input.txt";
        var outputFile = "/home/dreed657/dev/helevator_2021/Stoyan/Patterns/src/main/java/com/helecloud/Structural/output.txt";

        var builder = new IOBuilder();
        var IO = builder.buildFileIO(inputFile, outputFile);

        var input = IO.read();
        IO.write(input);
    }
}
