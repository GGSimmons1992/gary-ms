//Interfaces are contracts for other classes and objects
//Can be used to define custom types without creating a class
interface User {
    username:string,
    password: string;
    confirmPassword?: string;
    //^^^^^-----optional field
}

let user:User;
//valid instantiation of user
user={username:'bob',password:'bobbert'};

user = {username:'BObby',password:'bobieta',confirmPassword:'bobieta'};

export interface CanDrive{
    accelerate(speed:number):void;
}