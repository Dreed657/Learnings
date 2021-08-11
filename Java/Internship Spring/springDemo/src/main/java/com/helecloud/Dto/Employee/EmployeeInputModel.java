package com.helecloud.Dto.Employee;

import lombok.*;

import javax.validation.constraints.NotBlank;
import javax.validation.constraints.NotNull;
import javax.validation.constraints.Size;
import java.math.BigDecimal;

@Getter
@Setter
@NoArgsConstructor
@AllArgsConstructor
public class EmployeeInputModel {
    @Size(min = 2, max = 25, message = "Name size must be between 2 and 25 characters.")
    @NotBlank(message = "Name is mandatory")
    private String name;

    @NotNull(message = "Sal is mandatory")
    private BigDecimal sal;

    @NotNull(message = "DeptId is mandatory")
    private Integer deptId;
}
