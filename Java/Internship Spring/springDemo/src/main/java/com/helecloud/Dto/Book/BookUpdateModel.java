package com.helecloud.Dto.Book;

import lombok.AllArgsConstructor;
import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;

import javax.validation.constraints.Min;
import javax.validation.constraints.NotBlank;
import javax.validation.constraints.Size;

@NoArgsConstructor
@AllArgsConstructor
@Getter
@Setter
public class BookUpdateModel {

    @NotBlank(message = "Id is mandatory")
    private String id;

    @Size(min = 5, max = 10, message = "Name size must be between 5 and 10 characters.")
    @NotBlank(message = "Name is mandatory")
    private String name;

    @Size(min = 5, max = 100, message = "Description size must be between 5 and 100 characters.")
    @NotBlank(message = "Description is mandatory")
    private String description;
}
