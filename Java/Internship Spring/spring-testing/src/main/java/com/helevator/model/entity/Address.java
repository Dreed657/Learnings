package com.helevator.model.entity;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.EnumType;
import javax.persistence.Enumerated;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.Table;

import lombok.*;

import java.util.Set;

@Entity
@Table(name = "addresses")
@Getter
@Setter
@NoArgsConstructor
@AllArgsConstructor
@EqualsAndHashCode
public class Address {

  public Address(String address, String phone, AddressType type) {
      this.setAddress(address);
      this.setPhone(phone);
      this.setType(type);
  }

  @Id
  @GeneratedValue(strategy = GenerationType.AUTO)
  private Integer id;

  @Column
  private String address;

  @Column
  private String phone;

  @Column
  @Enumerated(EnumType.STRING)
  private AddressType type;
  
}
