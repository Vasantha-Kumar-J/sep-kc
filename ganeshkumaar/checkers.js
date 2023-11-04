import { globalVariables } from "./index.js";

export function isOn() {
    if(!globalVariables.powerOn) {
        alert('switch on the machine first')
        return false
    } else {
        return true
    }
}

export function isHold() {
    if(globalVariables.hold){
        alert('some process is still running. please wait')
        return true
    } else {
        return false
    }
}
