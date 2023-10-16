import { globalVariables } from "./index.js" 

export function heating() {
    globalVariables.hold = true
    let led = document.querySelector('#heating')
    led.classList.add('on')
    globalVariables.timeRemaining = 5
    globalVariables.timeBox.innerHTML = globalVariables.timeRemaining

    timerRunner()
    globalVariables.timerId = setInterval(timerRunner,1000,led)
}

export function purging() {
    globalVariables.hold = true
    let led = document.querySelector('#purging')
    led.classList.add('on')
    globalVariables.timeRemaining = 4

    globalVariables.timeBox.innerHTML = globalVariables.timeRemaining

    timerRunner()
    globalVariables.timerId = setInterval(timerRunner,1000,led)
}

export function grinding() {
    globalVariables.hold = true
    let led = document.querySelector('#grinding')
    led.classList.add('on')
    globalVariables.timeRemaining = 3

    globalVariables.timeBox.innerHTML = globalVariables.timeRemaining

    timerRunner()
    globalVariables.timerId = setInterval(timerRunner,1000,led)
}

export function brewing() {
    globalVariables.hold = true
    let led = document.querySelector('#brewing')
    led.classList.add('on')
    globalVariables.timeRemaining = 4

    globalVariables.timeBox.innerHTML = globalVariables.timeRemaining

    timerRunner()
    globalVariables.timerId = setInterval(timerRunner,1000,led)
}

export function dispensing() {
    globalVariables.hold = true
    let led = document.querySelector('#dispensing')
    led.classList.add('on')
    globalVariables.timeRemaining = 5

    globalVariables.timeBox.innerHTML = globalVariables.timeRemaining

    timerRunner()
    globalVariables.timerId = setInterval(timerRunner,1000,led)
}




function timerRunner(led) {
    if(globalVariables.timeRemaining === 0) {
        clearInterval(globalVariables.timerId)
        led.classList.remove('on')
        globalVariables.timeBox.innerHTML = globalVariables.timeRemaining
        globalVariables.hold = false

        return 0
    }
    globalVariables.timeBox.innerHTML = globalVariables.timeRemaining
    globalVariables.timeRemaining--
}
