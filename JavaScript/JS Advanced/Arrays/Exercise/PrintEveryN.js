function print(array, n) {

    let outputArray = [];

    for (let i = 0; i < array.length; i += n) {
        outputArray.push(array[i]);
    }
    return outputArray;
}
console.log(print(['5',
    '20',
    '31',
    '4',
    '20'], 2,
))