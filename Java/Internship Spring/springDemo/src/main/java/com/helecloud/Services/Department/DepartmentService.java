package com.helecloud.Services.Department;

import com.helecloud.Dto.Department.DepartmentInputModel;
import com.helecloud.Dto.Department.DepartmentViewModel;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public interface DepartmentService {
    List<DepartmentViewModel> getAll();
    DepartmentViewModel getById(Integer id);
    DepartmentViewModel save(DepartmentInputModel inputModel);
    DepartmentViewModel update(Integer id, DepartmentInputModel inputModel);
    void delete(Integer id);
}
