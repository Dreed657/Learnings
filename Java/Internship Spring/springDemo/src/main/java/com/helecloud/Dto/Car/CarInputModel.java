package com.helecloud.Dto.Car;

import lombok.AllArgsConstructor;
import lombok.Getter;
import lombok.Setter;

import javax.validation.constraints.NotBlank;
import javax.validation.constraints.Size;

@Getter
@Setter
@AllArgsConstructor
public class CarInputModel {

    @Size(max = 100, message = "Make size must be between 0 and 100 characters.")
    @NotBlank(message = "Make is mandatory")
    private String make;

    @Size(min = 2, max = 50, message = "Model size must be between 2 and 50 characters.")
    @NotBlank(message = "Model is mandatory")
    private String model;

    @Size(min = 1950, max = 2021, message = "Year must be between 1950 and 2021")
    @NotBlank(message = "Year is mandatory")
    private int year;
}
