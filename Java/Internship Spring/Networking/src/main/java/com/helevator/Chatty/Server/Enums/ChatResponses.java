package com.helevator.Chatty.Server.Enums;

import java.util.Locale;

public enum ChatResponses {
    OK("OK"),
    ERROR("ERROR"),
    TIMEOUT("TIMEOUT"),
    TOROOM("TOROOM"),
    TOUSER("TOUSER");

    private String response = null;

    ChatResponses(String response) {
        this.response = response;
    }

    public String toString() {
        return this.response.toLowerCase(Locale.ROOT);
    }
}
