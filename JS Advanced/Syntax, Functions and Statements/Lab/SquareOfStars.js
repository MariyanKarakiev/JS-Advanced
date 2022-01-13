function drawSquare(size) {
    let square = '';

    for (let i = 0; i < size; i++) {
        for (let j = 0; j < size; j++) {
            square += '* ';
        }
        square += '\n';
    }

    console.log(square);
}

drawSquare(1);