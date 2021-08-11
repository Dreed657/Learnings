package com.helevator.model.dto;

import java.util.Set;

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
public class UserDto {
  private Integer id;
  private String name;
  private Set<AddressDto> addresses;
  private Set<BorrowInputDto> borrowed;
}
