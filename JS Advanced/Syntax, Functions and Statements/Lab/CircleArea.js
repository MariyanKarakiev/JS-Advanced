function solve(radius) {

    let S = Math.PI * (radius ** 2);
   
    if(typeof(radius)=='number'){
    console.log(S.toFixed(2));
    }

    else{
        console.log(`We can not calculate the circle area, because we receive a ${typeof(radius)}.`)
    }
}

solve('name');