import { displayTotalCups } from "./JavaScripts/uiManipulation.js";
import { mapEventListenerToInput, startCoffeeMachine } from "./JavaScripts/startSetUp.js";
import { checkIngredientLevel } from "./JavaScripts/makingProcess.js";
let coffeeJson

/**
 * Function to initialize the event for inputs
 */
export async function start () {
  coffeeJson = await fetch('/api/v1/').then((data) => data.json())
  displayTotalCups(coffeeJson.totalCupsConsumed)
  startCoffeeMachine(coffeeJson.isProperlyShutdown)
  mapEventListenerToInput()
  checkIngredientLevel()
}

/**
 * Function to update the coffee json file
 * @param {boolean} properShutDown machine properly shuted down or not
 */
export async function updateCoffeeJson(properShutDown = false) {
  coffeeJson.isProperlyShutdown = properShutDown
  coffeeJson.totalCupsConsumed = displayTotalCups(0)
  const response = await fetch('/api/v1/', {
    method: 'post',
    headers: {
      Accept: 'application/json',
      'Content-Type': 'application/json'
    },
    body: JSON.stringify(coffeeJson)
  })
}

window.addEventListener('DOMContentLoaded', start)
