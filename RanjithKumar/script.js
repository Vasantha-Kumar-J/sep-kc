const beverageSelectionButtons = document.querySelectorAll('.beverage-selection-buttons')
const quantitySelectors = document.querySelectorAll('.quantity-selector')
let selectedBeverage, selectedQuantity

function start () {
  beverageSelectionButtons.forEach((button) => {
    button.addEventListener('click', (e) => handleSelectedBeverage(e))
  })
  quantitySelectors.forEach((button) => {
    button.addEventListener('click', (e) => handleSelectedQuantity(e))
  })
}

function handleSelectedBeverage (e) {
  beverageSelectionButtons.forEach((button) => {
    button.classList.remove('selected-button')
  })
  e.target.classList.add('selected-button')
  selectedBeverage = e.target.id.split('-')[0]
  startBeverageProcess()
}

function handleSelectedQuantity (e) {
  quantitySelectors.forEach((button) => {
    button.classList.remove('selected-quantity')
  })
  e.target.classList.add('selected-quantity')
  selectedQuantity = e.target.id.split('-')[0]
  startBeverageProcess()
}

function startBeverageProcess () {
  if (selectedBeverage && selectedQuantity){
    if(selectedBeverage === 'hotwater'){
      makeHotWater(selectedQuantity)
    } else if (selectedBeverage === 'coffee') {
      makeCoffee(selectedQuantity)
    }
  }
}



//// hot water module
const dispenserElement = document.getElementById('dispenser-level')
const chamberElement = document.getElementById('chamber-level')

const waterLevel = document.getElementById('water-level')
const beanLevel = document.getElementById('bean-level')
const milkLevel = document.getElementById('milk-level')

const grindingLed = document.getElementById("grinding-led")
const brewingLed = document.getElementById("dispensing-led")
const heatingLed = document.getElementById("dispensing-led")
const dispensingLed = document.getElementById("dispensing-led")

const timeDisplay = document.getElementById('time-display')
const cupsElement = document.getElementById('cups-display')
const time = {
  dispensing: 5,
  grinding:3,
  brewing:4,
  heating:5,
  purging:4
}

function makeHotWater (selectedQuantity){
  const quantity = selectedQuantity === 'cup' ? 5 : 20
  dispenserElement.value = quantity
  waterLevel.value -= quantity
  dispensingLed.classList.add('led-on')
  let elapse = time.dispensing
  timeDisplay.innerHTML = elapse
  const intervalId = setInterval(() => {
    elapse = elapse - 1
    timeDisplay.innerHTML = elapse
    console.log(elapse)
  },1000)
  setTimeout(() => {
    clearInterval(intervalId)
    dispensingLed.classList.remove('led-on')
    dispenserElement.value = 0
    cupsElement.innerHTML = parseInt(cupsElement.innerHTML) + (quantity / 5)
  }, time.dispensing*1000)
}

function makeCoffee (selectedQuantity) {
  const quantity = selectedQuantity === 'cup' ? 5 : 20
  chamberElement.value = quantity
  beanLevel.value -= quantity
  grindingLed.classList.add('led-on')
  let elapse = time.grinding
  timeDisplay.innerHTML = elapse
  const intervalId1 = setInterval(() => {
    elapse = elapse - 1
    timeDisplay.innerHTML = elapse
  },1000)
  setTimeout(() => {
    clearInterval(intervalId1)
    grindingLed.classList.remove('led-on')
  }, time.grinding*1000)

  chamberElement.value += quantity
  waterLevel.value -= quantity
  brewingLed.classList.add('led-on')
  elapse = time.brewing
  timeDisplay.innerHTML = elapse
  const intervalId2 = setInterval(() => {
    elapse = elapse - 1
    timeDisplay.innerHTML = elapse
  },1000)
  setTimeout(() => {
    clearInterval(intervalId2)
    brewingLed.classList.remove('led-on')
  }, time.brewing*1000)

  dispenserElement.value = chamberElement.value
  chamberElement.value = 0
  elapse = time.dispensing
  timeDisplay.innerHTML = elapse
  const intervalId3 = setInterval(() => {
    elapse = elapse - 1
    timeDisplay.innerHTML = elapse
  },1000)
  setTimeout(() => {
    clearInterval(intervalId3)
    dispensingLed.classList.remove('led-on')
    dispenserElement.value = 0
    cupsElement.innerHTML = parseInt(cupsElement.innerHTML) + (quantity / 5)
  }, time.dispensing*1000)

}


window.addEventListener('DOMContentLoaded', start)