package com.helevator.model.dto;

import lombok.*;

import java.util.Set;

@AllArgsConstructor
@NoArgsConstructor
@Getter
@Setter
@EqualsAndHashCode
public class BookDto {
    private Integer id;
    private String title;
    private String genre;
    private Set<AuthorDto> authors;
    private Set<EditionDto> editions;
    private Set<BorrowInputDto> borrowed;
}
