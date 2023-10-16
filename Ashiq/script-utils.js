export let dispense = document.getElementById("dispenser");
export let clickCup = document.getElementsByClassName("units-selection")[0]
export let clickCarafe = document.getElementsByClassName("units-selection")[1]
export let water = document.getElementsByClassName("ingredients-value")[0] ;
export let bean = document.getElementsByClassName("ingredients-value")[1];
export let milk = document.getElementsByClassName("ingredients-value")[2];
export let dispenseLed = document.getElementsByClassName("indicator-leds")[7]
export let coffeeJson = {
    "isProperlyShutDown" : true ,
    "totalCupsConsumed" : 38 ,
}
export let chamber = document.getElementById("chamber")
export let dispenser = document.getElementById("dispenser")

export let variables = {
    isCupOrCarafe  : "cup" ,
}