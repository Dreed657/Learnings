package com.helecloud.Services.Employee;

import com.helecloud.Dto.Car.CarViewModel;
import com.helecloud.Dto.Employee.EmployeeInputModel;
import com.helecloud.Dto.Employee.EmployeeViewModel;
import com.helecloud.Models.Car;
import com.helecloud.Models.Employee;
import com.helecloud.Repositories.DepartmentRepository;
import com.helecloud.Repositories.EmployeeRepository;
import lombok.RequiredArgsConstructor;
import org.modelmapper.ModelMapper;
import org.springframework.stereotype.Service;

import java.util.List;
import java.util.stream.Collectors;

@Service
@RequiredArgsConstructor
public class EmployeeServiceImpl implements EmployeeService {

    private final EmployeeRepository employeeRepository;
    private final DepartmentRepository departmentRepository;
    private final ModelMapper mapper;

    @Override
    public List<EmployeeViewModel> getAll() {
        return employeeRepository.findAll()
                .stream()
                .map(e -> mapper.map(e, EmployeeViewModel.class))
                .collect(Collectors.toList());
    }

    @Override
    public EmployeeViewModel getById(Integer id) {
        var result = employeeRepository.findById(id);
        var entity = result.orElseThrow(() -> new RuntimeException("Employee was not found!"));

        return mapper.map(entity, EmployeeViewModel.class);
    }

    @Override
    public EmployeeViewModel save(EmployeeInputModel inputModel) {
        var departmentEntity = departmentRepository.findById(inputModel.getDeptId());
        var department = departmentEntity.orElseThrow(() -> new RuntimeException("Department was not found!"));

        var entity = new Employee(inputModel.getName(), inputModel.getSal(), department);
        var result = employeeRepository.save(entity);

        return mapper.map(result, EmployeeViewModel.class);
    }

    @Override
    public EmployeeViewModel update(Integer id, EmployeeInputModel inputModel) {
        var result = employeeRepository.findById(id);
        var entity = result.orElseThrow(() -> new RuntimeException("Car was not found!"));

        var departmentEntity = departmentRepository.findById(inputModel.getDeptId());
        var department = departmentEntity.orElseThrow(() -> new RuntimeException("Department was not found!"));

        entity.setName(inputModel.getName());
        entity.setSal(inputModel.getSal());
        entity.setDept(department);

        employeeRepository.save(entity);

        return mapper.map(entity, EmployeeViewModel.class);
    }

    @Override
    public void delete(Integer id) {
        employeeRepository.deleteById(id);
    }
}
