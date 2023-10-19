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

let elaspedTime = 0 ;
function heating(){
    // elaspedTime = (utils.variables.isCupOrCarafe == 'cup') ? elaspedTime + 5 : (elaspedTime + 5 )*4;
    elaspedTime +=5;
    setTimeout(()=>{document.getElementsByClassName("indicator-leds")[4].style.backgroundColor = '#8FAADC'},elaspedTime*1000)
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
    if(waterLevel < 30 || beanLevel < 30 || milkLevel < 30){
    
    if(milkLevel < 30){
        document.getElementsByClassName("checkbox")[0].disabled = false ;
        document.getElementsByClassName("checkbox")[1].disabled = false ;
        document.getElementsByClassName("checkbox")[2].disabled = true ;
        utils.lowMilkLed.style.backgroundColor = "red" 
    }
    // if(waterLevel > 30 && beanLevel > 30 && milkLevel > 30 ) {
    else {
        // document.getElementsByClassName("checkbox")[0].disabled = false ;
        // document.getElementsByClassName("checkbox")[1].disabled = false ;
        // document.getElementsByClassName("checkbox")[2].disabled = false ;
        
        utils.lowMilkLed.style.backgroundColor = "#8FAADC"
    }
    // }
    if(beanLevel < 30){
        document.getElementsByClassName("checkbox")[0].disabled = true ;
        document.getElementsByClassName("checkbox")[1].disabled = false ;
        document.getElementsByClassName("checkbox")[2].disabled = true ;
        utils.lowBeanLed.style.backgroundColor = "red" ;
    }
    else {
        // document.getElementsByClassName("checkbox")[0].disabled = false ;
        // document.getElementsByClassName("checkbox")[1].disabled = false ;
        // document.getElementsByClassName("checkbox")[2].disabled = false ;
        utils.lowBeanLed.style.backgroundColor = "#8FAADC" ;
    }
    if(waterLevel < 30){
        for(let i=0;i<3;i++) document.getElementsByClassName("checkbox")[i].disabled = true ;
        utils.lowWaterLed.style.backgroundColor = "red"
    }
    else {
        utils.lowWaterLed.style.backgroundColor = "#8FAADC"
    }
    }
    else{        
        for(let i=0;i<3;i++) document.getElementsByClassName("checkbox")[i].disabled = false ;
        utils.lowMilkLed.style.backgroundColor = "#8FAADC"
        utils.lowBeanLed.style.backgroundColor = "#8FAADC"
        utils.lowWaterLed.style.backgroundColor = "#8FAADC"
    }
    
    
}

function grinding(){
    // elaspedTime = (utils.variables.isCupOrCarafe == 'cup') ? elaspedTime + 3 : (elaspedTime + 3 )*4;
    elaspedTime+=3
    setTimeout(() => {
        utils.grindLed.style.backgroundColor = 'green'
        utils.bean.value = utils.bean.value - parseInt(utils.variables.isCupOrCarafe == 'cup' ? 5 : 20) ;
        utils.chamber.value = parseInt(utils.chamber.value) + parseInt(utils.variables.isCupOrCarafe == 'cup' ? 5 : 20) ;
        showIngredientsLevel();
        showChamberAndDispenserLevels()
    }, 5000);
    setTimeout(() => {
        utils.grindLed.style.backgroundColor = '#8FAADC'
    }, 8000);
    utils.showelaspedTime.innerHTML = elaspedTime
}

function brewing(){
    // elaspedTime = (utils.variables.isCupOrCarafe == 'cup') ? elaspedTime + 4 : (elaspedTime + 4 )*4 ;
    elaspedTime+=4
    setTimeout(() => {
        utils.brewingLed.style.backgroundColor = 'green'
        
        utils.water.value = utils.water.value - parseInt(utils.variables.isCupOrCarafe == 'cup' ? 5 : 20)
        if(document.querySelector('input[name="beverage"]:checked').value == 'latte' ){
            utils.milk.value = utils.milk.value - parseInt(utils.variables.isCupOrCarafe == 'cup' ? 5 : 20)
            
        }
        utils.chamber.value = parseInt(utils.chamber.value) + parseInt(utils.variables.isCupOrCarafe == 'cup' ? 5 : 20) ;        showIngredientsLevel();
        showChamberAndDispenserLevels()
    }, 8000);
    setTimeout(() => {
        utils.brewingLed.style.backgroundColor = '#8FAADC'
        utils.dispenser.value = utils.chamber.value
        utils.chamber.value = '0';
        utils.showChamber.innerHTML = '0'
    }, 12000);
    utils.showelaspedTime.innerHTML = elaspedTime
    console.log(elaspedTime);
}
let promiseProcessComplete ;
function dispensing(time = [12000,18000]){
    elaspedTime+=5;
    setTimeout(()=>{
        let reduce = parseInt(utils.dispenser.value) / 5;
        utils.dispenseLed.style.backgroundColor = "green" 
        let intervalId = setInterval(() => {
            utils.dispenser.value = parseInt(utils.dispenser.value) - reduce ;
            utils.showDispenser.innerHTML = utils.dispenser.value ;
            if(parseInt(utils.dispenser.value)==0) clearInterval(intervalId);
        }, 1000);
    },time[0]);
    utils.showelaspedTime.innerHTML = elaspedTime
    utils.showDispenser.innerHTML = utils.dispenser.value ;
    promiseProcessComplete = new Promise((resolve,reject)=>{
        setTimeout(()=>{
            utils.dispenseLed.style.backgroundColor = "#8FAADC" 
            resolve();
        },time[1])
    })
    
}

