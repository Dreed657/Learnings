package com.helecloud.Models;

import lombok.*;

import javax.persistence.*;

@Entity
@Table(name = "Cars")
@Getter
@Setter
@NoArgsConstructor
@AllArgsConstructor
public class Car {

    public Car(String make, String model, int year) {
        this.setMake(make);
        this.setModel(model);
        this.setYear(year);
    }

    @Id
    @GeneratedValue(strategy = GenerationType.AUTO)
    private Integer Id;

    @Column(nullable = false)
    private String make;

    @Column(nullable = false)
    private String model;

    @Column(nullable = false)
    private int year;
}
