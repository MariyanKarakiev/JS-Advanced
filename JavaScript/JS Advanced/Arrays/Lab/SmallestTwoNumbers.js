function solve(arr) {
    arr = arr.sort((a, b) => a - b);

    let smallestNumbers = arr.length >= 2 ? arr[0].toString() + ' ' + arr[1].toString() : arr[0];

    console.log(smallestNumbers);
}

solve([30]);