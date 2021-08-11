package com.helecloud;

import org.junit.jupiter.api.Test;

import static org.assertj.core.api.Assertions.*;

class EmpTest {

    public static final int EID = 1;
    public static final String ENAME = "Petar";
    public static final int SAL = 20;
    public static final int DEPT_ID = 1;
    public static final int EID1 = 2;
    public static final String ENAME1 = "Georgi";
    public static final int SAL1 = 40;
    public static final int DEPT_ID1 = 2;

    @Test
    void getAll() {
        final Emp test = new Emp(EID, ENAME, SAL, DEPT_ID);

        assertThat(test.getEid()).isEqualTo(EID);
        assertThat(test.getEname()).isEqualTo(ENAME);
        assertThat(test.getDeptId()).isEqualTo(DEPT_ID);
        assertThat(test.getSal()).isEqualTo(SAL);
    }

    @Test
    void testEquals() {
        final Emp actual = new Emp(EID, ENAME, SAL, DEPT_ID);
        final Emp same = new Emp(EID, ENAME, SAL, DEPT_ID);
        final Emp diff = new Emp(EID1, ENAME1, SAL1, DEPT_ID1);
        final Emp nullEmp  = null;
        final Emp sameIdDiffDataEmp  = new Emp(EID, ENAME1, SAL1, DEPT_ID1);;
        final Emp diffIdSameDataEmp  = new Emp(EID1, ENAME, SAL, DEPT_ID);;

        assertThat(actual).isEqualTo(actual);
        assertThat(actual).isEqualTo(same);
        assertThat(actual).isNotEqualTo(diff);
        assertThat(actual).isNotEqualTo(nullEmp);
        assertThat(actual).isEqualTo(sameIdDiffDataEmp);
        assertThat(actual).isNotEqualTo(diffIdSameDataEmp);
    }

    @Test
    void testHashCode() {
        final Emp actual = new Emp(EID, ENAME, SAL, DEPT_ID);
        final Emp sameIdEmp = new Emp(EID, ENAME, SAL, DEPT_ID);
        final Emp diffIdEmp = new Emp(EID1, ENAME, SAL, DEPT_ID);

        assertThat(actual.hashCode()).isEqualTo(actual.hashCode());
        assertThat(actual.hashCode()).isEqualTo(sameIdEmp.hashCode());
        assertThat(actual.hashCode()).isNotEqualTo(diffIdEmp.hashCode());
    }

  @Test
  void getEid() {
      final int actual = new Emp(EID, ENAME, SAL, DEPT_ID)
              .getEid();

      assertThat(actual).isEqualTo(EID);
  }

  @Test
  void getEname() {
      final String actual = new Emp(EID, ENAME, SAL, DEPT_ID)
              .getEname();

      assertThat(actual).isEqualTo(ENAME);
  }

  @Test
  void getSal() {
      final int actual = new Emp(EID, ENAME, SAL, DEPT_ID)
              .getSal();

      assertThat(actual).isEqualTo(SAL);
  }

  @Test
  void getDeptId() {
      final int actual = new Emp(EID, ENAME, SAL, DEPT_ID)
              .getDeptId();

      assertThat(actual).isEqualTo(DEPT_ID);
  }

  @Test
  void testToString() {
      final StringBuilder sb = new StringBuilder("Emp{");

      sb.append("eid=").append(EID);
      sb.append(", ename='").append(ENAME).append('\'');
      sb.append(", sal=").append(SAL);
      sb.append(", deptId=").append(DEPT_ID);
      sb.append('}');

      String expected = sb.toString();

      final Emp emp = new Emp(EID, ENAME, SAL, DEPT_ID);
      String actual = emp.toString();
      
      assertThat(actual).isEqualTo(expected);
  }
}