function startsWithLowercase(element) {
    return element[0] === element[0].toLowerCase();
}

function checkStringStartWithAny(startString) {
    return function(stringItem) {
        return stringItem.startsWith(startString);
    };
}

function filter(arr, criteria) {
    let result = [];
    for (const element of arr) {
        if (criteria(element)) {
            result.push(element);
        }
    }
    return result;
}

function displayResult(arr) {
    let result = filter(arr, startsWithLowercase);
    for (const element of result) {
        console.log(element);
    }
}

let arr = ["abc", "qwerty", "Xyz"];
let startsWithA = checkStringStartWithAny("A");
let filterStartsWithA = filter(arr, startsWithA);

displayResult(arr);
