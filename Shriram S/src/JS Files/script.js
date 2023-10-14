import * as scriptUtils from './importExports.js'

(async function () {
    scriptUtils.fetchUtils.variables.machineStatus = await scriptUtils.fetchUtils.fetchData('../../Assets/Coffee.json')
    addEventListeners()
}) ()

function addEventListeners() {
    document.getElementsByClassName('power-status')[0].addEventListener('click', function(){
        const machineStatus = scriptUtils.fetchUtils.variables.machineStatus

        if(machineStatus.isProperlyShutDown === true) {
            scriptUtils.fetchUtils.variables.machineStatus.isProperlyShutDown = 'false'
            this.style.backgroundColor = "rgb(68, 121, 68)"
            this.textContent = 'On'

            scriptUtils.generalUtils.displayTotalCups(machineStatus.totalCupsConsumed)
            scriptUtils.generalUtils.heatMachine()
        }   else {
            scriptUtils.fetchUtils.variables.machineStatus.isProperlyShutDown = 'true'
            this.style.backgroundColor = "rgb(35, 35, 89)"
            this.textContent = 'Off'
            // this.reset()
        }
    })
}
