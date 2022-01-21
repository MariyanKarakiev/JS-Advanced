//solving the problem with just one line of code for fun :)

function solve(arr) {
    return arr.sort((a, b) => a - b).slice(arr.length / 2 , arr.length);
}

console.log(solve([ 19, 14, 7, 2, 19, 6]));