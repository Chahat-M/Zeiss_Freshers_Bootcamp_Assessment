#include <iostream>
#include <boost/di.hpp>

using namespace std;

class IFuelPump{
public:
    virtual void pumpFuel() = 0;
};

class FuelPump : public IFuelPump{
public:
    void pumpfuel() override{
        // some code
    }
}

class IStartUpMotor{
public:
    virtual void start() = 0;
};

class StartUpMotor : public IStartUpMotor{
    void start() override{
        // some code
    }
}

class IEngine {
public:
    virtual void startEngine() = 0;
};

class Engine : public IEngine{
private:
    IStartUpMotor* startUpMotorobj;
    IFuelPump* fuelPumpobj;

public:
    Engine(IStartUpMotor* motor, IFuelPump* pump) : startUpMotorobj(motor), fuelPumpobj(pump) {}

    void startEngine() {
        startUpMotorobj->start();
        fuelPumpobj->pumpFuel();
    }

};

class ITransmission{
public:
    virtual void shift() = 0;
}

class Transmission : public ITransmission{
public:
    void shift() override{
        // some code
    }
}

class Car : public IEngine, public ITransmission {
private:
    IEngine* engine;
    ITransmission* transmission;

public:
    Car(IEngine* carEngine, ITransmission* carTransmission)
        : engine(carEngine), transmission(carTransmission) {}

    void startCar() {
        engine->startEngine();
    }

    void driveCar() {
        engine->drive();
        transmission->shift();
    }
};

int main()
{   
    auto injector = boost::di::make_injector(
        boost::di::bind<IStartUpMotor>().to<StartUpMotor>(),
        boost::di::bind<IFuelPump>().to<FuelPump>(),
        boost::di::bind<IEngine>().to<Engine>(),
        boost::di::bind<ITransmission>().to<Transmission>()
    );
    
    auto carEngine = injector.create<IEngine>();
    auto trans = injector.create<ITransmission>();

    Car myCar(*carEngine, *trans);
    myCar.startEngine();
    myCar.drive();
    return 0;
}
