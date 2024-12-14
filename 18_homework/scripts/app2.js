function Animal(name,kind) {
    this.name = name;
    this.kind = kind;

    this.animalSound = function(sound) {
        console.log(`The ${this.name} says ${sound}`);
    }
}

let nameInput = prompt(`What is your animal name?`)
let kindInput = prompt(`What kind of animal is?`)
let soundInput = prompt(`What sound does your ${nameInput} make?`)

let dog = new Animal(nameInput,kindInput);

console.log(dog);
dog.animalSound(soundInput);