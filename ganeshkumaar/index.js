import * as processes from './processes.js'
import { isOn,isHold } from './checkers.js'
import { createWater,createCoffee,createLatte, updateBeanLevel, updateMilkLevel, updateWaterLevel,checkMinimumLevels } from './createfunctions.js'

export const globalVariables = {
    hold : false,
    timerId: null,
    timeRemaining:0,
    timeBox: document.querySelector('.time-display .display-box'),
    cupBox: document.querySelector('.cup-display .display-box'),
    powerOn:false,
    waterLevel:100,
    beanLevel:100,
    milkLevel:100,
    cupsUsed:0,
    chamberLevel:0,
    dispenserLevel:0
}


let power = document.querySelector('.power-button')

updateAllLevels()
checkMinimumLevels()

power.addEventListener('click',actionOnPowerClick )

let allElements = document.querySelectorAll('*')

function actionOnPowerClick() {
    if (power.innerText==='on') {
        globalVariables.powerOn= false
        power.innerText='off'
        for(let i of allElements) {
            if(i.classList.contains('on')) {
                i.classList.remove('on')
            }
        }
    } else if (power.innerText==='off') {
        updateAllLevels()
        checkMinimumLevels()
        globalVariables.powerOn= true
        power.innerText='on'
        processes.heating()
    }
}


let knobs= document.querySelectorAll('.knob')
let leds=document.querySelectorAll('.led')

knobs.forEach((knob) => {
    knob.addEventListener('click', (knob) => {
        actionOnKnobClick(knob)
    })
})

function actionOnKnobClick(knob) {
    if(!isOn()) return 0
    if(isHold()) return 0
    let divNum = knobSelector(knob.currentTarget.parentElement.classList[0])
    knobSwitch(divNum)
}

function knobSelector(ledName) {
    let divNum
    switch (ledName) {
        case 'coffee-knob':
            divNum=0
            break
        case 'latte-knob':
            divNum=2
            break
        case 'hot-water-knob':
            divNum=1
            break
    }
    return divNum
}


function knobSwitch(divNum) {
    for(let i=0; i<3;i++) {
        let led=knobs[i].querySelector('.led')
        if(i === divNum) {
            led.classList.add('on')
        }else {
            led.classList.remove('on')
        }
    }
}



let cupSelector= document.querySelector('.cup-selector')
let carafeSelector =document.querySelector('.carafe-selector')

cupSelector.addEventListener('click', actionOnCupClick)

carafeSelector.addEventListener('click', actionOnCarafeClick)

function actionOnCupClick () {
    if(!isOn()) return 0
    if(isHold()) return 0
    let selectedTypeNum = isTypeSelected()
    if(selectedTypeNum===-1) {
        alert('select a type first')
        return 0
    }
    if(selectedTypeNum===0) {
        createCoffee(1)
    } else if (selectedTypeNum===1) {
        createWater(1)
    } else if (selectedTypeNum===2) {
        createLatte(1)
    }
}

function actionOnCarafeClick() {
    if(!isOn()) return 0
    if(isHold()) return 0
    let selectedTypeNum = isTypeSelected()
    if(selectedTypeNum===-1) {
        alert('select a type first')
        return 0
    }
    if(selectedTypeNum===0) {
        createCoffee(4)
    } else if (selectedTypeNum===1) {
        createWater(4)
    } else if (selectedTypeNum===2) {
        createLatte(4)
    }
}

function isTypeSelected() {
    for(let i=0 ; i<3 ;i++) {
        if(leds[i].classList.contains('on')) {
            return i
        }
    }
    return -1
}

let levelInputs = document.querySelectorAll('input')

for(let i in levelInputs) {
    levelInputs[i].addEventListener('input',updateAllLevels)
}
    
function updateAllLevels() {
    updateBeanLevel(0)
    updateMilkLevel(0)
    updateWaterLevel(0)
}