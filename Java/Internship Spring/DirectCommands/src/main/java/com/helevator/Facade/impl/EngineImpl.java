package com.helevator.Facade.impl;

import com.helevator.Facade.api.Engine;
import com.helevator.Facade.api.IO.Reader;
import com.helevator.Facade.api.IO.Writer;
import com.helevator.Facade.impl.commands.*;
import com.helevator.Facade.impl.storage.CommandRepository;
import com.helevator.Facade.impl.storage.VariableRepository;

import java.util.Arrays;
import java.util.Locale;

public class EngineImpl implements Engine {
  private final Reader input;
  private final Writer output;

  private final CommandRepository Commands;
  private final VariableRepository Variables;

  public EngineImpl(Reader input, Writer output) {
    this.input = input;
    this.output = output;

    this.Commands = new CommandRepository();
    this.Variables = new VariableRepository();

    this.registerCommands();
  }

  @Override
  public void Run() {
    this.output.write("Type help to see all available commands!");
    this.output.write("Enter an command:");
    var commandInput = this.input.read();

    while (!commandInput.toLowerCase(Locale.ROOT).equals("exit")) {
      var args = commandInput.split(" ");

      var name = args[0].trim();
      var comArgs = args.length > 1 ? Arrays.copyOfRange(args, 1, args.length) : new String[] {};

      try {
        var command = this.Commands.getByName(name);
        var result = command.execute(comArgs);
        this.output.write(result.toString());
      } catch (IllegalArgumentException e) {
        this.output.write(e.getMessage());
      } catch (Exception e) {
        e.getStackTrace();
      }

      commandInput = this.input.read();
    }
  }

  private void registerCommands() {
    this.Commands.add("reverse", new Reverse());
    this.Commands.add("reverse-words", new ReverseWords());
    this.Commands.add("count-words", new CountWords());

    this.Commands.add("getAll", new GetAllVariables(this.Variables));
    this.Commands.add("get", new GetVariable(this.Variables));
    this.Commands.add("set", new SetVariable(this.Variables));

    this.Commands.add("help", new Help(this.Commands));
  }
}
