function heroicInvetory(input){
    let heroes = [];

    for (const info of input){
        let [name, level, items] = info.split(' / ');
        level = Number(level);

        items = items ? items.split(', ') : [];

        heroes.push({name,level,items});
    }

    return JSON.stringify(heroes);
}

console.log(heroicInvetory(['Isacc / 25 / Apple, GravityGun',
    'Derek / 12 / BarrelVest, DestructionSword',
    'Hes / 1 /']));