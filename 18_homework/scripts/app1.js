// first way
let country = {
    name: `Germany`,
    capitalCity: `Berlin`,
    population: 84552242,
    area: 357596,
    goesOutToSea: true,

    personPerOneMeter: function() {
        console.log(`${this.population / this.area} people live on 1m2 in ${this.name}`);
    }
}

console.log(country);
country.personPerOneMeter()

console.log(` `);
console.log(`==============================================================`);
// second way

let city = new Object() 

city.name = `Belgrade`;
city.cityInCountry = `Serbia`;
city.population = 1166763;
city.isSafe = true;
city.isGoodForLiving = function() {
    if(this.isSafe === true) {
        console.log(`It is good city for living`);
    } else {
        console.log(`It isn't good city for living`);        
    }
}

console.log(city);
city.isGoodForLiving();

console.log(` `);
console.log(`==============================================================`);
// third way

function Person(firstName, lastName, age, birthYear, weringGlasses) {
    this.firstName = firstName;
    this.lastName = lastName;
    this.age = age;
    this.birthYear = birthYear;
    this.weringGlasses = weringGlasses;

    this.getAge = function (currentYear) {
        return currentYear - this.birthYear;
    }

    this.getFullName = function () {
        return this.firstName + this.lastName;
    }
}

let angel = new Person(`Angel`, `Krstevski`, 17, 2007, true);
console.log(angel);