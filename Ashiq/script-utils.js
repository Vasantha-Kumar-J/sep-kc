export let dispense = document.getElementById("dispenser");
export let clickCup = document.getElementsByClassName("units-selection")[0]
export let clickCarafe = document.getElementsByClassName("units-selection")[1]
export let water = document.getElementsByClassName("ingredients-value")[0] ;
export let bean = document.getElementsByClassName("ingredients-value")[1];
export let milk = document.getElementsByClassName("ingredients-value")[2];
export let dispenseLed = document.getElementsByClassName("indicator-leds")[7]
export let grindLed = document.getElementsByClassName('indicator-leds')[5]
export let brewingLed = document.getElementsByClassName('indicator-leds')[6]
export let coffeeJson = {
    "isProperlyShutDown" : true ,
    "totalCupsConsumed" : 38 ,
}
export let chamber = document.getElementById("chamber")
export let dispenser = document.getElementById("dispenser")
export let showelaspedTime = document.getElementsByClassName("show-stats")[0] ;
export let showtotalCupsConsumed = document.getElementsByClassName("show-stats")[1] ;
export let selectedBeverage = document.querySelector('input[name="beverage"]:checked') ;
export let showDispenser = document.getElementsByClassName('chamber-and-dispenser')[1];
export let showChamber = document.getElementsByClassName('chamber-and-dispenser')[0];
export let lowWaterLed = document.getElementsByClassName("indicator-leds")[0]
export let lowBeanLed = document.getElementsByClassName("indicator-leds")[1]
export let lowMilkLed = document.getElementsByClassName("indicator-leds")[2]
export let variables = {
    isCupOrCarafe  : "cup" ,
}