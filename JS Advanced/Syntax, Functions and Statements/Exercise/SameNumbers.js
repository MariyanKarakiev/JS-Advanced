function solve(element) {
    let n = String(element);
    let areSame = true;
    let sum = Number();
    let firstLetter = n[0];

    for (let i = 0; i < n.length; i++) {
        if (n[i] !=firstLetter) {
            areSame = false;
        }
        sum +=Number(n[i]);
    }
    console.log(areSame);
    console.log(sum);
}

solve(2);