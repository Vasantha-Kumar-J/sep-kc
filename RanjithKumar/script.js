import { displayTotalCups } from "./JavaScripts/uiManipulation.js";
import { mapEventListenerToInput, startCoffeeMachine } from "./JavaScripts/startSetUp.js";
import { checkIngredientLevel } from "./JavaScripts/makingProcess.js";

let coffeeJson

/**
 * Function to initialize the event for inputs
 */
export async function start () {
  coffeeJson = await fetch('./coffee.json').then((data) => data.json())
  displayTotalCups(coffeeJson.totalCupsConsumed)
  startCoffeeMachine(coffeeJson.isProperlyShutdown)
  mapEventListenerToInput()
  checkIngredientLevel()
}

export function updateCoffeeJson(properShutDown = false) {
  coffeeJson.isProperlyShutdown = properShutDown
  coffeeJson.totalCupsConsumed = displayTotalCups(0)
}


window.addEventListener('DOMContentLoaded', start)