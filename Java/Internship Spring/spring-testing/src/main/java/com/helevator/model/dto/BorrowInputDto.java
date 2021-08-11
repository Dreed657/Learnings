package com.helevator.model.dto;

import lombok.*;

@AllArgsConstructor
@NoArgsConstructor
@Getter
@Setter
@EqualsAndHashCode
public class BorrowInputDto {
    private Integer userId;
    private String userName;
    private Integer bookId;
    private String bookTitle;
}
