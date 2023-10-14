import { displayTotalCups } from "./JavaScripts/uiManipulation.js";
import { mapEventListenerToInput, startCoffeeMachine } from "./JavaScripts/startSetUp.js";
import { checkIngredientLevel } from "./JavaScripts/makingProcess.js";

export let coffeeJson

/**
 * Function to initialize the event for inputs
 */
async function start () {
  coffeeJson = await fetch('./coffee.json').then((data) => data.json())
  displayTotalCups(coffeeJson.totalCupsConsumed)
  startCoffeeMachine(coffeeJson.isProperlyShutdown)
  mapEventListenerToInput()
  checkIngredientLevel()
}



window.addEventListener('DOMContentLoaded', start)