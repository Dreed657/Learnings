package com.helevator.service;

import java.util.HashSet;
import java.util.List;
import java.util.stream.Collectors;

import com.helevator.model.dto.*;
import com.helevator.model.entity.Address;
import com.helevator.repostiory.AddressRepository;
import com.helevator.repostiory.BookRepository;
import org.modelmapper.ModelMapper;
import org.springframework.stereotype.Service;

import com.helevator.model.entity.User;
import com.helevator.repostiory.UserRepository;
import lombok.RequiredArgsConstructor;

@Service
@RequiredArgsConstructor
public class UserService {

  private final UserRepository userRepository;

  private final AddressRepository addressRepository;

  private final BookRepository bookRepository;

  private final ModelMapper mapper;

  public List<UserDto> getUsers() {
    return userRepository.findAll()
            .stream()
            .map(u -> mapper.map(u, UserDto.class))
            .collect(Collectors.toList());
  }

  public UserDto create(UserInputDto model) {
    var addresses = model.getAddresses()
            .stream()
            .map(a -> new Address(a.getAddress(), a.getPhone(), a.getType()))
            .collect(Collectors.toSet());

    addressRepository.saveAll(addresses);

    var user = new User(model.getName(), addresses);

    userRepository.save(user);

    return mapper.map(user, UserDto.class);
  }

  public BorrowDto borrow(BorrowInputDto model) {
    var resultBook = bookRepository.findById(model.getBookId());
    var book = resultBook.orElseThrow(() -> new RuntimeException("Book with id " + model.getBookId() + " was not found!"));

    var resultUser = userRepository.findById(model.getUserId());
    var user = resultUser.orElseThrow(() -> new RuntimeException("User with id " + model.getUserId() + " was not found!"));

    user.getBorrowed().add(book);
    book.getBorrowed().add(user);

    userRepository.save(user);

    return new BorrowDto(mapper.map(user, UserDto.class), mapper.map(book, BookDto.class));
  }
}
