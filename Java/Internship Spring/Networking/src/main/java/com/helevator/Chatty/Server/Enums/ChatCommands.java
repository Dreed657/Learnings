package com.helevator.Chatty.Server.Enums;

public enum ChatCommands {
    LOGIN("LOGIN"),
    LOGOUT("LOGOUT"),
    JOIN("JOIN"),
    LEAVE("LEAVE"),
    MSG("MSG");

    private String _command = null;

    ChatCommands(String command) {
        this._command = command;
    }

    public String toString() {
        return this._command;
    }
}
