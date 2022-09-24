function factory(library, orders) {

    let readyOrders = [];

    orders.forEach(order => {
        let template = order.template;
        let key = Object.keys(template)[0];
        let value = Object.values(template)[0];

        let readyOrder = {};

        readyOrder[key] = value;

        Object.keys(library).forEach(c => {
            let tr = order.parts.includes(c);
            if(tr){
            readyOrder[c] = library[c];
            }
        });

        readyOrders.push(readyOrder);
    });

    return readyOrders;
}

const library = {
    print: function () {
        console.log(`${this.name} is printing a page`);
    },
    scan: function () {
        console.log(`${this.name} is scanning a document`);
    },
    play: function (artist, track) {
        console.log(`${this.name} is playing '${track}' by ${artist}`);
    },
};
const orders = [
    {
        template: { name: 'ACME Printer' },
        parts: ['print']
    },
    {
        template: { name: 'Initech Scanner' },
        parts: ['scan']
    },
    {
        template: { name: 'ComTron Copier' },
        parts: ['scan', 'print']
    },
    {
        template: { name: 'BoomBox Stereo' },
        parts: ['play']
    }
];
const products = factory(library, orders);
console.log(products);