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
import javax.persistence.OneToMany;
import javax.persistence.Table;

import lombok.AllArgsConstructor;
import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;

@Entity
@Table(name = "books")
@Getter
@Setter
@AllArgsConstructor
@NoArgsConstructor
public class Book {
  @Id
  @GeneratedValue(strategy = GenerationType.AUTO)
  private Integer id;

  @Column
  private String title;

  @Column
  private String genre;

  @ManyToMany(fetch = FetchType.LAZY)
  @JoinTable(name = "books_authors",
      joinColumns = {@JoinColumn(name = "book_id", nullable = false,
          foreignKey = @ForeignKey(name = "book_author_book_fk"))},
      inverseJoinColumns = {@JoinColumn(name = "author_id", nullable = false,
          foreignKey = @ForeignKey(name = "book_author_author_fk"))})
  private Set<Author> authors;

  @OneToMany(mappedBy = "book", fetch = FetchType.LAZY)
  private Set<Edition> editions;

  @ManyToMany
  private Set<User> borrowed;

  @Override
  public boolean equals(Object o) {
    if (this == o) {
      return true;
    }
    if (o == null || getClass() != o.getClass()) {
      return false;
    }
    Book book = (Book) o;
    return id.equals(book.id) && title.equals(book.title) && genre.equals(book.genre);
  }

  @Override
  public int hashCode() {
    return Objects.hash(id, title, genre);
  }
}
