const powerButton = document.querySelector('#power-state')
const totalCupLog = document.querySelector('#total-cup-value')
const elapsedTimeLog = document.querySelector('#elapsed-time-value')
const chamberLevelIndicatorScale = document.getElementById('chamber-level-indicator-scale')
const dispenserLevelIndicatorScale = document.getElementById('dispenser-level-indicator-scale');
const heatingProcessIndicator = document.querySelector('#heating-state')
const purgingProcessIndicator = document.querySelector('#purging-state')
const dispensingProcessIndicator = document.querySelector('#dispensing-state')
const grindingProcessIndicator = document.querySelector('#grinding-state')
const brewingProcessIndicator = document.querySelector('#brewing-state')
const waterLevelValue = document.querySelector('#water-level-indicator-slider')
const beanLevelValue = document.querySelector('#bean-level-indicator-slider')
const milkLevelValue = document.querySelector('#milk-level-indicator-slider')
const coffeeRadio = document.querySelector('#coffee-radio')
const hotWaterRadio = document.getElementById('hot-water-radio');
const cupCountContainer = document.querySelector('.cup-count-container');
const latteRadio = document.getElementById('latte-radio');
const coffeeCupUnit = document.querySelector('#coffee-cup-unit')
const coffeeCarafeUnit = document.querySelector('#coffee-carafe-unit')
const insufficientWaterIndicator = document.getElementById('insufficient-water-indicator')
const insufficientBeanIndicator = document.getElementById('insufficient-bean-indicator')
const insufficientMilkIndicator = document.getElementById('insufficient-milk-indicator')
let coffeeJson
let totalCupsConsumed
const observer = new MutationObserver(runElapsedTimeLog)
;

(async () => {
  coffeeJson = await fetch('./coffee.json').then(response => { return response.json() })
  totalCupsConsumed = coffeeJson.totalCupsConsumed
  addpowerButtonListener()
})()

function switchOnMachine(){
  observer.observe(elapsedTimeLog, observerOptions)
  updateCupLog(totalCupsConsumed)
  disableCupCountContainer()
  readPowerShutdown(coffeeJson.isProperlyShutdown)
}

function switchOffMachine() {
  totalCupsConsumed = parseInt(totalCupLog.innerHTML)
  deleteAllCallbackFunctions()
  totalCupLog.innerHTML = 0
  elapsedTimeLog.innerHTML = 0
  switchAllIndicators()
  disableCupCountContainer(1)
}

function addpowerButtonListener() {
  powerButton.addEventListener('click', () => {
    if (powerButton.innerHTML == 'ON') {
      powerButton.innerHTML = 'OFF'
      switchOnMachine()
    } else {
      switchOffMachine()
      powerButton.innerHTML = 'ON'
    }
  })
}  

function readPowerShutdown(isProperlyShutdown) {
  if (isProperlyShutdown) {
    switchHeatingProcessIndicator()
    elapsedTimeLog.innerHTML = parseInt(elapsedTimeLog.innerHTML) + 5
  } else {
    switchPurgingProcessIndicator()
    setTimeout(() => {
      switchHeatingProcessIndicator()
    }, 4000)
    elapsedTimeLog.innerHTML = parseInt(elapsedTimeLog.innerHTML) + 9
  }
}

function updateCupLog(cupConsumedValue) {
  totalCupLog.innerHTML = cupConsumedValue
}

function updateJSON() {
  fetch('./coffee.json')
  .then(response => response.json())
  .then(jsonData => {
    // update the JSON data
    jsonData.newKey = 'newValue';

    // send the updated JSON data back to the server
    fetch('./', {
      method: 'POST',
      body: JSON.stringify(jsonData),
      headers: {
        'Content-Type': 'application/json'
      }
    });
  });
}

function deleteAllCallbackFunctions() {
  for (var i = 1; i < 99999; i++) {
    window.clearInterval(i);
    window.clearTimeout(i);
  }
}

function switchAllIndicators() {
  const elements = [heatingProcessIndicator, purgingProcessIndicator, grindingProcessIndicator, brewingProcessIndicator, dispensingProcessIndicator, insufficientBeanIndicator, insufficientMilkIndicator, insufficientWaterIndicator]
  elements.forEach((element) => {
    element.classList.remove('switch-on-indicator')
  })
}

function switchHeatingProcessIndicator() {
  heatingProcessIndicator.classList.add('switch-on-indicator')
  setTimeout(() => {
    heatingProcessIndicator.classList.remove('switch-on-indicator')
  }, 5000)
}

