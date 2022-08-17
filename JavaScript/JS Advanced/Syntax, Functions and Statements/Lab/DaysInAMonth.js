function solve(month,year){  

    let date = new Date(year,month,0);

    let days = date.getDate();

    console.log(days);
}

solve(1,2012);

