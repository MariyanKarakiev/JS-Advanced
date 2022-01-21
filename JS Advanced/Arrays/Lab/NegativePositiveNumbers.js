function solve(arr) {

    let numbersToPrint = [];

    arr.forEach(element => {
        if (element < 0) {
            numbersToPrint.unshift(element);
        }
        else {
            numbersToPrint.push(element);
        }
    });

    numbersToPrint.forEach(element => {console.log(element)});
}

solve([3, -2, 0, -1]);