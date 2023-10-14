import { globalVariables } from "./index.js";

function isOn() {
    if(!powerOn) {
        alert('switch on the machine first')
        return 0
    }
}