function rotate(array, n) {

    for (let i = 0; i < n; i++) {
      array.unshift(array[array.length-1]);
      array.pop();
    }

   console.log(array.join(' '));
}

rotate(['1',
    '2',
    '3',
    '4'],
    2)