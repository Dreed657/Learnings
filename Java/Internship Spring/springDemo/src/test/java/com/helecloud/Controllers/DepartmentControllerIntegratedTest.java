package com.helecloud.Controllers;

import com.fasterxml.jackson.core.type.TypeReference;
import com.fasterxml.jackson.databind.ObjectMapper;
import com.github.javafaker.Faker;
import com.helecloud.Dto.Car.CarViewModel;
import com.helecloud.Dto.Department.DepartmentViewModel;
import com.helecloud.Models.Car;
import com.helecloud.Models.Department;
import com.helecloud.Repositories.CarRepository;
import com.helecloud.Repositories.DepartmentRepository;
import org.junit.jupiter.api.AfterEach;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;
import org.modelmapper.ModelMapper;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.autoconfigure.web.servlet.AutoConfigureMockMvc;
import org.springframework.boot.test.context.SpringBootTest;
import org.springframework.http.MediaType;
import org.springframework.test.web.servlet.MockMvc;

import java.util.List;
import java.util.stream.Collectors;

import static org.assertj.core.api.Assertions.assertThat;
import static org.junit.jupiter.api.Assertions.*;
import static org.springframework.test.web.servlet.request.MockMvcRequestBuilders.delete;
import static org.springframework.test.web.servlet.request.MockMvcRequestBuilders.get;
import static org.springframework.test.web.servlet.result.MockMvcResultMatchers.status;

@SpringBootTest
@AutoConfigureMockMvc
class DepartmentControllerIntegratedTest {

    @Autowired
    private MockMvc mockMvc;

    @Autowired
    private ObjectMapper objectMapper;

    @Autowired
    private ModelMapper modelMapper;

    @Autowired
    private DepartmentRepository departmentRepository;

    private final Faker faker = new Faker();

    private final List<Department> departments = List.of(
            new Department(faker.name().title()),
            new Department(faker.name().title()),
            new Department(faker.name().title())
    );

    @BeforeEach
    void setUp() {
        departmentRepository.saveAll(departments);
    }

    @AfterEach
    void tearDown() {
        departmentRepository.deleteAll(departments);
    }

    @Test
    void getAllShouldReturnAll() throws Exception {
        // Act
        var resultActions = mockMvc
                .perform(get("/api/department/").contentType(MediaType.APPLICATION_JSON))
                .andExpect(status().isOk());

        var result = resultActions.andReturn();
        var contentAsString = result.getResponse().getContentAsString();
        var actual = objectMapper.readValue(contentAsString, new TypeReference<List<DepartmentViewModel>>() {
        });

        var expected = this.departments.stream()
                .map(e -> modelMapper.map(e, DepartmentViewModel.class))
                .collect(Collectors.toList());

        // Assert
        assertThat(actual.size()).isEqualTo(expected.size());
        assertThat(actual).isEqualTo(expected);
    }

    @Test
    void getByIdShouldWorkCorrectly() throws Exception {
        var departmentId = departmentRepository.findAll().get(0).getId();

        var resultActions = mockMvc
                .perform(get("/api/department/" + departmentId).contentType(MediaType.APPLICATION_JSON))
                .andExpect(status().isOk());

        var result = resultActions.andReturn();
        var contentAsString = result.getResponse().getContentAsString();
        var actual = objectMapper.readValue(contentAsString, new TypeReference<DepartmentViewModel>() {
        });

        var expected = modelMapper.map(this.departments.get(0), DepartmentViewModel.class);

        assertThat(actual).isEqualTo(expected);
    }

    @Test
    void getByIdShouldReturnAnErrorIfNotFound() throws Exception {
        var resultActions = mockMvc
                .perform(get("/api/department/10000").contentType(MediaType.APPLICATION_JSON))
                .andExpect(status().isNotFound());

        var result = resultActions.andReturn();
        var contentAsString = result.getResponse().getContentAsString();

        assertThat(contentAsString).isEmpty();
    }

    @Test
    void deleteShouldWorkCorrectly() throws Exception {
        var departmentId = departmentRepository.findAll().get(0).getId();

        var resultActions = mockMvc
                .perform(delete("/api/department/" + departmentId).contentType(MediaType.APPLICATION_JSON))
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
                .perform(delete("/api/department/10").contentType(MediaType.APPLICATION_JSON))
                .andExpect(status().isNotFound());

        var result = resultActions.andReturn();
        var actual = result.getResponse().getContentAsString();

        assertThat(actual).isEmpty();
    }
}