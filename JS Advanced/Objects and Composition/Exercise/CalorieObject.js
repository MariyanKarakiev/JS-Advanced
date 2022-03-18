function solve(input){
    let resultObjs = {};

    for(let i = 0; i<input.length; i+=2){
        resultObjs[input[i]] = Number(input[i+1]);
    }

    return resultObjs;
}

console.log(solve(['name','89', 'idiot','90']));