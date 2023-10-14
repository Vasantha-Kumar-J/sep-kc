import { start, updateCoffeeJson } from "../script.js"
import { runProcess, sleep, startBeverageMaking, time } from "./makingProcess.js"

let selectedBeverage, selectedQuantity

const beverageSelectionButtons = document.querySelectorAll('.beverage-selection-buttons')
const quantitySelectors = document.querySelectorAll('.quantity-selector')
const powerButton = document.getElementById('power-button')

export function startCoffeeMachine(properShutDown) {
  if (properShutDown) {
      runProcess('heating')  
  } else {
    runProcess('purging')
    sleep(time.purging * 1000).then(() => runProcess('heating'))
  }
}

export function mapEventListenerToInput () {
  powerButton.addEventListener('click', (e) => handlePowerButton(e))
  beverageSelectionButtons.forEach((button) => {
    button.addEventListener('click', (e) => handleSelectedBeverage(e))
  })
  quantitySelectors.forEach((button) => {
    button.addEventListener('click', (e) => handleSelectedQuantity(e))
  })
}

function handlePowerButton(element) {
  console.log(element)
  if (element.target.innerHTML === 'On'){
    updateCoffeeJson(true)
    element.target.innerHTML = 'Off'
  } else {
    updateCoffeeJson(false)
    element.target.innerHTML = 'On'
    start()
  }
}

/**
 * Function to handle the beverage selected
 * @param {object} e 
 */
function handleSelectedBeverage (e) {
  selectedBeverage = e.target.id.split('-')[0]
  startBeverageMaking(selectedBeverage, selectedQuantity)
}

/**
 * Function to handle the quantity selected
 * @param {object} e 
 */
function handleSelectedQuantity (e) {
  quantitySelectors.forEach((button) => button.classList.remove('selected-quantity'))
  e.target.classList.add('selected-quantity')
  selectedQuantity = e.target.id.split('-')[0]
  startBeverageMaking(selectedQuantity, selectedQuantity)
}

