package com.helecloud.Services.Car;

import com.helecloud.Dto.Car.CarInputModel;
import com.helecloud.Dto.Car.CarViewModel;
import com.helecloud.Models.Car;
import com.helecloud.Repositories.CarRepository;
import lombok.RequiredArgsConstructor;
import org.modelmapper.ModelMapper;
import org.springframework.stereotype.Service;

import javax.transaction.Transactional;
import java.util.List;
import java.util.stream.Collectors;

@Service
@RequiredArgsConstructor
public class CarServiceImpl implements CarService {

    private final CarRepository carRepository;
    private final ModelMapper mapper;

    @Override
    public List<CarViewModel> getAll() {
        return carRepository.findAll()
                .stream()
                .map(e -> mapper.map(e, CarViewModel.class))
                .collect(Collectors.toList());
    }

    @Override
    public CarViewModel getById(Integer id) {
        var result = carRepository.findById(id);
        var entity = result.orElseThrow(() -> new RuntimeException("Car was not found!"));

        return mapper.map(entity, CarViewModel.class);
    }

    @Override
    public CarViewModel save(CarInputModel inputModel) {
        var entity = new Car(inputModel.getMake(), inputModel.getModel(), inputModel.getYear());
        var result = carRepository.save(entity);

        return mapper.map(result, CarViewModel.class);
    }

    @Override
    public CarViewModel update(Integer id, CarInputModel inputModel) {
        var result = carRepository.findById(id);
        var entity = result.orElseThrow(() -> new RuntimeException("Car was not found!"));

        entity.setMake(inputModel.getMake());
        entity.setModel(inputModel.getModel());
        entity.setYear(inputModel.getYear());

        carRepository.save(entity);

        return mapper.map(entity, CarViewModel.class);
    }

    @Override
    public void delete(Integer id) {
        carRepository.deleteById(id);
    }
}
