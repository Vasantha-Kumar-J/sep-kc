import { start, updateCoffeeJson } from "../script.js"
import { runProcess, sleep, startBeverageMaking, time } from "./makingProcess.js"
import { controlAllInputs, resetAllInputs } from "./uiManipulation.js"

let selectedBeverage, selectedQuantity

const beverageSelectionButtons = document.querySelectorAll('.beverage-selection-buttons')
const quantitySelectors = document.querySelectorAll('.quantity-selector')
const powerButton = document.getElementById('power-button')

export let inputSelected = { selectedBeverage, selectedQuantity }

/**
 * Function to start the coffee machine
 * @param {boolean} properShutDown system properly shuted down or not
 */
export function startCoffeeMachine(properShutDown) {
  if (properShutDown) {
      runProcess('heating')  
  } else {
    runProcess('purging')
    sleep(time.purging * 1000).then(() => runProcess('heating'))
  }
}

/**
 * Function to map the input elements to its respective listener functions
 */
export function mapEventListenerToInput () {
  powerButton.addEventListener('click', (e) => handlePowerButton(e))
  beverageSelectionButtons.forEach((button) => {
    button.addEventListener('click', (e) => handleSelectedBeverage(e))
  })
  quantitySelectors.forEach((button) => {
    button.addEventListener('click', (e) => handleSelectedQuantity(e))
  })
}

/**
 * Function to handle the power of the machine
 * @param {object} element Power button element
 */
function handlePowerButton(element) {
  if (element.target.innerHTML === 'On'){
    updateCoffeeJson(true)
    element.target.innerHTML = 'Off'
    resetAllInputs()
    controlAllInputs(true)
  } else {
    updateCoffeeJson(false)
    element.target.innerHTML = 'On'
    start()
    controlAllInputs(false)
  }
}

/**
 * Function to handle the beverage selected
 * @param {object} e 
 */
function handleSelectedBeverage (e) {
  selectedBeverage = e.target.id.split('-')[0]
  startBeverageMaking(selectedBeverage, selectedQuantity)
  selectedBeverage = (selectedBeverage && selectedQuantity) ? null : selectedBeverage
}

/**
 * Function to handle the quantity selected
 * @param {object} e 
 */
function handleSelectedQuantity (e) {
  quantitySelectors.forEach((button) => button.classList.remove('selected-quantity'))
  e.target.classList.add('selected-quantity')
  selectedQuantity = e.target.id.split('-')[0]
  startBeverageMaking(selectedBeverage, selectedQuantity)
}

