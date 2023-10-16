import { displayTotalCups } from "./JavaScripts/uiManipulation.js";
import { mapEventListenerToInput, startCoffeeMachine } from "./JavaScripts/startSetUp.js";
import { checkIngredientLevel } from "./JavaScripts/makingProcess.js";

let coffeeJson

/**
 * Function to initialize the event for inputs
 */
export async function start () {
  try { // If the local storage is not defined means copy the coffee.json to local storage
    coffeeJson = JSON.parse(localStorage.getItem('coffee.json'))
    displayTotalCups(coffeeJson.totalCupsConsumed)
    startCoffeeMachine(coffeeJson.isProperlyShutdown)
    mapEventListenerToInput()
    checkIngredientLevel()
    updateCoffeeJson()
  } catch (error) {
    coffeeJson = await fetch('./coffee.json').then((data) => data.json())
    window.localStorage.setItem('coffee.json', JSON.stringify(coffeeJson))
  }
}

/**
 * Function to update the coffee json file
 * @param {boolean} properShutDown machine properly shuted down or not
 */
export function updateCoffeeJson(properShutDown = false) {
  coffeeJson.isProperlyShutdown = properShutDown
  coffeeJson.totalCupsConsumed = displayTotalCups(0)
  localStorage.setItem('coffee.json', JSON.stringify(coffeeJson))
}

window.addEventListener('DOMContentLoaded', start)