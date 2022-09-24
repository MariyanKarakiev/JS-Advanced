function findPairs(mtrx) {

    let countOfPairs = 0;

    for (let i = 0; i <= mtrx.length - 1; i++) {
        for (let j = 0; j <= mtrx[0].length - 1; j++) {

            function checkForPair(i, j, mtrx) {

                let plusRow = (mtrx.length-1 == i) ? 0 : 1;
                let plusColl = (mtrx[0].length-1 == j) ? 0 : 1;

             
                if (mtrx[i][j] === mtrx[i + plusRow][j + plusColl]
                    || mtrx[i][j] === mtrx[i][j + plusColl]
                    || mtrx[i][j] === mtrx[i + plusRow][j]) {
                    return true;
                }
            }

            if (checkForPair(i, j, mtrx)) {
                countOfPairs++;
                console.log(i, j);
            }
        }
    }

    console.log(countOfPairs);
}

findPairs([['2', '2', '5', '7', '4'],
['4', '0', '5', '3', '4'],
['2', '5', '5', '4', '2']])