function switchPurgingProcessIndicator() {
  purgingProcessIndicator.classList.add('switch-on-indicator')
  setTimeout(() => {
    purgingProcessIndicator.classList.remove('switch-on-indicator')
  }, 4000)
}

function switchGrindingProcessIndicator() {
  grindingProcessIndicator.classList.add('switch-on-indicator')
  setTimeout(() => {
    grindingProcessIndicator.classList.remove('switch-on-indicator')
  }, 3000)
}

function switchBrewingProcessIndicator() {
  brewingProcessIndicator.classList.add('switch-on-indicator')
  setTimeout(() => {
    brewingProcessIndicator.classList.remove('switch-on-indicator')
  }, 4000)
}

function switchDispensingProcessIndicator() {
  dispensingProcessIndicator.classList.add('switch-on-indicator')
  setTimeout(() => {
    dispensingProcessIndicator.classList.remove('switch-on-indicator')
    dispenserLevelIndicatorScale.value = 0
  }, 5000)
}

function switchLowWaterIndicator(lowWaterFlag) {
  if (lowWaterFlag == 1) {
    insufficientWaterIndicator.classList.add('switch-on-indicator')
  } else {
    insufficientWaterIndicator.classList.remove('switch-on-indicator');
  }
}

function switchLowBeanIndicator(lowBeanFlag) {
  if (lowBeanFlag == 1) {
    insufficientBeanIndicator.classList.add('switch-on-indicator')
  } else {
    insufficientBeanIndicator.classList.remove('switch-on-indicator');
  }
}

function switchLowMilkIndicator(lowMilkFlag) {
  if (lowMilkFlag == 1) {
    insufficientMilkIndicator.classList.add('switch-on-indicator')
  } else {
    insufficientMilkIndicator.classList.remove('switch-on-indicator')
  }
}

waterLevelValue.addEventListener('change', () => {
  if (waterLevelValue.value <= 30) {
    switchLowWaterIndicator(1)
    disableHotWaterRadio(1)
    disableCoffeeRadio(1)
    disableLatteRadio(1)
  } else {
    switchLowWaterIndicator(0)
    disableHotWaterRadio(0)
    disableCoffeeRadio(0)
    disableLatteRadio(0)
  }
})

beanLevelValue.addEventListener('change', () => {
  if (beanLevelValue.value <= 30) {
    switchLowBeanIndicator(1)
    disableCoffeeRadio(1)
    disableLatteRadio(1)
  } else {
    switchLowBeanIndicator(0)
    disableCoffeeRadio(0)
    disableLatteRadio(0)
  }
})

milkLevelValue.addEventListener('change', () => {
  if (milkLevelValue.value <= 30){
    disableLatteRadio(1)
    switchLowMilkIndicator(1)
  } else {
    switchLowMilkIndicator(0)
    disableLatteRadio(0)
  }
})

function disableHotWaterRadio(disable) {
  if (disable == 1) {
    hotWaterRadio.disabled = true
  } else {
    hotWaterRadio.disabled = false  
  }
}

function disableCoffeeRadio(disable) {
  if (disable == 1) {
    coffeeRadio.disabled = true
  } else {
    coffeeRadio.disabled = false
  }
}

function disableLatteRadio(disable) {
  if (disable == 1) {
    latteRadio.disabled = true
  } else {
    latteRadio.disabled = false
  }
}

function disableCupCountContainer(disable) {
  if (disable == 1) {
    cupCountContainer.classList.add('disable-click')
  } else {
    cupCountContainer.classList.remove('disable-click') 
  }
}

function hotWaterDispenser(coffeeUnitValue) {
  let units = 0
  if (coffeeUnitValue) {
    totalCupLog.innerHTML = parseInt(totalCupLog.innerHTML) + 1
    units = 5
  } else {
    totalCupLog.innerHTML = parseInt(totalCupLog.innerHTML) + 4
    units = 20
  }
  elapsedTimeLog.innerHTML = parseInt(elapsedTimeLog.innerHTML) + 5
  levelScaleHandler(units, waterLevelValue)
  addUnitsToDispenser(units)
  switchDispensingProcessIndicator()
}

