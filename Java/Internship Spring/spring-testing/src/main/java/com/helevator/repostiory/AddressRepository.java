package com.helevator.repostiory;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import com.helevator.model.entity.Address;

@Repository
public interface AddressRepository extends JpaRepository<Address, Integer> {

}
