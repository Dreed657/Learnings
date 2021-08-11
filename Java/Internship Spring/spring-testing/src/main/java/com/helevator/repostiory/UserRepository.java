package com.helevator.repostiory;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import com.helevator.model.entity.User;

@Repository
public interface UserRepository extends JpaRepository<User, Integer> {

}