function coffeeDispenser(coffeeUnitValue) {
  let units = 0
  if (coffeeUnitValue) {
    totalCupLog.innerHTML = parseInt(totalCupLog.innerHTML) + 1
    units = 5
  } else {
    totalCupLog.innerHTML = parseInt(totalCupLog.innerHTML) + 4
    units = 20
  }
  elapsedTimeLog.innerHTML = parseInt(elapsedTimeLog.innerHTML) + 12
  latteAndCoffeeDispenser(units, 0)
}

function latteDispenser(coffeeUnitValue) {
  let units = 0
  if (coffeeUnitValue) {
    totalCupLog.innerHTML = parseInt(totalCupLog.innerHTML) + 1
    units = 5
  } else {
    totalCupLog.innerHTML = parseInt(totalCupLog.innerHTML) + 4
    units = 20
  }
  elapsedTimeLog.innerHTML = parseInt(elapsedTimeLog.innerHTML) + 12
  latteAndCoffeeDispenser(units, 1)
}

function latteAndCoffeeDispenser(units, latteFlag) {
  levelScaleHandler(units, beanLevelValue)
  switchGrindingProcessIndicator()
  addUnitsToChamber(units)
  setTimeout(() => {
    levelScaleHandler(units, waterLevelValue)
    if (latteFlag == 1) {
      levelScaleHandler(units, milkLevelValue)
      addUnitsToChamber(2 * units)
    } else {
      addUnitsToChamber(units)
    }
    switchBrewingProcessIndicator()
    setTimeout(() => {
      switchDispensingProcessIndicator()
      addUnitsToDispenser()
    }, 4000)
  }, 3000)
}

function levelScaleHandler(units, target) {
  target.value -= units
  target.dispatchEvent(new Event('change'))
  const val = target.value
  const min = target.min
  const max = target.max
  target.style.backgroundSize = (val - min) * 100 / (max - min) + '% 100%'
}

coffeeCupUnit.addEventListener('click', () => {
  if (coffeeRadio.checked == true) {
    checkCoffeeDispensingPossibility(1)
  }
  if (hotWaterRadio.checked == true) {
    checkHotWaterDispensingPossibility(1)
  }
  if (latteRadio.checked === true) {
    checkLatteDispensingPossibility(1)
  }
})

coffeeCarafeUnit.addEventListener('click', () => {
  if (coffeeRadio.checked == true) {
    checkCoffeeDispensingPossibility(0)
  }
  if (hotWaterRadio.checked == true) {
    checkHotWaterDispensingPossibility(0)
  }
  if (latteRadio.checked === true) {
    checkLatteDispensingPossibility(0)
  }
})

function checkCoffeeDispensingPossibility(unitValue) {
  if (waterLevelValue.value > 30 && beanLevelValue.value > 30) {
    coffeeDispenser(unitValue)
  } else {
      alert('Fill Ingredients')
  }
}

function checkHotWaterDispensingPossibility(unitValue) {
  if (waterLevelValue.value > 30) {
    hotWaterDispenser(unitValue)
  } else {
      alert('Fill Ingredients')
  }
}

function checkLatteDispensingPossibility(unitValue) {
  if (waterLevelValue.value > 30 && beanLevelValue.value > 30 && milkLevelValue.value > 30) {
    latteDispenser(unitValue)
  } else {
      alert('Fill Ingredients')
  }
}

function addUnitsToChamber(units) {
  chamberLevelIndicatorScale.value = parseInt(chamberLevelIndicatorScale.value) + units
}

function addUnitsToDispenser(units) {
  let temp = chamberLevelIndicatorScale.value
  if (chamberLevelIndicatorScale.value != 0) {
    chamberLevelIndicatorScale.value = 0
    dispenserLevelIndicatorScale.value = parseInt(dispenserLevelIndicatorScale.value) + temp
  } else {
    dispenserLevelIndicatorScale.value = parseInt(dispenserLevelIndicatorScale.value) + units
  }
}

function runElapsedTimeLog() {
  observer.disconnect()
  disableCupCountContainer(1)
  let initialTime = parseInt(elapsedTimeLog.innerHTML)
  let t = setInterval(() => {
    if (elapsedTimeLog.innerHTML == 0) {
      disableCupCountContainer(0)
      clearInterval(t)
    } else {
      elapsedTimeLog.innerHTML = parseInt(elapsedTimeLog.innerHTML) - 1
    }
  }, 1000)
  setTimeout(() => {
    observer.observe(elapsedTimeLog, observerOptions)
  }, (initialTime + 1) * 1000)
}

const observerOptions = {
  childList: true,
  subtree: true,
};