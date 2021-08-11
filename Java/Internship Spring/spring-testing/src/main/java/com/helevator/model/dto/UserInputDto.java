package com.helevator.model.dto;

import lombok.*;

import java.util.Set;

@AllArgsConstructor
@NoArgsConstructor
@Getter
@Setter
@EqualsAndHashCode
public class UserInputDto {
    private String name;
    private Set<AddressInputDto> addresses;
}
