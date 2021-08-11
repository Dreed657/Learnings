package com.helevator.model.dto;

import lombok.*;

@AllArgsConstructor
@NoArgsConstructor
@Getter
@Setter
@EqualsAndHashCode
public class EditionDto {
    private Integer id;
    private String title;
    private String publisher;
    private Integer pagesCount;
    private Integer quantity;
    private BookDto book;
}
