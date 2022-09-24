function heroCreater() {
    return {
        mage(name) {
            return {
                name,
                health:100,
                mana:100,
                cast(spell){
                    this.mana--;
                    console.log(`${this.name} cast ${spell}`);
                }
            }
        },
        fighter(name) {
            return {
                name,
                health:100,
                stamina:100,
                fight(){
                    this.stamina--;
                    console.log(`${this.name} slashes at the foe`);
                }
            }
        }
    }
}

let create = heroCreater();

let mage = create.mage("ivan");

mage.cast("plunka");
console.log(mage.mana);

let createf = heroCreater();

let f = create.fighter("ivain");

f.fight();
console.log(f.stamina);