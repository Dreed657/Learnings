package com.helevator.model.dto;

import lombok.*;

@AllArgsConstructor
@NoArgsConstructor
@Getter
@Setter
@EqualsAndHashCode
public class AuthorInputDto {
    private String name;
    private String description;
}
