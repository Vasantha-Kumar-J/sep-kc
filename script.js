(async function(){
    await powerON()
    }
)()
const chamberValue = document.getElementById('chamber_value')
const dispencerValue = document.getElementById('dispencer_value')
let details
 let isProperlyShutDown
  let  totalCupsConsumed 
  let  heating 
  let  purging 
  let  water 
  let  coffeeBeans
  let  milk
let waterToBeReduce
let beanToBeReduce
let milkToBeReduce
let isCup
let isCarafe
const waterIngrediant = document.getElementById('water_level_button')
const waterRequired = document.getElementById('waterRequired')
const beanIngrediant = document.getElementById('bean_level_button')
const beanRequired = document.getElementById('beanRequired')
const milkIngrediant = document.getElementById('milk_level_button')
const milkRequired = document.getElementById('milkRequired')
const hotWater = document.getElementById('water_selection')
const cupSelection = document.getElementsByClassName('cup_selection')[0]
const carafeSelection = document.getElementsByClassName('carafe_selection')[0]
async function powerON(){
    details = await (await fetch('./coffe.json')).json() 
    isProperlyShutDown =details.isProperlyShutDown
    totalCupsConsumed =details.totalCupsConsumed
    heating = details.heating
    purging = details.purging
    water = details.water
    coffeeBeans = details.coffeeBeans
    milk = details.milk
    const cupCount = totalCupsConsumed
    document.getElementById('cup_count').textContent =cupCount
    if(isProperlyShutDown== "True"){
        document.getElementsByClassName('process_type')[1].style.color='red'
         document.getElementById('time').textContent =details.heating
    }
    else{
        document.getElementsByClassName('process_type')[0].style.color='red'
        document.getElementsByClassName('process_type')[1].style.color='red'
    }
    chamberValue.textContent =0
    dispencerValue.textContent =0
}
setInterval(function toMonitorSufficiency(){
   if(water<30){
    waterRequired.textContent = 'Insufficient'
   }
   if(coffeeBeans<30){
    beanRequired.textContent = 'Insufficient'
   }
   if(milk<30){
    milkRequired.textContent = 'Insufficient'
   }
},1000)
waterIngrediant.addEventListener('change',()=>{
     waterRequired.textContent = waterIngrediant.value
})
beanIngrediant.addEventListener('change',()=>{
    beanRequired.textContent = beanIngrediant.value
})
milkIngrediant.addEventListener('change',()=>{
    milkRequired.textContent = milkIngrediant.value
})
cupSelection.addEventListener('click',()=>{
    isCarafe = false
    isCup = true
})
carafeSelection.addEventListener('click',()=>{
    isCarafe = true
    isCup = false
})
hotWater.addEventListener('click',()=>{
    if(isCup){
        water = water -5
    }
    else{
        water = water - 20
    }
})
coffeeBeans.addEventListener('click',()=>{
    if(isCup){
        water = water -5
        coffeeBeans = coffeeBeans- 5
    }
    else{
        water = water -20
        coffeeBeans = coffeeBeans- 20
    }
})