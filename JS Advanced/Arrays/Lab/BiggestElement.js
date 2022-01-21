function solve(matrix){
    let rowsMax = matrix.map(x=>Math.max.apply(Math, x));

    return Math.max(...rowsMax);
}

console.log(solve([[3, 5, 7, 12],
    [-1, 4, 33, 2],
    [8, 3, 0, 4]]));