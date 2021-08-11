package com.helecloud.Dto.Department;

import lombok.AllArgsConstructor;
import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;

import javax.validation.constraints.NotBlank;
import javax.validation.constraints.Size;

@Getter
@Setter
@NoArgsConstructor
@AllArgsConstructor
public class DepartmentInputModel {
    @Size(min = 2, max = 25, message = "Name size must be between 2 and 25 characters.")
    @NotBlank(message = "Name is mandatory")
    private String name;
}
