function solve(input) {

    let towns = {};

    input.forEach(x => {       
       let [name,populationText] = x.split(' <-> ');
       let population = Number(populationText);
       
       if (!towns[name]) {
            towns[name] = 0;
        }

        towns[name] += population;
    });

    for(const name in towns){
        console.log(`${name} : ${towns[name]}`);
    }
}

solve(['Sofia <-> 1200000',
    'Montana <-> 20000',
    'New York <-> 10000000',
    'Washington <-> 2345000',
    'Las Vegas <-> 1000000'])