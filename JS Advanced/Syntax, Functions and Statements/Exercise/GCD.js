function solve(x, y) {

    if (typeof (x) !== 'number' || typeof (y) !== "number") {
        console.log('invalid');
    }

    while (y) {
        let z = y;
        y = x % y;
        x = z;
    }
console.log(x);
}

solve(48, 18);