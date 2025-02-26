function tellStory(name, mood, activity, gender) {
    let heShe;
    if (gender === `male`) {
        heShe = `he`;
    } else if (gender === `female`) {
        heShe = `she`;
    } else {
        alert(`Please enter a gender`);
    }

    console.log(`This is ${name}.`);
    console.log(`${name} is a nice person.`);
    console.log(`Today ${heShe} is ${mood}.`);
    console.log(`${heShe.charAt(0).toUpperCase() + heShe.slice(1).toLowerCase()} is ${activity} all day.`);
    console.log(`The end.`);
}

genderInput = prompt(`Please enter your gender `).toLowerCase();
nameInput = prompt(`Enter your name `);
moodInput = prompt(`Enter your mood `);
activityInput = prompt(`What are you doing `);

tellStory(nameInput, moodInput, activityInput, genderInput);