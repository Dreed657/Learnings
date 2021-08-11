package com.helecloud.Dto.Car;

import lombok.*;

import java.util.Objects;

@Getter
@Setter
@NoArgsConstructor
@AllArgsConstructor
@EqualsAndHashCode
public class CarViewModel {
    private String make;
    private String model;
    private int year;
}
