package com.helecloud;

import java.util.Objects;

public class Emp {
    private final int eid;
    private final String ename;
    private final int sal;
    private final int deptId;

    public Emp(int eid, String ename, int sal, int deptId) {
        this.eid = eid;
        this.ename = ename;
        this.sal = sal;
        this.deptId = deptId;
    }

    public int getEid() {
        return eid;
    }

    public String getEname() {
        return ename;
    }

    public int getSal() {
        return sal;
    }

    public int getDeptId() {
        return deptId;
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (!(o instanceof Emp)) return false;
        Emp emp = (Emp) o;
        return getEid() == emp.getEid();
    }

    @Override
    public int hashCode() {
        return Objects.hash(getEid());
    }

    @Override
    public String toString() {
        final StringBuilder sb = new StringBuilder("Emp{");

        sb.append("eid=").append(eid);
        sb.append(", ename='").append(ename).append('\'');
        sb.append(", sal=").append(sal);
        sb.append(", deptId=").append(deptId);
        sb.append('}');

        return sb.toString();
    }
}
