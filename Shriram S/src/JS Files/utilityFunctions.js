// Elapsed Time for various functions
const elapsedTime = {
    'heating' : 5,
    'purging' : 4
}

/**
 * Function to display the number of cups available,in the UI
 * @param {Number} cupsCount 
 */
export function displayTotalCups(cupsCount) {
    const cupsConfig = document.getElementsByClassName('show-total-cups')[0]
    cupsConfig.textContent = cupsCount
}

/**
 * When the properShutdown is true --> Heating process has to be done
 */
export function heatMachine() {
    const configElapsedTime = document.getElementsByClassName('show-elapsed-time')[0]

    const totalElapsedTime = calculateElapsedTime(['heating'])

    const heating = document.getElementsByClassName('heating')[0]
    heating.classList.add('run-heating-process')
    setTimeout(() => {
        heating.classList.remove('run-heating-process')
        configElapsedTime.textContent = totalElapsedTime
    }, totalElapsedTime*1000)
}

/**
 * When the properShutdown is false --> Purging has to be done first and then followed by heating process
 */
export function purgeAndHeatMachine() {
    const configElapsedTime = document.getElementsByClassName('show-elapsed-time')[0]
    const totalElapsedTime = calculateElapsedTime(['purging','heating'])

    setTimeout(() => {
        configElapsedTime.textContent = totalElapsedTime
    }, totalElapsedTime*1000)
}

/**
 * 
 * @param {Array} processDone - All the various process that are all involved in the system
 * @returns {Number} - The total elapsed time for all the process
 */
function calculateElapsedTime(processDone) {
    let totalElapsedTime = 0
    for(const process of processDone) {
        totalElapsedTime += elapsedTime[process]
    }
    return totalElapsedTime
}
