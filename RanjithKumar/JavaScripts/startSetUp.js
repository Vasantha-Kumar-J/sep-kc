import { runProcess, sleep, startBeverageMaking, time } from "./makingProcess.js"

let selectedBeverage, selectedQuantity

const beverageSelectionButtons = document.querySelectorAll('.beverage-selection-buttons')
const quantitySelectors = document.querySelectorAll('.quantity-selector')

export function startCoffeeMachine(properShutDown) {
  if (properShutDown) {
      runProcess('heating')  
  } else {
    runProcess('purging')
    sleep(time.purging * 1000).then(() => runProcess('heating'))
  }
}

export function mapEventListenerToInput () {
  beverageSelectionButtons.forEach((button) => {
    button.addEventListener('click', (e) => handleSelectedBeverage(e))
  })
  quantitySelectors.forEach((button) => {
    button.addEventListener('click', (e) => handleSelectedQuantity(e))
  })
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
