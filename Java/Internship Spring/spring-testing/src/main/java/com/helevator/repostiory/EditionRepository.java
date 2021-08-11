package com.helevator.repostiory;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import com.helevator.model.entity.Edition;

@Repository
public interface EditionRepository extends JpaRepository<Edition, Integer> {

}
