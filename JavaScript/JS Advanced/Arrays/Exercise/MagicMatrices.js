function solve(array) {
    let result = false;
    let sum = 0;

    
    
    array.reduce((acc, curr) => {

        let sum = (a, b) => a + b;

        if (acc.reduce(sum) != curr.reduce(sum)) {
            console.log(acc.reduce(sum) + '-' + curr.reduce(sum));
            console.log(result = false);
        }

        console.log(result = true);
        return curr;
    })

    console.log(result);
}
solve([[4, 5, 6],
[6, 5, 4],
[5, 5, 5]])