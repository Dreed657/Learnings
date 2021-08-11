package com.helecloud.Controllers;

import com.fasterxml.jackson.core.type.TypeReference;
import com.fasterxml.jackson.databind.ObjectMapper;
import com.github.javafaker.Faker;
import com.helecloud.Dto.Car.CarInputModel;
import com.helecloud.Dto.Car.CarViewModel;
import com.helecloud.Models.Car;
import com.helecloud.Repositories.CarRepository;
import org.junit.jupiter.api.AfterEach;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;
import org.modelmapper.ModelMapper;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.autoconfigure.web.servlet.AutoConfigureMockMvc;
import org.springframework.boot.test.context.SpringBootTest;
import org.springframework.http.MediaType;
import org.springframework.test.annotation.DirtiesContext;
import org.springframework.test.web.servlet.MockMvc;

import java.nio.charset.Charset;
import java.util.ArrayList;
import java.util.List;
import java.util.concurrent.TimeUnit;
import java.util.stream.Collectors;

import static org.assertj.core.api.Assertions.assertThat;
import static org.springframework.http.RequestEntity.post;
import static org.springframework.test.web.servlet.request.MockMvcRequestBuilders.delete;
import static org.springframework.test.web.servlet.request.MockMvcRequestBuilders.get;
import static org.springframework.test.web.servlet.result.MockMvcResultMatchers.status;

@SpringBootTest
@AutoConfigureMockMvc
class CarControllerIntegratedTest {

    @Autowired
    private MockMvc mockMvc;

    @Autowired
    private ObjectMapper objectMapper;

    @Autowired
    private ModelMapper modelMapper;

    @Autowired
    private CarRepository carRepository;

    private final Faker faker = new Faker();

    private final List<Car> cars = List.of(
            new Car(faker.aviation().airport(), faker.aviation().airport(), 2000),
            new Car(faker.aviation().airport(), faker.aviation().airport(), 2000),
            new Car(faker.aviation().airport(), faker.aviation().airport(), 2000)
    );

    @BeforeEach
    void setUp() {
        carRepository.saveAll(cars);
    }

    @AfterEach
    void tearDown() {
        carRepository.deleteAll(cars);
    }

    @Test
    void getAllShouldReturnAll() throws Exception {
        // Act
        var resultActions = mockMvc
                .perform(get("/api/car/").contentType(MediaType.APPLICATION_JSON))
                .andExpect(status().isOk());

        var result = resultActions.andReturn();
        var contentAsString = result.getResponse().getContentAsString();
        var actual = objectMapper.readValue(contentAsString, new TypeReference<List<CarViewModel>>() {
        });

        var expected = this.cars.stream()
                .map(e -> modelMapper.map(e, CarViewModel.class))
                .collect(Collectors.toList());

        // Assert
        assertThat(actual.size()).isEqualTo(expected.size());
        assertThat(actual).isEqualTo(expected);
    }

    @Test
    void getByIdShouldWorkCorrectly() throws Exception {
        var carId = carRepository.findAll().get(0).getId();

        var resultActions = mockMvc
                .perform(get("/api/car/" + carId).contentType(MediaType.APPLICATION_JSON))
                .andExpect(status().isOk());

        var result = resultActions.andReturn();
        var contentAsString = result.getResponse().getContentAsString();
        var actual = objectMapper.readValue(contentAsString, new TypeReference<CarViewModel>() {
        });

        var expected = modelMapper.map(this.cars.get(0), CarViewModel.class);

        assertThat(actual).isEqualTo(expected);
    }

    @Test
    void getByIdShouldReturnAnErrorIfNotFound() throws Exception {
        var resultActions = mockMvc
                .perform(get("/api/car/10000").contentType(MediaType.APPLICATION_JSON))
                .andExpect(status().isNotFound());

        var result = resultActions.andReturn();
        var contentAsString = result.getResponse().getContentAsString();

        assertThat(contentAsString).isEmpty();
    }

    @Test
    void deleteShouldWorkCorrectly() throws Exception {
        var carId = carRepository.findAll().get(0).getId();

        var resultActions = mockMvc
                .perform(delete("/api/car/" + carId).contentType(MediaType.APPLICATION_JSON))
                .andExpect(status().isOk());

        var result = resultActions.andReturn();
        var contentAsString = result.getResponse().getContentAsString();
        var actual = objectMapper.readValue(contentAsString, new TypeReference<Boolean>() {
        });

        assertThat(actual).isEqualTo(true);
    }

    @Test
    void deleteShouldReturnAnErrorIfNotFound() throws Exception {
        var resultActions = mockMvc
                .perform(delete("/api/car/10").contentType(MediaType.APPLICATION_JSON))
                .andExpect(status().isNotFound());

        var result = resultActions.andReturn();
        var actual = result.getResponse().getContentAsString();

        assertThat(actual).isEmpty();
    }
}