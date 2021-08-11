package com.helevator.repostiory;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import com.helevator.model.entity.Author;

@Repository
public interface AuthorRepository extends JpaRepository<Author, Integer> {

}
