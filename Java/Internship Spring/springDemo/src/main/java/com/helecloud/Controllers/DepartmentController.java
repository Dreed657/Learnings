package com.helecloud.Controllers;

import com.helecloud.Dto.Department.DepartmentInputModel;
import com.helecloud.Dto.Department.DepartmentViewModel;
import com.helecloud.Services.Department.DepartmentService;
import lombok.AllArgsConstructor;
import lombok.extern.log4j.Log4j2;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import javax.validation.Valid;
import java.util.List;

@Log4j2
@RestController
@AllArgsConstructor
@RequestMapping("api/department")
public class DepartmentController {

    private final DepartmentService service;

    @GetMapping("/")
    public ResponseEntity<List<DepartmentViewModel>> getAll() {
        return ResponseEntity.ok().body(service.getAll());
    }

    @GetMapping("/{id}")
    public ResponseEntity<DepartmentViewModel> getById(@PathVariable Integer id) {
        try {
            return ResponseEntity.ok().body(service.getById(id));
        } catch (RuntimeException e) {
            return ResponseEntity.notFound().build();
        }
    }

    @PostMapping("/")
    public ResponseEntity<DepartmentViewModel> create(@Valid @RequestBody DepartmentInputModel entity) {
        return ResponseEntity.ok().body(service.save(entity));
    }

    @PostMapping("/{id}")
    public ResponseEntity<DepartmentViewModel> update(@PathVariable Integer id, @Valid @RequestBody DepartmentInputModel entity) {
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
