package com.helevator.repostiory;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import com.helevator.model.entity.Book;

@Repository
public interface BookRepository extends JpaRepository<Book, Integer> {

}
