package com.helevator.model.dto;

import lombok.*;

@AllArgsConstructor
@NoArgsConstructor
@Getter
@Setter
@EqualsAndHashCode
public class EditionInputDto {
    private String title;
    private String publisher;
    private Integer pagesCount;
    private Integer quantity;
    private Integer bookId;
}
