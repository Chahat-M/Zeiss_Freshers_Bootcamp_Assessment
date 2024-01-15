#include <iostream>

using namespace std;

class FuelPump{
public:
    virtual void pumpFuel() = 0;
};

class StartUpMotor{
public:
    virtual void start() = 0;
};

class Engine{
private:
    StartUpMotor* startUpMotorobj;
    FuelPump* fuelPumpobj;

public:
    Engine(StartUpMotor* motor, FuelPump* pump) : startUpMotorobj(motor), fuelPumpobj(pump) {}

    void startEngine() {
        startUpMotorobj->start();
        fuelPumpobj->pumpFuel();
    }

};

class Transmission{
public:
    virtual void shift() = 0;
}

class CarEngine : public Engine {
public:
    CarEngine(StartUpMotor* motor, FuelPump* pump) : Engine(motor, pump) {}

    void drive() {}
};

class AutomaticTransmission : public Transmission {
public:
    void shift() override {}
};

class Car {
private:
    CarEngine* engine;
    Transmission* transmission;

public:
    Car(CarEngine* carEngine, Transmission* carTransmission)
        : engine(carEngine), transmission(carTransmission) {}

    void startCar() {
        engine->startEngine();
    }

    void driveCar() {
        engine->drive();
        transmission->shift();
    }
};
