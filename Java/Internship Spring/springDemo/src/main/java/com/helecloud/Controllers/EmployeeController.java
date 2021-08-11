package com.helecloud.Controllers;

import com.helecloud.Dto.Employee.EmployeeInputModel;
import com.helecloud.Dto.Employee.EmployeeViewModel;
import com.helecloud.Services.Employee.EmployeeService;
import lombok.AllArgsConstructor;
import lombok.extern.log4j.Log4j2;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import javax.validation.Valid;
import java.util.List;

@Log4j2
@RestController
@AllArgsConstructor
@RequestMapping("api/employee")
public class EmployeeController {

    private final EmployeeService service;

    @GetMapping("/")
    public ResponseEntity<List<EmployeeViewModel>> getAll() {
        return ResponseEntity.ok().body(service.getAll());
    }

    @GetMapping("/{id}")
    public ResponseEntity<EmployeeViewModel> getById(@PathVariable Integer id) {
        try {
            return ResponseEntity.ok().body(service.getById(id));
        } catch (RuntimeException e) {
            return ResponseEntity.notFound().build();
        }
    }

    @PostMapping("/")
    public ResponseEntity<EmployeeViewModel> create(@Valid @RequestBody EmployeeInputModel entity) {
        return ResponseEntity.ok().body(service.save(entity));
    }

    @PostMapping("/{id}")
    public ResponseEntity<EmployeeViewModel> update(@PathVariable Integer id, @Valid @RequestBody EmployeeInputModel entity) {
        try {
            var result = service.update(id, entity);
            return ResponseEntity.ok().body(result);
        } catch (RuntimeException e) {
            return ResponseEntity.notFound().build();
        }
    }

    @DeleteMapping("/{id}")
    public ResponseEntity<Boolean> delete(@PathVariable Integer id) {
        try {
            service.getById(id);
            service.delete(id);

            return ResponseEntity.ok(true);
        } catch (RuntimeException e) {
            return ResponseEntity.notFound().build();
        }
    }
}
