package com.helevator.model.dto;

import lombok.*;

@AllArgsConstructor
@NoArgsConstructor
@Getter
@Setter
@EqualsAndHashCode
public class AuthorDto {
    private Integer id;
    private String name;
    private String description;
}
