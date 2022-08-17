function solve(array) {

    let result = [];
    array.sort((a, b) => a - b);

    for (let i = 0; i < array.length; i++) {
        result.push(array.shift());
        result.push(array.pop());
    }
    return result.concat(array) ;
}

console.log(solve([1,
    65,
    3,
    52,
    48,
    63,
    31,
    -3,
    18,
    56]));