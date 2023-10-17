import { globalVariables } from "./index.js"
import * as processes from './processes.js'

export function createWater(cups) {
    let usedWater = 5*cups
    globalVariables.waterLevel -= usedWater
    document.querySelector('.water-level-container input').value = globalVariables.waterLevel
    document.querySelector('.water-level-container .level-number').innerHTML= globalVariables.waterLevel
    
    document.querySelector('#dispenser-indicator .inner-level').style.height = `${usedWater}%`
    processes.dispensing()
    
}