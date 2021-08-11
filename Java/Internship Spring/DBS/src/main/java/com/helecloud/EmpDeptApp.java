package com.helecloud;

import javax.sql.DataSource;
import java.sql.Connection;
import java.sql.SQLException;

public class EmpDeptApp {

  public static void main(String[] args) throws SQLException {
    DataSourceFactory dataSourceFactory = new HikariDsFactory();

    final DataSource dataSource = dataSourceFactory.createDataSource();

    try (Connection connection = dataSource.getConnection()) {
      final Emp newEmp = new Emp(10, "Ignat", 10, 1);
      final EmpRepository empRepository = new EmpRepository();
//      empRepository.insertEmp(connection, newEmp);
      var res = empRepository.getEmpById(connection, newEmp.getEid());

        System.out.println("Response: " + res);
//      empRepository.updateEmp(connection, newEmp);
//      empRepository.deleteEmp(connection, newEmp);
    }
  }
}
