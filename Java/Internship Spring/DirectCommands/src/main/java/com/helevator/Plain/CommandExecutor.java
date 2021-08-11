package com.helevator.Plain;

public class CommandExecutor {
    public static void main(String[] args) {
        String command = args[0];
        String argument = args[1];

        System.out.println("Command: " + command);
        System.out.println("Argument: " + argument);

        switch (command) {
            case "reverse":
                printResult(reverseString(argument));
                break;
            case "count-words":
                printResult(countWords(argument).toString());
                break;
            case "reverse-words":
                printResult(reverseWords(argument));
                break;
            default:
                throw new IllegalArgumentException();
        }
    }

    private static String reverseString(String input) {
        var sb = new StringBuilder();

        sb.append(input.toCharArray());

        return sb.reverse().toString();
    }

    private static String reverseWords(String input) {
        var sb = new StringBuilder();
        var words = input.split(" ");

        for (String word : words) {
            sb.append(word).append(" ");
        }

        return sb.reverse().toString().trim();
    }

    private static Integer countWords(String input) {
        return input.split(" ").length;
    }

    private static void printResult(String input) {
        System.out.println(input);
    }
}
