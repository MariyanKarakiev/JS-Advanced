function factory(requirements) {
    let car = {};

    car.model = requirements.model;

    if (requirements.power <= 90) {
        car.engine = {
            power: 90,
            volume: 1800
        };
    }
    else if (requirements.power <= 120) {
        car.engine = {
            power: 120,
            volume: 2400
        };
    }
    else if (requirements.power <= 200) {
        car.engine = {
            power: 200,
            volume: 3500
        };
    }

    if (requirements.carriage == 'hatchback') {
        car.carriage = {
            type: 'hatchback',
            color: requirements.color
        };
    }
    else if (requirements.carriage == 'coupe') {
        car.carriage = {
            type: 'coupe',
            color: requirements.color
        };
    }

    if (requirements.wheelsize % 2 === 0) {
        requirements.wheelsize--;
    }
    
        car.wheels = [requirements.wheelsize,
        requirements.wheelsize,
        requirements.wheelsize,
        requirements.wheelsize]

    return car;
}

console.log(factory({
   model:'Opel Vectra',
power: 110,
color:'grey',
carriage:'coupe',
wheelsize: 17 
}));