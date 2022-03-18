function solve(input) {

    let letters = [];
    
    input.sort((a,b) => a.localeCompare(b));

    input.forEach(line => {
        let [product, price] = line.split(' : ');
        let firstLetter = product.charAt(0);
       
        let letterCategory = letters.find(l => l.letter === firstLetter);

        if (!Boolean(letterCategory)) {
            letters.push({
                letter: firstLetter,
                products: [{
                    product,
                    price: Number(price)
                }]
            });
        }
        else {
            letterCategory.products.push({ product, price });
        }
    });

    letters.forEach(l => {
        console.log(`${l.letter}`);
        l.products.forEach(p => console.log(`${p.product}: ${p.price}`));
    })
}



solve(['Appricot : 20.4',
    'Fridge : 1500',
    'TV : 1499',
    'Deodorant : 10',
    'Boiler : 300',
    'Apple : 1.25',])
