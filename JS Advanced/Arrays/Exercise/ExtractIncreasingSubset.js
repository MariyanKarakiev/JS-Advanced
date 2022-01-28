//for some reason judge`s test#4 is not recieving output successfully

function solve(array) {
    if (array.length != 0) {

        let result = [array[0]];

        array.reduce((currentNum, nextNum) => {
            if (nextNum > result[result.length - 1]) {
                result.push(nextNum);
            }
            return nextNum;
        })
        return result;
    }
    else {
        return [0];
    }
}

console.log(solve([1,
    3,
    8,
    4,
    10,
    12,
    3,
    2,
    24]));

console.log(solve([1,
    2,
    3,
    4]));

console.log(solve([]));