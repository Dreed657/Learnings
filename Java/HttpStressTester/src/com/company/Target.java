package com.company;

public class Target {

    private String domain;
    private int port;
    private String uri;
    private Protocol protocol;

    public Target(String domain, int port, String uri, Protocol protocol) {

        this.domain = domain;
        this.port = port;
        this.uri = uri;
        this.protocol = protocol;
    }

    public String GetUrl() {
        return this.protocol.name() + "://" + this.domain + ":" + this.port + "/" + this.uri;
    }

    @Override
    public String toString() {
        var sb = new StringBuilder();

        sb.append("Target ");
        sb.append("Domain: " + this.domain + "\n");
        sb.append("Port: " + this.port + "\n");
        sb.append("uri: " + this.uri + "\n");
        sb.append("Protocol: " + this.protocol.name() + "\n");

        return sb.toString().trim();
    }
}
