package com.helecloud.Services.Car;

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
import org.springframework.boot.test.context.SpringBootTest;

import java.util.List;
import java.util.stream.Collectors;

import static org.assertj.core.api.AssertionsForClassTypes.assertThat;
import static org.assertj.core.api.AssertionsForClassTypes.assertThatThrownBy;

@SpringBootTest
class CarServiceImplTest {

    @Autowired
    private CarRepository carRepository;

    @Autowired
    private CarService carService;

    @Autowired
    private ModelMapper modelMapper;

    private final Faker faker = new Faker();

    private final List<Car> cars = List.of(
            new Car(1, faker.aviation().airport(), faker.aviation().airport(), 2000),
            new Car(2, faker.aviation().airport(), faker.aviation().airport(), 2000),
            new Car(3, faker.aviation().airport(), faker.aviation().airport(), 2000)
    );

    @BeforeEach
    void setUp() {
        carRepository.saveAll(cars);
    }

    @AfterEach
    void tearDown() {
        carRepository.deleteAll(carRepository.findAll());
    }

    @Test
    void getAll() {
        // Act
        var expected = this.cars
                .stream()
                .map(c -> modelMapper.map(c, CarViewModel.class))
                .collect(Collectors.toList());

        var actual = carService.getAll();

        // Assert
        assertThat(actual.size()).isEqualTo(expected.size());
        assertThat(actual).isEqualTo(expected);
    }

    @Test
    void getById() {
        var carId = carRepository.findAll().get(0).getId();

        var expected = modelMapper.map(this.cars.get(0), CarViewModel.class);
        var actual = carService.getById(carId);

        assertThat(actual).isEqualTo(expected);
    }

    @Test
    void getByIdShouldThrowAnErrorIfCarNotFound() {
        assertThatThrownBy(() -> {
            carService.getById(10);
        }).isInstanceOf(RuntimeException.class)
                .hasMessageContaining("Car was not found!");
    }

    @Test
    void save() {
        var input = new CarInputModel(faker.aviation().airport(), faker.aviation().airport(), 2000);

        var output = carService.save(input);

        var expected = new Car(input.getMake(), input.getModel(), input.getYear());
        var actual = new Car(output.getMake(), output.getModel(), output.getYear());

        assertThat(actual.getMake()).isEqualTo(expected.getMake());
        assertThat(actual.getModel()).isEqualTo(expected.getModel());
        assertThat(actual.getYear()).isEqualTo(expected.getYear());
    }

    @Test
    void update() {
        var carId = carRepository.findAll().get(0).getId();

        var updateModel = new CarInputModel("Random", "Random2", 2000);
        var actual = carService.update(carId, updateModel);

        var expected = new CarViewModel("Random", "Random2", 2000);

        assertThat(actual).isEqualTo(expected);
    }

    @Test
    void deleteShouldWorkCorrectly() {
        var carId = carRepository.findAll().get(0).getId();

        var before = carService.getById(carId);
        carService.delete(carId);

        assertThat(before).isNotNull();
        assertThatThrownBy(() -> {
            carService.getById(carId);
        }).isInstanceOf(RuntimeException.class)
                .hasMessageContaining("Car was not found!");
    }
}