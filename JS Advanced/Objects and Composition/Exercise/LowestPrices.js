function solve(input) {
    let products = [];

    input.forEach(line => {
        let [town, product, price] = line.split(' | ');

        let obj = products.find(p => p.product === product);

        if (!Boolean(obj)) {
            products.push({ town, product, price: Number(price)});
        }

        else {
            if (obj.price > price) {
                obj.price = Number(price);
                obj.town = town;
            }
        }
    });

    products.forEach(p => console.log(`${p.product} -> ${p.price} (${p.town})`));
}

solve(['Sample Town | Sample Product | 1000',
    'Sample Town | Orange | 2',
    'Sample Town | Peach | 1',
    'Sofia | Orange | 3',
    'Sofia | Peach | 2',
    'New York | Sample Product | 1000.1',
    'New York | Burger | 10'])


solve(['Sofia City | Audi | 100000',
    'Sofia City | BMW | 100000',
    'Sofia City | Mitsubishi | 10000',
    'Sofia City | Mercedes | 10000',
    'Sofia City | NoOffenseToCarLovers | 0',
    'Mexico City | Audi | 1000',
    'Mexico City | BMW | 99999',
    'Mexico City | Mitsubishi | 10000',
    'New York City | Mitsubishi | 1000',
    'Washington City | Mercedes | 1000'])