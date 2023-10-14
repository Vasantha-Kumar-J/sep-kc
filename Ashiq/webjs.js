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

coffeeJson = {
    "isProperlyShutDown" : true ,
    "totalCupsConsumed" : 38 ,
}

function heating(){
    let elaspedTime = 5 ;
    document.getElementsByClassName("show-stats")[0].innerHTML = elaspedTime;
    document.getElementsByClassName("indicator-leds")[1].style.backgroundColor = "red"
}

function purging(){
    let elaspedTime = 4 ;
    document.getElementsByClassName("show-stats")[0].innerHTML = elaspedTime;
    document.getElementsByClassName("indicator-leds")[0].style.backgroundColor = "red"
}

showIngredientsLevel();
showChamberAndDispenserLevels();
let power = document.getElementById("power-button");
let powerState = power.innerHTML;
power.addEventListener("click",()=>{
    powerState = (powerState=="OFF")? "ON" : "OFF" ;
    power.innerHTML = powerState
});
if(powerState=="ON"){
    document.getElementsByClassName("show-stats")[1].innerHTML = coffeeJson.totalCupsConsumed;
    if(coffeeJson.isProperlyShutDown==true){
        heating();
    }
    else{
        purging();
        heating();
    }
}