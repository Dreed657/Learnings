package com.helecloud.Services.Department;

import com.helecloud.Dto.Department.DepartmentInputModel;
import com.helecloud.Dto.Department.DepartmentViewModel;
import com.helecloud.Models.Department;
import com.helecloud.Repositories.DepartmentRepository;
import lombok.RequiredArgsConstructor;
import org.modelmapper.ModelMapper;
import org.springframework.stereotype.Service;

import java.util.List;
import java.util.stream.Collectors;

@Service
@RequiredArgsConstructor
public class DepartmentServiceImpl implements DepartmentService{

    private final DepartmentRepository departmentRepository;
    private final ModelMapper mapper;

    @Override
    public List<DepartmentViewModel> getAll() {
        return departmentRepository.findAll()
                .stream()
                .map(e -> mapper.map(e, DepartmentViewModel.class))
                .collect(Collectors.toList());
    }

    @Override
    public DepartmentViewModel getById(Integer id) {
        var result = departmentRepository.findById(id);
        var entity = result.orElseThrow(() -> new RuntimeException("Department was not found!"));

        return mapper.map(entity, DepartmentViewModel.class);
    }

    @Override
    public DepartmentViewModel save(DepartmentInputModel inputModel) {
        var entity = new Department(inputModel.getName());
        var result = departmentRepository.save(entity);

        return mapper.map(result, DepartmentViewModel.class);
    }

    @Override
    public DepartmentViewModel update(Integer id, DepartmentInputModel inputModel) {
        var result = departmentRepository.findById(id);
        var entity = result.orElseThrow(() -> new RuntimeException("Department was not found!"));

        entity.setName(inputModel.getName());

        departmentRepository.save(entity);

        return mapper.map(entity, DepartmentViewModel.class);
    }

    @Override
    public void delete(Integer id) {
        departmentRepository.deleteById(id);
    }
}
