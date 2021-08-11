package com.helecloud.Dto.Employee;

import com.helecloud.Dto.Department.DepartmentViewModel;
import lombok.*;

import java.math.BigDecimal;
import java.util.Objects;

@Getter
@Setter
@NoArgsConstructor
@AllArgsConstructor
@EqualsAndHashCode
public class EmployeeViewModel {
    private String name;
    private BigDecimal sal;
    private DepartmentViewModel dept;
}
