function getEvenElement(arr) {

    let result = '';

    for (let i = 0; i < arr.length; i += 2) {
       result+=arr[i];
       result+=' ';
    }

    console.log(result)
}

getEvenElement(['20', '30', '40', '50', '60'])