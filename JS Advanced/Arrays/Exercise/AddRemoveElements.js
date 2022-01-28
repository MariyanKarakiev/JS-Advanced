function solve(commands) {
   
    let numbers = [];
   
    for (let i = 1; i <= commands.length; i++) {
        if (commands[i - 1] == 'add') {
            numbers.push(i);
        }
        else if (commands[i - 1] == 'remove') {
            numbers.pop();
        }
    }

    numbers.length != 0 ? numbers.forEach(x=>console.log(x)) : console.log("Empty");
}

solve([
    'remove',
    'add'
])