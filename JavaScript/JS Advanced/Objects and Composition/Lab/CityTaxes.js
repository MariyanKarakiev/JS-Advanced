function cityTaxes(name, population, treasury) {

    let city = {
        name,
        population,
        treasury,
        taxRate: 10,
        collectTaxes() {
            this.treasury += this.population * this.taxRate;
        },
        applyGrowth(percentage) {
            this.population += this.population * (percentage / 100);
            this.population.toFixed(2);
        },
        applyRecession(percentage) {
            this.treasury -= this.treasury * (percentage / 100);
            this.treasury.toFixed(2);
        }
    };
    return city;
}

    const city =
cityTaxes('Tortuga',
7000,
15000);
city.collectTaxes();
console.log(city.treasury);
city.applyGrowth(5);
console.log(city.population);