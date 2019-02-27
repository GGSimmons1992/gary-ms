import { CanDrive } from "./interfaces";

//classes creates blueprint
//in angular classes are used for:
//components, directives, pipes, and others

class Car implements CanDrive{
    
    //fields
    engineName:string;
    gears:number;
    //^^^^----public by default
    //vvvv----access modifier
    private speed:number;

    constructor(speed:number){
        this.speed = speed || 0 ;
    }
    
    accelerate():void {
        this.speed++
    }

    getSpeed():number {
        return this.speed
    }

    setSpeed(speed: number){
        this.speed = speed;
    }

    static numberOfWheels():number{
        return 4;
    }

}

let car = new Car(55);
car.accelerate();
car.getSpeed();
console.log(Car.numberOfWheels());