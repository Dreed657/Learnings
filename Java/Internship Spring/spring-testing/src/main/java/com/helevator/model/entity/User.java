package com.helevator.model.entity;

import java.util.Set;
import javax.persistence.*;

import com.helevator.model.dto.AddressDto;
import lombok.AllArgsConstructor;
import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;

@Entity
@Table(name = "users")
@Getter
@Setter
@AllArgsConstructor
@NoArgsConstructor
public class User {

  public User(String name, Set<Address> addresses) {
    this.setName(name);
    this.setAddresses(addresses);
  }

  @Id
  @GeneratedValue(strategy = GenerationType.AUTO)
  private Integer id;

  @Column
  private String name;

  @OneToMany(fetch = FetchType.LAZY)
  @JoinColumn(name = "user_id" , foreignKey = @ForeignKey(name = "address_user_fk"))
  private Set<Address> addresses;

  @ManyToMany
  private Set<Book> borrowed;
}
