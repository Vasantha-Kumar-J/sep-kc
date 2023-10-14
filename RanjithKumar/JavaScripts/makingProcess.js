import { displayTimeElapsed, displayTotalCups, transferUnits, turnOffLed, turnOnLed } from "./uiManipulation.js"

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
 */
export function startBeverageMaking (selectedBeverage, selectedQuantity) {
  if (selectedBeverage && selectedQuantity){
    if(selectedBeverage === 'hotwater') makeHotWater(selectedQuantity)
    else if (selectedBeverage === 'coffee') makeCoffee(selectedQuantity)
  else if (selectedBeverage === 'latte') makeLatte(selectedQuantity)
  checkIngredientLevel()
  }
}

function makeHotWater(selectedQuantity) {
  const units = selectedQuantity === 'cup' ? 5 : 20
  transferUnits('water-level', 'dispenser-level', units)
  runProcess('dispensing')
}

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

export function runProcess(process) {
  console.log(process)
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

export function dispenseBeverage() {
  const units = parseInt(dispenserElement.value)
  dispenserElement.value = 0
  displayTotalCups(units / 5)
}

export function checkIngredientLevel () {
  if (waterLevel.value < 30) document.getElementById('hotwater-selector').disabled = true
  if (waterLevel.value < 30 || beanLevel.value < 30)  document.getElementById('coffee-selector').disabled = true
  if (milkLevel.value < 30 || waterLevel.value < 30 || beanLevel.value < 30) document.getElementById('latte-selector').disabled = true
  return true
}

export function sleep(ms) {
  return new Promise(resolve => setTimeout(resolve, ms));
}
