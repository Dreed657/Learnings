package com.helecloud.Services.Car;

import com.helecloud.Dto.Car.CarInputModel;
import com.helecloud.Dto.Car.CarViewModel;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public interface CarService {
    List<CarViewModel> getAll();
    CarViewModel getById(Integer id);
    CarViewModel save(CarInputModel inputModel);
    CarViewModel update(Integer id, CarInputModel inputModel);
    void delete(Integer id);
}
