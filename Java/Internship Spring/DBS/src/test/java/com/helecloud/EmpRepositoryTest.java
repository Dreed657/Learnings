package com.helecloud;

import org.junit.jupiter.api.AfterEach;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;
import org.mockito.Mockito;

import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.util.Iterator;
import java.util.concurrent.atomic.AtomicInteger;

import static org.assertj.core.api.Assertions.assertThat;
import static org.junit.jupiter.api.Assertions.*;

class EmpRepositoryTest {

  @BeforeEach
  void setUp() {}

  @AfterEach
  void tearDown() {}

  @Test
  void getEmp() throws Exception {
    final Connection con = Mockito.mock(Connection.class);
    final ResultSet mockResultSet = Mockito.mock(ResultSet.class);
    final PreparedStatement mockPreparedStatement = Mockito.mock(PreparedStatement.class);

    Mockito.when(con.prepareStatement(Mockito.anyString())).thenReturn(mockPreparedStatement);
    Mockito.when(mockPreparedStatement.executeQuery()).thenReturn(mockResultSet);
    Mockito.when(mockResultSet.next()).thenReturn(true, true, false);
    Mockito.when(mockResultSet.getInt(1)).thenReturn(1);
    Mockito.when(mockResultSet.getInt(3)).thenReturn(3);
    Mockito.when(mockResultSet.getInt(4)).thenReturn(4);
    Mockito.when(mockResultSet.getString(2)).thenReturn("Test");

    final Iterator<Emp> emp = new EmpRepository().getEmp(con);
    assertThat(emp).isNotNull();

    AtomicInteger count = new AtomicInteger();
    emp.forEachRemaining((e) -> count.getAndIncrement());
    assertThat(count.getPlain()).isEqualTo(2);
  }

  @Test
  void getEmpById() throws Exception {
    final Connection con = Mockito.mock(Connection.class);
    final ResultSet mockResultSet = Mockito.mock(ResultSet.class);
    final PreparedStatement mockPreparedStatement = Mockito.mock(PreparedStatement.class);

    var expectedEmp = new Emp(1, "Name", 50, 1);

    Mockito.when(con.prepareStatement(Mockito.anyString())).thenReturn(mockPreparedStatement);
    Mockito.when(mockPreparedStatement.executeQuery()).thenReturn(mockResultSet);
    Mockito.when(mockResultSet.getInt(1)).thenReturn(expectedEmp.getEid());
    Mockito.when(mockResultSet.getString(2)).thenReturn(expectedEmp.getEname());
    Mockito.when(mockResultSet.getInt(3)).thenReturn(expectedEmp.getSal());
    Mockito.when(mockResultSet.getInt(4)).thenReturn(expectedEmp.getDeptId());

    final Emp emp = new EmpRepository().getEmpById(con, 1);
    assertThat(emp).isNotNull();
    assertThat(emp.getEid()).isEqualTo(expectedEmp.getEid());
    assertThat(emp.getEname()).isEqualTo(expectedEmp.getEname());
    assertThat(emp.getSal()).isEqualTo(expectedEmp.getSal());
    assertThat(emp.getDeptId()).isEqualTo(expectedEmp.getDeptId());
  }

  @Test
  void insertEmp() {}

  @Test
  void deleteEmp() {}

  @Test
  void updateEmp() {}
}
