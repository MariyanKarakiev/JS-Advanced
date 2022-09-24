function cook(number, c1, c2, c3, c4, c5) {
    number = Number(number)
    let operations = new Array(c1, c2, c3, c4, c5);

    operations.forEach(element => {
        switch (element) {
            case 'chop':
                number /= 2;
                break;
            case 'dice':
                number = Math.sqrt(number);
                break;
            case 'spice':
                number += 1;
                break;
            case 'bake':
                number *= 3;
                break;
            case 'fillet':
                number -=number*0.20;
                break;           
        }

        console.log(number);
    });
}

cook('9', 'dice', 'spice', 'bake', 'fillet', 'chop')