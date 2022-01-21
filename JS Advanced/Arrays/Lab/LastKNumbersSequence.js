function solve(n, k) {
    let arr = [1];

    for (let i = 1; i < n; i++) {
        let numberToPush = 0;

    for (let j = i - k ; j != i; j++) {
            numberToPush += arr[j] || 0;
        }

        arr.push(numberToPush)
    }

    return arr;
}

console.log(solve(6, 3));
