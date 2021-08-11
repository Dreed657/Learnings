package com.helecloud.Services.Department;

import com.github.javafaker.Faker;
import com.helecloud.Dto.Car.CarInputModel;
import com.helecloud.Dto.Car.CarViewModel;
import com.helecloud.Dto.Department.DepartmentInputModel;
import com.helecloud.Dto.Department.DepartmentViewModel;
import com.helecloud.Models.Book;
import com.helecloud.Models.Car;
import com.helecloud.Models.Department;
import com.helecloud.Repositories.CarRepository;
import com.helecloud.Repositories.DepartmentRepository;
import com.helecloud.Services.Car.CarService;
import org.junit.jupiter.api.AfterEach;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;
import org.modelmapper.ModelMapper;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.context.SpringBootTest;

import java.util.List;
import java.util.stream.Collectors;

import static org.assertj.core.api.AssertionsForClassTypes.assertThat;
import static org.assertj.core.api.AssertionsForClassTypes.assertThatThrownBy;
import static org.junit.jupiter.api.Assertions.*;

@SpringBootTest
class DepartmentServiceImplTest {

    @Autowired
    private DepartmentRepository departmentRepository;

    @Autowired
    private DepartmentService departmentService;

    @Autowired
    private ModelMapper modelMapper;

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
    void getAll() {
        // Act
        var expected = this.departments
                .stream()
                .map(c -> modelMapper.map(c, DepartmentViewModel.class))
                .collect(Collectors.toList());

        var actual = departmentService.getAll();

        // Assert
        assertThat(actual.size()).isEqualTo(expected.size());
        assertThat(actual).isEqualTo(expected);
    }

    @Test
    void getById() {
        var departmentId = departmentRepository.findAll().get(0).getId();

        var expected = modelMapper.map(this.departments.get(0), DepartmentViewModel.class);
        var actual = departmentService.getById(departmentId);

        assertThat(actual).isEqualTo(expected);
    }

    @Test
    void getByIdShouldThrowAnErrorIfCarNotFound() {
        assertThatThrownBy(() -> {
            departmentService.getById(10);
        }).isInstanceOf(RuntimeException.class)
                .hasMessageContaining("Department was not found!");
    }

    @Test
    void save() {
        var input = new DepartmentInputModel(faker.name().title());

        var output = departmentService.save(input);

        var expected = new Department(input.getName());
        var actual = new Department(output.getName());

        assertThat(actual.getName()).isEqualTo(expected.getName());
    }

    @Test
    void update() {
        var departmentId = departmentRepository.findAll().get(0).getId();

        var updateModel = new DepartmentInputModel("Random");
        var actual = departmentService.update(departmentId, updateModel);

        var expected = new DepartmentViewModel("Random");

        assertThat(actual).isEqualTo(expected);
    }

    @Test
    void deleteShouldWorkCorrectly() {
        var departmentId = departmentRepository.findAll().get(0).getId();

        var before = departmentService.getById(departmentId);
        departmentService.delete(departmentId);

        assertThat(before).isNotNull();
        assertThatThrownBy(() -> {
            departmentService.getById(departmentId);
        }).isInstanceOf(RuntimeException.class)
                .hasMessageContaining("Department was not found!");
    }
}