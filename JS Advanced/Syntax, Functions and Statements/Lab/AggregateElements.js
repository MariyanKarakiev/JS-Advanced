function aggregateElements(elements) {

    aggregate(elements, 0, (a, b) => a + b);
    aggregate(elements, 0, (a, b) => a + 1 / b);
    aggregate(elements, '', (a, b) => a + b);

    function aggregate(arr, initVal, func) {
        let value = initVal;

        arr.forEach(element => {
            value = func(value, element);
        });

        console.log(value);
    }
}

aggregateElements([1, 2, 3]);