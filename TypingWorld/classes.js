//classes creates blueprint
//in angular classes are used for:
//components, directives, pipes, and others
class Car {
    constructor(speed) {
        this.speed = speed || 0;
    }
    accelerate() {
        this.speed++;
    }
    getSpeed() {
        return this.speed;
    }
    setSpeed(speed) {
        this.speed = speed;
    }
    static numberOfWheels() {
        return 4;
    }
}
let car = new Car(55);
car.accelerate();
car.getSpeed();
console.log(Car.numberOfWheels());
