import { globalVariables } from "./index.js"
import * as processes from './processes.js'

const sleep = (delay) => new Promise((resolve) => setTimeout(resolve,delay))

export async function createWater(cups) {
    if(globalVariables.waterLevel < 30) {
        alert('some ingredients below minium level')
        return 0
    }

    let usedWater = 5*cups

    updateWaterLevel(usedWater)
    fillDispenser(usedWater)
    processes.dispensing()

    await sleep(5000)

    emptyDispenser()
    updateCups(cups)
}

export async function createCoffee(cups) {

    if(globalVariables.waterLevel < 30 || globalVariables.beanLevel < 30) {
        alert('some ingredients below minium level')
        return 0
    }
    let usedBean = 5*cups
    let usedWater = 5*cups

    updateBeanLevel(usedBean)
    fillChamber(usedBean)

    processes.grinding()
    await sleep(3000)

    updateWaterLevel(usedWater)
    fillChamber(usedWater)

    processes.brewing()
    await sleep(4000)

    fillDispenser(globalVariables.chamberLevel)
    emptyChamber()

    processes.dispensing()
    await sleep(5000)

    emptyDispenser()
    updateCups(cups)
}

export async function createLatte(cups) {
    if(globalVariables.waterLevel < 30 || globalVariables.milkLevel < 30 || globalVariables.beanLevel < 30) {
        alert('some ingredients below minium level')
        return 0
    }

    let usedBean = 5*cups
    let usedWater = 5*cups
    let usedMilk = 5*cups

    updateBeanLevel(usedBean)
    fillChamber(usedBean)

    processes.grinding()
    await sleep(3000)

    updateWaterLevel(usedWater)
    fillChamber(usedWater)

    updateMilkLevel(usedMilk)
    fillChamber(usedMilk)

    processes.brewing()
    await sleep(4000)

    fillDispenser(globalVariables.chamberLevel)
    emptyChamber()

    processes.dispensing()
    await sleep(5000)

    emptyDispenser()
    updateCups(cups)
}

export function updateWaterLevel(usedWater) {
    globalVariables.waterLevel -= usedWater
    document.querySelector('.water-level-container input').value = globalVariables.waterLevel
    document.querySelector('.water-level-container .level-number').innerHTML= globalVariables.waterLevel
}

export function updateBeanLevel(usedBean) {
    globalVariables.beanLevel -= usedBean
    document.querySelector('.bean-level-container input').value = globalVariables.beanLevel
    document.querySelector('.bean-level-container .level-number').innerHTML= globalVariables.beanLevel
}

export function updateMilkLevel(usedMilk) {
    globalVariables.milkLevel -= usedMilk
    document.querySelector('.milk-level-container input').value = globalVariables.milkLevel
    document.querySelector('.milk-level-container .level-number').innerHTML= globalVariables.milkLevel
}


function fillDispenser(amount) {
    globalVariables.dispenserLevel += amount
    document.querySelector('#dispenser-indicator .inner-level').style.height = `${globalVariables.dispenserLevel}%`
}

function fillChamber(amount) {
    globalVariables.chamberLevel += amount
    document.querySelector('#chamber-indicator .inner-level').style.height =`${globalVariables.chamberLevel}%`
}

function emptyChamber() {
    globalVariables.chamberLevel = 0
    document.querySelector('#chamber-indicator .inner-level').style.height ='0%'
}

function emptyDispenser() {
    globalVariables.dispenserLevel = 0
    document.querySelector('#dispenser-indicator .inner-level').style.height ='0%'
}

function updateCups(cups) {
    globalVariables.cupsUsed += cups
    globalVariables.cupBox.innerHTML = globalVariables.cupsUsed
}

