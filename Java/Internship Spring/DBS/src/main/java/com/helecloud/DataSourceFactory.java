package com.helecloud;

import javax.sql.DataSource;

public interface DataSourceFactory {
    DataSource createDataSource();
}
