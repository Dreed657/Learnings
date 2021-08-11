package com.helecloud.Dto.Book;

import lombok.AllArgsConstructor;
import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;

import javax.validation.constraints.Size;
import javax.validation.constraints.NotBlank;

@NoArgsConstructor
@AllArgsConstructor
@Getter
@Setter
public class BookCreateModel {

    @Size(min = 5, max = 10, message = "Name size must be between 5 and 10 characters.")
    @NotBlank(message = "Name is mandatory")
    private String name;

    @Size(min = 5, max = 100, message = "Description size must be between 5 and 100 characters.")
    @NotBlank(message = "Description is mandatory")
    private String description;
}
