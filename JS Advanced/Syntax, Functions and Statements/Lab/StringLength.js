function getLength(string1, string2, string3) {
    let sumOfLenths = string1.length + string2.length + string3.length;
    let averageLength = sumOfLenths / 3;

    console.log(sumOfLenths);
    console.log(Math.floor(averageLength));
}

getLength('chocolate', 'ice cream', 'cake');