package com.helevator.Facade.impl.commands;

import com.helevator.Facade.api.Executable;
import com.helevator.Facade.impl.storage.CommandRepository;
import org.junit.jupiter.api.AfterEach;
import org.junit.jupiter.api.Assertions;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;

import java.util.Collection;


class HelpTest extends AbstractCommandTest {
    @BeforeEach
    public void beforeEach() {
        this.commandRepo = new CommandRepository();

        this.commandRepo.add("reverse", new Reverse());
        this.commandRepo.add("reverse-words", new ReverseWords());
        this.commandRepo.add("count-words", new CountWords());

        this.exe = new Help(this.commandRepo);
    }

    @AfterEach
    public void tearDown() {
        this.exe = null;
    }

    @Test
    public void testHelpWorksCorrectly() {
        var expected = this.getCommandInfo();
        var actual = this.exe.execute(null);

        Assertions.assertEquals(expected, actual);
    }

    private String getCommandInfo() {
        var sb = new StringBuilder();
        var commands = (Collection<Executable>)this.commandRepo.getAll();

        for (Executable executable : commands) {
            sb.append(executable.getInfo()).append("\n");
        }

        return sb.toString().trim();
    }
}