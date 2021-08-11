package com.helevator.model.dto;

import com.helevator.model.entity.AddressType;
import lombok.*;

@AllArgsConstructor
@NoArgsConstructor
@Getter
@Setter
@EqualsAndHashCode
public class AddressInputDto {
    private String address;
    private String phone;
    private AddressType type;
}
