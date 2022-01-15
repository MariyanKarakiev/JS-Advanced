function calculate(steps, lengthOfFoot, speed) {
    let distanceToSchool = steps * lengthOfFoot;
    let speedInMeters = speed * 1000 / 3600;
    let brakes = Math.floor(distanceToSchool / 500) * 60;
    let time = (distanceToSchool / speedInMeters) + brakes;

    let hours = Math.floor(time / 3600).toFixed(0).padStart(2, '0');
    let minutes = Math.floor(time / 60).toFixed(0).padStart(2, '0');
    let seconds = (time % 60).toFixed(0).padStart(2, '0');
    console.log(hours + ':' + minutes + ':' + seconds);
}
calculate(2564, 0.70, 5.5);
