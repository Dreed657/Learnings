package com.helecloud.Controllers;

import com.helecloud.Dto.Car.CarInputModel;
import com.helecloud.Dto.Car.CarViewModel;
import com.helecloud.Services.Car.CarService;
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
@RequestMapping("api/car")
public class CarController {

    private final CarService service;

    @GetMapping("/")
    public ResponseEntity<List<CarViewModel>> getAll() {
        return ResponseEntity.ok().body(service.getAll());
    }

    @GetMapping("/{id}")
    public ResponseEntity<CarViewModel> getById(@PathVariable Integer id) {
        try {
            var result = service.getById(id);
            return ResponseEntity.ok().body(result);
        } catch (RuntimeException e) {
            return ResponseEntity.notFound().build();
        }
    }

    @PostMapping("/")
    public ResponseEntity<CarViewModel> create(@Valid @RequestBody CarInputModel entity) {
        return ResponseEntity.ok().body(service.save(entity));
    }

    @PostMapping("/{id}")
    public ResponseEntity<CarViewModel> update(@PathVariable Integer id, @Valid @RequestBody CarInputModel entity) {
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
