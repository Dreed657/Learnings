package com.helecloud.Services.Employee;

import com.helecloud.Dto.Employee.EmployeeInputModel;
import com.helecloud.Dto.Employee.EmployeeViewModel;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public interface EmployeeService {
    List<EmployeeViewModel> getAll();
    EmployeeViewModel getById(Integer id);
    EmployeeViewModel save(EmployeeInputModel inputModel);
    EmployeeViewModel update(Integer id, EmployeeInputModel inputModel);
    void delete(Integer id);
}
