package com.helecloud.Services.Employee;

import com.github.javafaker.Faker;
import com.helecloud.Dto.Department.DepartmentViewModel;
import com.helecloud.Dto.Employee.EmployeeInputModel;
import com.helecloud.Dto.Employee.EmployeeViewModel;
import com.helecloud.Models.Department;
import com.helecloud.Models.Employee;
import com.helecloud.Repositories.DepartmentRepository;
import com.helecloud.Repositories.EmployeeRepository;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;
import org.mockito.Mock;
import org.mockito.Mockito;
import org.modelmapper.ModelMapper;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.context.SpringBootTest;

import java.math.BigDecimal;
import java.util.List;
import java.util.Optional;
import java.util.stream.Collectors;

import static org.assertj.core.api.AssertionsForClassTypes.assertThat;
import static org.assertj.core.api.AssertionsForClassTypes.assertThatThrownBy;

@SpringBootTest
class EmployeeServiceImplTest {

    private final EmployeeRepository employeeRepository;

    private final DepartmentRepository departmentRepository;

    private final EmployeeService employeeService;

    private final ModelMapper modelMapper = new ModelMapper();

    private final Faker faker = new Faker();

    private final Department department = new Department(faker.name().title());

    private final List<Employee> employees = List.of(
            new Employee(1, faker.name().name(), new BigDecimal(faker.number().randomNumber()), department),
            new Employee(2, faker.name().name(), new BigDecimal(faker.number().randomNumber()), department),
            new Employee(3, faker.name().name(), new BigDecimal(faker.number().randomNumber()), department)
    );

    public EmployeeServiceImplTest() {
        this.employeeRepository = Mockito.mock(EmployeeRepository.class);
        this.departmentRepository = Mockito.mock(DepartmentRepository.class);

        Mockito.when(employeeRepository.findAll()).thenReturn(employees);
        Mockito.when(employeeRepository.findById(Mockito.any())).thenReturn(Optional.of(employees.get(0)));
        Mockito.when(employeeRepository.findById(10)).thenThrow(new RuntimeException("Employee was not found!"));
        Mockito.when(employeeRepository.save(Mockito.any())).thenReturn(employees.get(0));

        Mockito.when(departmentRepository.findAll()).thenReturn(List.of(department));
        Mockito.when(departmentRepository.findById(department.getId())).thenReturn(Optional.of(department));
        Mockito.when(departmentRepository.save(Mockito.any())).thenReturn(department);

        this.employeeService = new EmployeeServiceImpl(employeeRepository, departmentRepository, modelMapper);
    }

    @Test
    void getAll() {
        // Act
        var expected = this.employees
                .stream()
                .map(c -> modelMapper.map(c, EmployeeViewModel.class))
                .collect(Collectors.toList());

        var actual = employeeService.getAll();

        // Assert
        assertThat(actual.size()).isEqualTo(expected.size());
        assertThat(actual).isEqualTo(expected);
    }

    @Test
    void getById() {
        var employeeId = employeeRepository.findAll().get(0).getId();

        var expected = modelMapper.map(this.employees.get(0), EmployeeViewModel.class);
        var actual = employeeService.getById(employeeId);

        assertThat(actual).isEqualTo(expected);
    }

    @Test
    void getByIdShouldThrowAnErrorIfCarNotFound() {
        assertThatThrownBy(() -> {
            employeeService.getById(10);
        }).isInstanceOf(RuntimeException.class)
                .hasMessageContaining("Employee was not found!");
    }

    @Test
    void save() {
        var dept = departmentRepository.findAll().get(0);
        var input = new EmployeeInputModel(employees.get(0).getName(), employees.get(0).getSal(), employees.get(0).getDept().getId());

        var output = employeeService.save(input);

        var expected = new Employee(input.getName(), input.getSal(), dept);
        var actual = new Employee(output.getName(), output.getSal(), dept);

        assertThat(actual.getName()).isEqualTo(expected.getName());
        assertThat(actual.getSal()).isEqualTo(expected.getSal());
        assertThat(actual.getDept()).isEqualTo(expected.getDept());
    }

    @Test
    void update() {
        var employeeId = employeeRepository.findAll().get(0).getId();
        var dept = departmentRepository.findAll().get(0);

        var updateModel = new EmployeeInputModel("Random", new BigDecimal(50000), dept.getId());
        var actual = employeeService.update(employeeId, updateModel);

        var expected = new EmployeeViewModel("Random", new BigDecimal(50000), modelMapper.map(dept, DepartmentViewModel.class));

        assertThat(actual).isEqualTo(expected);
    }

    @Test
    void deleteShouldWorkCorrectly() {
        var employeeId = employeeRepository.findAll().get(0).getId();

        var before = employeeService.getById(employeeId);
        employeeService.delete(employeeId);

        assertThat(before).isNotNull();
    }
}