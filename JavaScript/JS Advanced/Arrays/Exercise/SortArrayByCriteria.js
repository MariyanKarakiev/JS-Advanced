function solve(array) {
    array.sort(function compare(a, b) {
        if (a.length - b.length !== 0) {
            return a.length - b.length;
        }
        else {
            return a.toLowerCase().localeCompare(b.toLowerCase());
        }
    });

    array.forEach(x => {
        console.log(x);
    });
}

solve(['alpha',
    'beta',
    'gamma'])