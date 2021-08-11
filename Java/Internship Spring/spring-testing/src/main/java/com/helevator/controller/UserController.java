package com.helevator.controller;

import java.util.List;

import com.helevator.model.dto.BorrowDto;
import com.helevator.model.dto.BorrowInputDto;
import com.helevator.model.dto.UserInputDto;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import com.helevator.model.dto.UserDto;
import com.helevator.service.UserService;
import lombok.RequiredArgsConstructor;

@RestController
@RequestMapping("/users")
@RequiredArgsConstructor
public class UserController {

  private final UserService userService;

  @GetMapping("/")
  public List<UserDto> listUsers() {
    return userService.getUsers();
  }

  @PostMapping("/")
  public ResponseEntity<UserDto> create(@RequestBody UserInputDto model) {
    return ResponseEntity.ok().body(userService.create(model));
  }

  @PostMapping("/borrow")
  public ResponseEntity borrow(@RequestBody BorrowInputDto model) {
    try {
      return ResponseEntity.ok().body(userService.borrow(model));
    } catch (RuntimeException e) {
      return ResponseEntity.status(HttpStatus.NOT_FOUND).body(e.getMessage());
    }
  }
}
