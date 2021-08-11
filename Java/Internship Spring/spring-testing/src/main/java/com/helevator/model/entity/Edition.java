package com.helevator.model.entity;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.ForeignKey;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.JoinColumn;
import javax.persistence.ManyToOne;
import javax.persistence.Table;

import lombok.Getter;
import lombok.Setter;

@Entity
@Table(name = "editions")
@Getter
@Setter
public class Edition {
  @Id
  @GeneratedValue(strategy = GenerationType.AUTO)
  private Integer id;

  @Column
  private String title;

  @Column
  private String publisher;

  @Column(name = "pages_count")
  private Integer pagesCount;

  @Column
  private Integer quantity;

  @ManyToOne
  @JoinColumn(name="book_id",
      foreignKey = @ForeignKey(name = "edition_book_fk"))
  private Book book;
}
