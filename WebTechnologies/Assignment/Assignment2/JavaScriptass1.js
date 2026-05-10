//1. Write a JavaScript program to find the area of a triangle where three sides are 5, 6, 7.
let a = 5;
let b = 6;
let c = 7;
let s = (a + b + c) / 2;
let area = Math.sqrt(s * (s - a) * (s - b) * (s - c));
console.log("Area of Triangle:", area);

//2. Write a JavaScript program to construct the following pattern, using a nested for loop.
for (let i = 1; i <= 5; i++) {
    let pattern = "";

    for (let j = 1; j <= i; j++) {
        pattern += "* ";
    }

    console.log(pattern);
}

//3. Write a JavaScript program to determine whether a given year is a leap year
let year = 2024;
if (year % 4 == 0) {
    console.log("Leap Year");
}
else
{
    console.log("Not a Leap Year");
}
//4. Write a JavaScript program that calculates the number of days left until Independence Day by comparing the current date with August 15th of the current year. If today is after August 15th, it calculates the days until next year's Independence Day. The difference in days is then logged to the console.
let today = new Date();
let currentYear = today.getFullYear();
let independenceDay = new Date(currentYear, 7, 15);
if (today > independenceDay) {
    independenceDay = new Date(currentYear + 1, 7, 15);
}
let difference = independenceDay - today;
let daysLeft = Math.ceil(difference / (1000 * 60 * 60 * 24));
console.log("Days left until Independence Day:", daysLeft);
