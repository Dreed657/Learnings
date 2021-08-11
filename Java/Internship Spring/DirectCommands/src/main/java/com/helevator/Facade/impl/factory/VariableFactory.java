package com.helevator.Facade.impl.factory;

import com.helevator.Facade.impl.storage.Variable;

import java.util.Locale;

public class VariableFactory {
    public static Variable create(String type, String value) {
        if (value == null) {
            throw new IllegalArgumentException("Value must not be null!");
        }

        switch (type.toLowerCase(Locale.ROOT)) {
            case "string":
                return new Variable<String>(value);
            case "number":
                return new Variable<Integer>(Integer.parseInt(value));
            default:
                throw new IllegalArgumentException(String.format("Provided type '%s' is not in allowed types!", type));
        }
    }
}
