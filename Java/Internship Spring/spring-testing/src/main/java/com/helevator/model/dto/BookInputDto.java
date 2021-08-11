package com.helevator.model.dto;

import lombok.*;

import java.util.Set;

@AllArgsConstructor
@NoArgsConstructor
@Getter
@Setter
@EqualsAndHashCode
public class BookInputDto {
    private String title;
    private String genre;
    private Set<AuthorInputDto> authors;
    private Set<EditionInputDto> editions;
}
