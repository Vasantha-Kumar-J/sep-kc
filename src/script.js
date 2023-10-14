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
const latteRadio = document.getElementById('latte-radio');
const coffeeCupUnit = document.querySelector('#coffee-cup-unit')
const coffeeCarafeUnit = document.querySelector('#coffee-carafe-unit')
let coffeeJson
;

(async () => {
  coffeeJson = await fetch('./coffee.json').then(response => { return response.json() })
  addpowerButtonListener()
})()

async function switchOnMachine(){
  updateCupLog(coffeeJson.totalCupsConsumed)
  readPowerShutdown(coffeeJson.isProperlyShutdown)
}

function addpowerButtonListener() {
  powerButton.addEventListener('click', () => {
    if (powerButton.innerHTML == 'ON') {
      powerButton.innerHTML = 'OFF'
      switchOnMachine()
      console.log(coffeeJson);
    } else {
      // switchOffMachine()
      powerButton.innerHTML = 'ON'
    }
  })
}  

function updateCupLog(cupConsumedValue) {
  totalCupLog.innerHTML = cupConsumedValue
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

function switchHeatingProcessIndicator() {
  heatingProcessIndicator.classList.add('switch-on-indicator')
  setTimeout(() => {
    heatingProcessIndicator.classList.remove('switch-on-indicator')
  },5000)
}

function switchPurgingProcessIndicator() {
  purgingProcessIndicator.classList.add('switch-on-indicator')
  setTimeout(() => {
    purgingProcessIndicator.classList.remove('switch-on-indicator')
  },4000)
}

function switchGrindingProcessIndicator() {
  grindingProcessIndicator.classList.add('switch-on-indicator')
  setTimeout(() => {
    grindingProcessIndicator.classList.remove('switch-on-indicator')
  },3000)
}

function switchBrewingProcessIndicator() {
  brewingProcessIndicator.classList.add('switch-on-indicator')
  setTimeout(() => {
    brewingProcessIndicator.classList.remove('switch-on-indicator')
  },4000)
}

function switchDispensingProcessIndicator() {
  dispensingProcessIndicator.classList.add('switch-on-indicator')
  setTimeout(() => {
    dispensingProcessIndicator.classList.remove('switch-on-indicator')
  },5000)
}

waterLevelValue.addEventListener('change', () => {
  if (waterLevelValue.value <= 30){
    disableHotWaterRadio()
    disableCoffeeRadio()
    disableLatteRadio()
  }
})

beanLevelValue.addEventListener('change', () => {
  if (beanLevelValue.value <= 30){
    disableCoffeeRadio()
    disableLatteRadio()
  }
})

milkLevelValue.addEventListener('change', () => {
  if (milkLevelValue.value <= 30){
    disableLatteRadio()
  }
})

function disableHotWaterRadio() {
  hotWaterRadio.disabled = true
}

function disableCoffeeRadio() {
  coffeeRadio.disabled = true
}

function disableLatteRadio() {
  latteRadio.disabled = true
}

function hotWaterDispenser(coffeeUnitValue) {
  if (coffeeUnitValue) {
    waterLevelValue.value -= 5
    totalCupLog.innerHTML = parseInt(totalCupLog.innerHTML) + 1
  } else {
    waterLevelValue.value -= 20
    totalCupLog.innerHTML = parseInt(totalCupLog.innerHTML) + 4
  }
  switchDispensingProcessIndicator()
  elapsedTimeLog.innerHTML = parseInt(elapsedTimeLog.innerHTML) + 5
}

function coffeeDispenser(coffeeUnitValue) {
  if (coffeeUnitValue) {
    waterLevelValue.value -= 5
    beanLevelValue.value -= 5
    totalCupLog.innerHTML = parseInt(totalCupLog.innerHTML) + 1
  } else {
    waterLevelValue.value -= 20
    beanLevelValue.value -= 20
    totalCupLog.innerHTML = parseInt(totalCupLog.innerHTML) + 4
  }
  switchGrindingProcessIndicator()
  addUnitsToChamber(5)
  setTimeout(() => {
    addUnitsToChamber(5)
    switchBrewingProcessIndicator()
    setTimeout(() => {
      switchDispensingProcessIndicator()
      addUnitsToDispenser()
      dispenserLevelIndicatorScale.value = 0
    }, 4000)
  }, 3000)
  elapsedTimeLog.innerHTML = parseInt(elapsedTimeLog.innerHTML) + 20
}

function latteDispenser(coffeeUnitValue) {
  if (coffeeUnitValue) {
    waterLevelValue.value -= 5
    beanLevelValue.value -= 5
    milkLevelValue.value -= 5
    totalCupLog.innerHTML = parseInt(totalCupLog.innerHTML) + 1
  } else {
    waterLevelValue.value -= 20
    beanLevelValue.value -= 20
    milkLevelValue.value -= 20
    totalCupLog.innerHTML = parseInt(totalCupLog.innerHTML) + 4
  }
  switchGrindingProcessIndicator()
  addUnitsToChamber(5)
  setTimeout(() => {
    addUnitsToChamber(5)
    switchBrewingProcessIndicator()
    setTimeout(() => {
      switchDispensingProcessIndicator()
      addUnitsToDispenser()
      dispenserLevelIndicatorScale.value = 0
    }, 4000)
  }, 3000)
  elapsedTimeLog.innerHTML = parseInt(elapsedTimeLog.innerHTML) + 20
}

function addCupUnitListener() {
  for (let i in cupUnit) {
    i.addEventListener('click', () => {
      if (coffeeRadio.checked == true) {
        coffeeDispenser(1);
      }
    })
  }
}

coffeeCupUnit.addEventListener('click', () => {
  if (coffeeRadio.checked == true) {
    coffeeDispenser(1);
  }
  if (hotWaterRadio.checked == true) {
    hotWaterDispenser(1)
  }
  if (latteRadio.checked === true) {
    latteDispenser(1)
  }
})

coffeeCarafeUnit.addEventListener('click', () => {
  if (coffeeRadio.checked == true) {
    coffeeDispenser(0);
  }
  if (hotWaterRadio.checked == true) {
    hotWaterDispenser(0)
  }
  if (latteRadio.checked === true) {
    latteDispenser(0)
  }
})

function addUnitsToChamber(units) {
  chamberLevelIndicatorScale.value += units
}

function addUnitsToDispenser() {
  let temp = chamberLevelIndicatorScale.value
  chamberLevelIndicatorScale.value = 0
  dispenserLevelIndicatorScale.value += temp
}