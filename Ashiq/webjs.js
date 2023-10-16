import * as utils from './script-utils.js'

function showIngredientsLevel(){
    let levelValue = document.getElementsByClassName("ingredients-value");
    for(let i=0;i<levelValue.length;i++){
        document.getElementsByClassName("ingredient-level-value")[i].innerHTML = levelValue[i].value
    }
}

function showChamberAndDispenserLevels(){
    let chamberValue = document.getElementById("chamber").value;
    let dispenserValue = document.getElementById("dispenser").value;
    document.getElementsByClassName("chamber-and-dispenser")[0].innerHTML = chamberValue;
    document.getElementsByClassName("chamber-and-dispenser")[1].innerHTML = dispenserValue;
    
}

let elaspedTime ;
function heating(){
    elaspedTime = elaspedTime + 5 ;
    document.getElementsByClassName("show-stats")[0].innerHTML = elaspedTime;
    document.getElementsByClassName("indicator-leds")[4].style.backgroundColor = "green"
}

function purging(){
    elaspedTime = elaspedTime + 4 ;
    document.getElementsByClassName("show-stats")[0].innerHTML = elaspedTime;
    document.getElementsByClassName("indicator-leds")[0].style.backgroundColor = "green"
}
setInterval(checkMinimumLevel , 10) ;

function checkMinimumLevel(){
    let waterLevel = document.getElementsByClassName("ingredients-value")[0].value;
    let beanLevel = document.getElementsByClassName("ingredients-value")[1].value;
    let milkLevel = document.getElementsByClassName("ingredients-value")[2].value;
    if(waterLevel < 30){
        for(let i=0;i<3;i++) document.getElementsByClassName("checkbox")[i].disabled = true ;
    }
    else if(beanLevel < 30){
        document.getElementsByClassName("checkbox")[0].disabled = true ;
        document.getElementsByClassName("checkbox")[1].disabled = false ;
        document.getElementsByClassName("checkbox")[2].disabled = true ;
    if(milkLevel < 30){
        document.getElementsByClassName("checkbox")[0].disabled = false ;
        document.getElementsByClassName("checkbox")[1].disabled = false ;
        document.getElementsByClassName("checkbox")[2].disabled = true ;
    }
    if(waterLevel > 30 && beanLevel > 30 && milkLevel > 30 ) {
        document.getElementsByClassName("checkbox")[0].disabled = false ;
        document.getElementsByClassName("checkbox")[1].disabled = false ;
        document.getElementsByClassName("checkbox")[2].disabled = false ;
    }
}
}

function dispenseHotWater(){
    utils.dispense.value = parseInt(utils.dispense.value) + parseInt(utils.variables.isCupOrCarafe == 'cup' ? 5 : 20) ;
    utils.water.value = utils.water.value - parseInt(utils.variables.isCupOrCarafe == 'cup' ? 5 : 20) ;
    utils.dispenseLed.style.backgroundColor = "green" ;
    elaspedTime = elaspedTime + 5 ;
    utils.coffeeJson.totalCupsConsumed += (utils.variables.isCupOrCarafe == 'cup' ? 1 : 4)
}

showIngredientsLevel();
showChamberAndDispenserLevels();
let power = document.getElementById("power-button");
let powerState = power.innerHTML;
utils.water.addEventListener("input",showIngredientsLevel);
utils.bean.addEventListener("input",showIngredientsLevel);
utils.milk.addEventListener("input",showIngredientsLevel);
utils.chamber.addEventListener("input",showChamberAndDispenserLevels);
utils.dispense.addEventListener("input",showChamberAndDispenserLevels);
power.addEventListener("click",()=>{
    powerState = (powerState=="OFF")? "ON" : "OFF" ;
    power.innerHTML = powerState
    if(powerState==="ON"){
        document.getElementsByClassName("show-stats")[1].innerHTML = utils.coffeeJson.totalCupsConsumed;
        if(utils.coffeeJson.isProperlyShutDown==true){
            elaspedTime = 0;
            heating();
        }
        else{
            elaspedTime = 0 ;
            purging();
            heating();
        }
        utils.clickCup.addEventListener("click",()=>{
            elaspedTime = 0;
            utils.variables.isCupOrCarafe = "cup";
            dispenseHotWater();
            showIngredientsLevel();
            showChamberAndDispenserLevels();
        })
        utils.clickCarafe.addEventListener("click",()=>{
            elaspedTime = 0;
            utils.variables.isCupOrCarafe = "carafe";
            dispenseHotWater();
            showIngredientsLevel();
            showChamberAndDispenserLevels();
        })
    }
});
