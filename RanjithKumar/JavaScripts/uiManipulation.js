const timeDisplay = document.getElementById('time-display')
const cupsElement = document.getElementById('cups-display')

/**
 * Function to display the total cups dispensed
 * @param {string} cups total cups dispensed
 */
export function displayTotalCups (cups) {
  cupsElement.innerHTML = parseInt(cupsElement.innerHTML) + cups
}

/**
 * Function to change the time in the UI
 * @param {string} time time elapsed for the the process
 */
export function displayTimeElapsed (time) {
  timeDisplay.innerHTML = time
}

export function turnOnLed(id) {
  document.getElementById(id).classList.add('led-on')
}

export function turnOffLed(id) {
  document.getElementById(id).classList.remove('led-on')
}

export function transferUnits(from, to, units){
  document.getElementById(from).value -= units
  if(to) document.getElementById(to).value = parseInt(document.getElementById(to).value) + units
}