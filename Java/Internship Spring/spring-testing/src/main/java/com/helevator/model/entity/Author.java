package com.helevator.model.entity;

import java.util.Objects;
import java.util.Set;
import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.FetchType;
import javax.persistence.ForeignKey;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.JoinColumn;
import javax.persistence.JoinTable;
import javax.persistence.ManyToMany;
import javax.persistence.Table;

import lombok.Getter;
import lombok.Setter;

@Entity
@Table(name = "authors")
@Getter
@Setter
public class Author {
  @Id
  @GeneratedValue(strategy = GenerationType.AUTO)
  private Integer id;

  @Column
  private String name;

  @Column
  private String description;

  @ManyToMany(fetch = FetchType.LAZY)
  @JoinTable(name = "books_authors",
      joinColumns = {@JoinColumn(name = "author_id", nullable = false,
          foreignKey = @ForeignKey(name = "book_author_author_fk"))},
      inverseJoinColumns = {@JoinColumn(name = "book_id", nullable = false,
          foreignKey = @ForeignKey(name = "book_author_book_fk"))})
  private Set<Book> books;

  @Override
  public boolean equals(Object o) {
    if (this == o) {
      return true;
    }
    if (o == null || getClass() != o.getClass()) {
      return false;
    }
    Author author = (Author) o;
    return id.equals(author.id) && name.equals(author.name) && description.equals(author.description);
  }

  @Override
  public int hashCode() {
    return Objects.hash(id, name, description);
  }
}
