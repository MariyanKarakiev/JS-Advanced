function solve(json) {
    let arr = JSON.parse(json);
    let outputArr = ["<table>"];

    outputArr.push(makeKeyRow(arr));
    arr.forEach(obj => outputArr.push(makeValueRow(obj)));

    outputArr.push("</table>");

    function makeKeyRow(arr) {
        let hRow = [];
        let keys = Object.keys(arr[0]);

        hRow.push("<tr>");
        keys.forEach(h => hRow.push(`<th>${h}</th>`));
        hRow.push("</tr>");

        return hRow.join('');
    }
    function makeValueRow(obj) {
        let dRow = [];
        let values = Object.values(obj);

        dRow.push("<tr>");
        values.forEach(h => dRow.push(`<td>${h}</td>`));
        dRow.push("</tr>");

        return dRow.join('');
    }

    console.log(outputArr.join('\n'));
}

solve(`[{"Name":"Stamat",
    "Score":5.5},
    {"Name":"Rumen",
    "Score":6}]`);