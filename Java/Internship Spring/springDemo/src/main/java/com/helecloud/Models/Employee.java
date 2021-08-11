package com.helecloud.Models;

import lombok.AllArgsConstructor;
import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;

import javax.persistence.*;
import java.math.BigDecimal;
import java.math.BigInteger;

@Entity
@Getter
@Setter
@Table(name = "emp")
@NoArgsConstructor
@AllArgsConstructor
public class Employee {

    public Employee(String name, BigDecimal sal, Department dept) {
        this.setName(name);
        this.setSal(sal);
        this.setDept(dept);
    }

    @Id
    @GeneratedValue(strategy = GenerationType.AUTO)
    private Integer id;

    @Column(nullable = false)
    private String name;

    @Column(nullable = false)
    private BigDecimal sal;

    @ManyToOne()
    @JoinColumn(name = "dept_id")
    private Department dept;
}
