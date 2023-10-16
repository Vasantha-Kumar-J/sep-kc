const timeDisplay = document.getElementById('time-display')
const cupsElement = document.getElementById('cups-display')
const beverageSelectionInputs = document.querySelectorAll('.beverage-selection-buttons')

/**
 * Function to display the total cups dispensed
 * @param {string} cups total cups dispensed
 */
export function displayTotalCups (cups) {
  cupsElement.innerHTML = parseInt(cupsElement.innerHTML) + cups
  return parseInt(cupsElement.innerHTML)
}

/**
 * Function to change the time in the UI
 * @param {string} time time elapsed for the the process
 */
export function displayTimeElapsed (time) {
  timeDisplay.innerHTML = time
}

/**
 * Function to turn the led ON
 * @param {string} id led element id
 */
export function turnOnLed(id) {
  document.getElementById(id).classList.add('led-on')
}

/**
 * Function to turn the led OFF
 * @param {string} id led element id
 */
export function turnOffLed(id) {
  document.getElementById(id).classList.remove('led-on')
}

/**
 * function to indicate the low level Led's
 * @param {string} led id of the element
 */
export function indicateLowLevel(led) {
  document.getElementById(led).style.backgroundColor = 'orange'
}

/**
 * Function to disable the single input element 
 * @param {string} elementId elements id
 */
export function disableElement(elementId) {
  document.getElementById(elementId).disabled = true
}

/**
 * Function to control the activeness of the inputs 
 * @param {boolean} activeness active or deactivate the input boolean
 */
export function controlAllInputs(activeness) {
  document.getElementById('cup-selector').disabled = activeness
  document.getElementById('carafe-selector').disabled = activeness
  beverageSelectionInputs.forEach((element) => element.disabled = activeness)
}

/**
 * Function tot reset the state of all the input elements
 */
export function resetAllInputs() {
  document.getElementById('cup-selector').checked = false
  document.getElementById('carafe-selector').checked = false
  beverageSelectionInputs.forEach((element) => element.checked = false)
}

/**
 * Function to transfer the unit substance from one element to another element
 * @param {string} from element reduce the unit
 * @param {string} to element to add the units
 * @param {number} units amount of units to be transferred
 */
export function transferUnits(from, to, units){
  document.getElementById(from).value -= units
  if(to) document.getElementById(to).value = parseInt(document.getElementById(to).value) + units
}