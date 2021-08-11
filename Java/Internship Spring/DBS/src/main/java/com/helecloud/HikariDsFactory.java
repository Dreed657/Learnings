package com.helecloud;

import com.zaxxer.hikari.HikariConfig;
import com.zaxxer.hikari.HikariDataSource;
import javax.sql.DataSource;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

public class HikariDsFactory implements DataSourceFactory {

    private static final Logger log = LoggerFactory.getLogger(HikariDsFactory.class);
    private final String configFile;

    public HikariDsFactory() {
        this.configFile = "/home/dreed657/dev/helevator_2021/Stoyan/DBS/src/main/resources/db.properties";
    }

    public HikariDsFactory(String configFile) {
        if (configFile == null || configFile.trim().isEmpty()) {
            throw new IllegalArgumentException("Provide path to config file!");
        }
        this.configFile = configFile;
    }

    @Override
    public DataSource createDataSource() {
        final HikariConfig cfg = new HikariConfig(configFile);

        log.info("Successfully connected to db!");

        return new HikariDataSource(cfg);
    }
}