function dispenseCoffee(){
    // utils.chamber.value = parseInt(utils.chamber.value) + parseInt(utils.variables.isCupOrCarafe == 'cup' ? 5 : 20) ;
    // utils.bean.value = utils.bean.value - parseInt(utils.variables.isCupOrCarafe == 'cup' ? 5 : 20) ;
    grinding() 
    // utils.chamber.value = parseInt(utils.chamber.value) + parseInt(utils.variables.isCupOrCarafe == 'cup' ? 5 : 20) ;
    // utils.water.value = utils.water.value - parseInt(utils.variables.isCupOrCarafe == 'cup' ? 5 : 20)
    brewing();
    // elaspedTime+=5;
    dispensing();
    // dispensing();
}
function dispenseLatte(){
    // utils.chamber.value = parseInt(utils.chamber.value) + parseInt(utils.variables.isCupOrCarafe == 'cup' ? 5 : 20) ;
    // utils.bean.value = utils.bean.value - parseInt(utils.variables.isCupOrCarafe == 'cup' ? 5 : 20) ;
    grinding() 
    // utils.chamber.value = parseInt(utils.chamber.value) + parseInt(utils.variables.isCupOrCarafe == 'cup' ? 5 : 20) ;
    // utils.water.value = utils.water.value - parseInt(utils.variables.isCupOrCarafe == 'cup' ? 5 : 20)
    
    brewing();
    // elaspedTime+=5;
    dispensing();
}
function dispenseHotWater(){
    elaspedTime = 5;
    utils.dispenser.value = parseInt(utils.dispenser.value) + parseInt(utils.variables.isCupOrCarafe == 'cup' ? 5 : 20) ;
    utils.water.value = utils.water.value - parseInt(utils.variables.isCupOrCarafe == 'cup' ? 5 : 20) ;
    // elaspedTime = (utils.variables.isCupOrCarafe == 'cup') ? elaspedTime + 5 : (elaspedTime + 5 )*4;

    // elaspedTime+=5
    // setTimeout(()=>{
    //     utils.dispenseLed.style.backgroundColor = "green" 
    //     let reduce = parseInt(utils.dispenser.value) / 5;
    //     let intervalId = setInterval(() => {
    //         utils.dispenser.value = parseInt(utils.dispenser.value) - reduce ;
    //         utils.showDispenser.innerHTML = utils.dispenser.value ;
    //         if(parseInt(utils.dispenser.value)==0) clearInterval(intervalId);
    //     }, 1000);
    // },(elaspedTime/2)*1000);
    // setTimeout(()=>{utils.dispenseLed.style.backgroundColor = "#8FAADC" },elaspedTime*1000)
    // utils.coffeeJson.totalCupsConsumed += (utils.variables.isCupOrCarafe == 'cup' ? 1 : 4)

    dispensing([5000,10000]);

    utils.showtotalCupsConsumed.innerHTML = utils.coffeeJson.totalCupsConsumed ;
    utils.showelaspedTime.innerHTML = elaspedTime
    // powerState = 'OFF' ;
    // power.innerHTML = powerState
}
setInterval(() => {
    if(parseInt(utils.showelaspedTime.innerHTML) > 0) {
        utils.showelaspedTime.innerHTML = parseInt(utils.showelaspedTime.innerHTML) - 1; 
    }
}, 1000);


showIngredientsLevel();
showChamberAndDispenserLevels();
let power = document.querySelector("#power-button > p");
let powerState = power.innerHTML;
utils.water.addEventListener("input",showIngredientsLevel);
utils.bean.addEventListener("input",showIngredientsLevel);
utils.milk.addEventListener("input",showIngredientsLevel);
utils.chamber.addEventListener("input",showChamberAndDispenserLevels);
utils.dispenser.addEventListener("input",showChamberAndDispenserLevels);
utils.clickCup.addEventListener("click",()=>{
    // elaspedTime = 0;     
    utils.variables.isCupOrCarafe = "cup";
    document.getElementsByClassName('units-selection')[0].style.border = "5px inset #44546A"
    document.getElementsByClassName('units-selection')[1].style.border = "5px solid #44546A"
    utils.coffeeJson.totalCupsConsumed += (utils.variables.isCupOrCarafe == 'cup' ? 1 : 4)
    utils.showtotalCupsConsumed.innerHTML = utils.coffeeJson.totalCupsConsumed ;
    // dispenseHotWater();
    // showIngredientsLevel();
    // showChamberAndDispenserLevels();
})
utils.clickCarafe.addEventListener("click",()=>{
    // elaspedTime = 0;
    utils.variables.isCupOrCarafe = "carafe";
    document.getElementsByClassName('units-selection')[1].style.border = "5px inset #44546A"
    document.getElementsByClassName('units-selection')[0].style.border = "5px solid #44546A"
    utils.coffeeJson.totalCupsConsumed += (utils.variables.isCupOrCarafe == 'cup' ? 1 : 4)
    utils.showtotalCupsConsumed.innerHTML = utils.coffeeJson.totalCupsConsumed ;
    // dispenseHotWater();
    // showIngredientsLevel();
    // showChamberAndDispenserLevels();
})

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
        if(document.querySelector('input[name="beverage"]:checked').value == 'hot-water'){
            dispenseHotWater();
            showIngredientsLevel();
            showChamberAndDispenserLevels();
            
        }
        else if(document.querySelector('input[name="beverage"]:checked').value == 'coffee'){
            dispenseCoffee();
            showIngredientsLevel();
            showChamberAndDispenserLevels();
            
        }
        else {
            dispenseLatte();
            showIngredientsLevel();
            showChamberAndDispenserLevels();
        }
        promiseProcessComplete .then((result) => {
            powerState = 'OFF' ;
        power.innerHTML = powerState
        }).catch((err) => {
            
        });
    }
});
