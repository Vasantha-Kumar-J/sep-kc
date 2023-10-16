import { updateCoffeeJson } from "../script.js"
import { controlAllInputs, disableElement, displayTimeElapsed, displayTotalCups, indicateLowLevel, resetAllInputs, transferUnits, turnOffLed, turnOnLed } from "./uiManipulation.js"

//// hot water module
const dispenserElement = document.getElementById('dispenser-level')
const chamberElement = document.getElementById('chamber-level')

const waterLevel = document.getElementById('water-level')
const beanLevel = document.getElementById('bean-level')
const milkLevel = document.getElementById('milk-level')

export const time = {
  dispensing: 5,
  grinding:3,
  brewing:4,
  heating:5,
  purging:4
}


/**
 * Function to start the beverage making process
 * @param {string} selectedBeverage option selected
 * @param {string} selectedQuantity quantity selected
 */
export function startBeverageMaking (selectedBeverage, selectedQuantity) {
  if (selectedBeverage && selectedQuantity){
    if(selectedBeverage === 'hotwater') makeHotWater(selectedQuantity)
    else if (selectedBeverage === 'coffee') makeCoffee(selectedQuantity)
    else if (selectedBeverage === 'latte') makeLatte(selectedQuantity)
    checkIngredientLevel()
    controlAllInputs(true)
}
}

/**
 * Function to execute the hot water making process
 * @param {string} selectedQuantity of beverage
 */
function makeHotWater(selectedQuantity) {
  const units = selectedQuantity === 'cup' ? 5 : 20
  transferUnits('water-level', 'dispenser-level', units)
  runProcess('dispensing')
}

/**
 * Function to execute the coffee making process
 * @param {string} selectedQuantity of beverage
 */
function makeCoffee(selectedQuantity) {
  const units = selectedQuantity === 'cup' ? 5 : 20
  transferUnits('bean-level', 'chamber-level', units)
  runProcess('grinding')
  sleep(time.grinding * 1000).then(() => {
    transferUnits('water-level', '', units)
    runProcess('brewing')
    sleep(time.brewing * 1000).then(() => {
      transferUnits('chamber-level', 'dispenser-level', units)
      runProcess('dispensing')
    })
  })
}

/**
 * Function to execute the latte making process
 * @param {string} selectedQuantity of beverage
 */
function makeLatte(selectedQuantity) {
  const units = selectedQuantity === 'cup' ? 5 : 20
  transferUnits('bean-level', 'chamber-level', units)
  runProcess('grinding')
  sleep(time.grinding * 1000).then(() => {
    transferUnits('water-level', '', units)
    transferUnits('milk-level', '', units)
    runProcess('brewing')
    sleep(time.brewing * 1000).then(() => {
      transferUnits('chamber-level', 'dispenser-level', units)
      runProcess('dispensing')
    })
  })
}

/**
 * Function to run the individual process like grinding, heating
 * @param {string} process which process need to be executed
 */
export function runProcess(process) {
  let duration = time[process]
  turnOnLed(process + '-led')
  displayTimeElapsed(duration)
  const intervalId = setInterval(() => {
    duration -= 1
    displayTimeElapsed(duration)
  }, 1000)
  const timeoutId = setTimeout(() => {
    clearInterval(intervalId)
    turnOffLed(process + '-led')
    if(process === 'dispensing') dispenseBeverage()
  }, time[process] * 1000)
}

/**
 * Function to dispense the beverage at the end of the making process
 */
export function dispenseBeverage() {
  const units = parseInt(dispenserElement.value)
  dispenserElement.value = 0
  displayTotalCups(units / 5)
  updateCoffeeJson()
  resetAllInputs()
  controlAllInputs(false)
}

/**
 * Function to check the ingredients availability
 */
export function checkIngredientLevel () {
  if (waterLevel.value < 30) {
    disableElement('hotwater-selector')
    disableElement('coffee-selector')
    disableElement('latte-selector')
    indicateLowLevel('low-water')
  }
  if (beanLevel.value < 30){
    disableElement('coffee-selector')
    disableElement('latte-selector')
    indicateLowLevel('low-bean')
  }
  if (milkLevel.value < 30) {
    disableElement('latte-selector')
    indicateLowLevel('low-milk')
  }
}

/**
 * Function to sleep the process until its elapsing time
 * @param {number} ms milliseconds to make the process sleep
 * @returns {object}
 */
export function sleep(ms) {
  return new Promise(resolve => setTimeout(resolve, ms));
}
