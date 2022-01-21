function solve(matrix) {
    let sumOfDiagonal1 = 0;
    let sumOfDiagonal2 = 0;

    for (let i = 0; i < matrix.length; i++) {
        sumOfDiagonal1 += matrix[i][i];
    }

    for (let i = matrix.length - 1; i >= 0; i--) {
        sumOfDiagonal2 += matrix[i][matrix.length - 1 - i];
    }

    console.log(sumOfDiagonal1 + ' ' + sumOfDiagonal2);
}
solve([[20, 40],
    [10, 60]]);