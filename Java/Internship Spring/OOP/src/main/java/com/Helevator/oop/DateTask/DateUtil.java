package com.Helevator.oop.DateTask;

import java.time.LocalDate;
import java.time.format.DateTimeFormatter;

public class DateUtil {

    public static Integer getDayOfWeek(String dateStr) {
        String format = "yyyy/MM/dd";
        LocalDate date = LocalDate.parse(dateStr, DateTimeFormatter.ofPattern(format));
        return date.getDayOfWeek().getValue();
    }
}
