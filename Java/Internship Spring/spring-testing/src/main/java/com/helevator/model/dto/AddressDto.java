package com.helevator.model.dto;

import com.helevator.model.entity.AddressType;
import lombok.AllArgsConstructor;
import lombok.EqualsAndHashCode;
import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;

@AllArgsConstructor
@NoArgsConstructor
@Getter
@Setter
@EqualsAndHashCode
public class AddressDto {

  private Integer id;

  private String address;

  private String phone;

  private AddressType type;
  
}
