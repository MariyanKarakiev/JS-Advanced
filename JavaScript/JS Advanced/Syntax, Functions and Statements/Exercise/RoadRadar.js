function evaluateSpeeding(speed, area) {

    let limit = Number();

    switch (area) {
        
        case 'motorway':
            limit = 130;
            break;

        case 'interstate':
            limit = 90;
            break;

        case 'city':
            limit = 50;
            break;

        case 'residential':
            limit = 20;
            break;
    }

    if (speed <= limit) {
        console.log(`Driving ${speed} km/h in a ${limit} zone`)
    }
    else {

        let differenceInspeed = speed - limit;
        let status = String();

        if (differenceInspeed <= 20) status = 'speeding';
        else if (differenceInspeed <= 40) status = 'excessive speeding';
        else status = 'reckless driving';

        console.log(`The speed is ${differenceInspeed} km/h faster than the allowed speed of ${limit} - ${status}`)
    }
}

evaluateSpeeding(120, 'interstate')