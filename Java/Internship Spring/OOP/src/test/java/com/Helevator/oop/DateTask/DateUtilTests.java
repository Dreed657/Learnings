package com.Helevator.oop.DateTask;

import org.junit.jupiter.api.Assertions;
import org.junit.jupiter.api.Test;

import java.time.format.DateTimeParseException;

public class DateUtilTests {
    @Test
    public void testWorkingCorrectly() {
        var actual = DateUtil.getDayOfWeek("2021/07/15");
        var expected = 4;
        
        Assertions.assertEquals(actual, expected);
    }

    @Test
    public void testInvalidDate() {
        Assertions.assertThrows(DateTimeParseException.class, () -> DateUtil.getDayOfWeek("2800/33/23"));
    }

    @Test
    public void testInvalidNullDate() {
        Assertions.assertThrows(NullPointerException.class, () -> DateUtil.getDayOfWeek(null));
    }

    @Test
    public void testInvalidEmptyDate() {
        Assertions.assertThrows(DateTimeParseException.class, () -> DateUtil.getDayOfWeek(""));
    }
}
