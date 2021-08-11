package com.helecloud;

import org.postgresql.core.ResultHandler;

import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.Iterator;
import java.util.LinkedList;
import java.util.List;
import java.util.logging.Logger;

public class EmpRepository {
  private static final Logger log = Logger.getLogger(EmpDeptApp.class.getName());

  public EmpRepository() {}

  public Iterator<Emp> getEmp(final Connection conn) {
    final List<Emp> emps = new LinkedList<>();
    try (PreparedStatement pst = conn.prepareStatement("SELECT eid, ename, sal, dept_id FROM emp");
        ResultSet rs = pst.executeQuery()) {
      while (rs.next()) {
        final Emp emp = new Emp(rs.getInt(1), rs.getString(2), rs.getInt(3), rs.getInt(4));
        emps.add(emp);
        log.info("RECEIVED: " + emp);
      }
    } catch (SQLException e) {
      throw new RuntimeException(e);
    }
    return emps.iterator();
  }

  public Emp getEmpById(final Connection conn, int eid) {
    final Emp emp;
    try (PreparedStatement pst = conn.prepareStatement("SELECT eid, ename, sal, dept_id FROM emp WHERE eid = " + eid);
         ResultSet rs = pst.executeQuery()) {

      emp = new Emp(rs.getInt(1), rs.getString(2), rs.getInt(3), rs.getInt(4));

      log.info("RECEIVED: " + emp);
    } catch (SQLException e) {
      throw new RuntimeException(e);
    }
    return emp;
  }

  public void insertEmp(final Connection conn, final Emp emp) {
    try (PreparedStatement pst =
        conn.prepareStatement("INSERT INTO emp (eid, ename, sal, dept_id) VALUES (?, ?, ?, ?)")) {
      pst.setInt(1, emp.getEid());
      pst.setString(2, emp.getEname());
      pst.setInt(3, emp.getSal());
      pst.setInt(4, emp.getDeptId());
      pst.executeUpdate();

      log.info("INSERTED: " + emp);
    } catch (SQLException e) {
      throw new RuntimeException(e);
    }
  }

  public void deleteEmp(final Connection conn, final Emp emp) {
    try (PreparedStatement pst = conn.prepareStatement("DELETE FROM emp WHERE eid = ?")) {
      pst.setInt(1, emp.getEid());
      pst.execute();

      log.info("UPDATED: " + emp);
    } catch (SQLException e) {
      throw new RuntimeException(e);
    }
  }

  public void updateEmp(final Connection conn, final Emp emp) {
    try (PreparedStatement pst =
        conn.prepareStatement("UPDATE emp SET ename = ?, sal = ?, dept_id = ? WHERE eid = ?")) {
      pst.setString(1, emp.getEname());
      pst.setInt(2, emp.getSal());
      pst.setInt(3, emp.getDeptId());
      pst.setInt(4, emp.getEid());
      pst.executeUpdate();

      log.info("UPDATED: " + emp);
    } catch (SQLException e) {
      throw new RuntimeException(e);
    }
  }
}
