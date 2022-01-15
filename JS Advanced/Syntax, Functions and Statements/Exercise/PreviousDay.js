function getPreviousDay(year, month, day) {
    let date = new Date(year, month - 1, day-1);

    let formattedDate = date.toLocaleDateString().split('/')

    formattedDate.unshift(formattedDate[formattedDate.length-1]);
    formattedDate.pop();

    console.log(formattedDate.join('-'));
}

getPreviousDay(2016, 10, 30);