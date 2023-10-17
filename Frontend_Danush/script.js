const powerstatus = document.getElementsByClassName('power-status')[0]
const totalCups = document.getElementById('total-cups-used')
let timeelapsed = document.getElementById('elapsed-time')
const heatingstate = document.getElementById('heating-state')
const purgingstate = document.getElementById('purging-state')
const dispensingstate = document.getElementById('dispensing-state')
const grindingstate = document.getElementById('grinding-state')
const brewingstate = document.getElementById('brewing-state')
const waterlevel = document.getElementById('water-level')
const milklevel = document.getElementById('milk-level')
const beanlevel = document.getElementById('bean-level')
const hwaterknob = document.getElementById('hwater-knob')
const coffeeknob = document.getElementById('coffee-knob')
const latteknob = document.getElementById('latte-knob')
const lowwater = document.getElementById('low-water-alert')
const lowmilk = document.getElementById('low-milk-alert')
const lowbean = document.getElementById('low-bean-alert')
const onecup = document.getElementById('one-cup')
const onecaraffe = document.getElementById('one-caraffe')
const dispenervalue = document.getElementById('dispenser-value')
const chambervalue = document.getElementById('chamber-value')

let flag = 0
let time = 1
let process = 0
let wateravail = 1
let coffeeavail = 1
let latteavail = 1
// let item = 'hwater'
let dispenserheight = parseInt(dispenervalue.style.height)

async function bootfn() {
  const res = await fetch('./coffee.json')
  jsondata = await res.json()
  powerhandlder(jsondata)
}

function powerhandlder(jsondata) {
  powerstatus.addEventListener('click', () => {
    flag = !flag
    if (flag) {
      powerstatus.innerHTML = 'On'
      time = 1
      loadvalues(jsondata)
      initprocess(jsondata)
      fetchitem()
      
      cuploader()
      caraffeloader()
    } else {
      powerstatus.innerHTML = 'Off'
      loadvalues(jsondata)
      timeelapsed.innerHTML = 0
    }
  })
}

function loadvalues(jsondata) {
  if (powerstatus.innerHTML === 'On') {
    totalCups.innerHTML = jsondata.totalCupsConsumed
  } else {
    totalCups.innerHTML = 0
    timeelapsed.innerHTML = 0
  }
}

function initprocess(jsondata) {
  process = 1
  if (jsondata.isProperlyShutdown) {
    heatprocess()
  } else {
    purgingprocess()
  }
}

function heatprocess(jsondata) {
  heatingstate.classList.add('process')
  a = setInterval(() => {
    timeelapsed.innerHTML = time
    time += 1
  }, 1000)
  setTimeout(() => {
    clearInterval(a)
    heatingstate.classList.remove('process')
    process = 0
  }, 5000)
}

function purgingprocess(jsondata) {
  purgingstate.classList.add('process')
  b = setInterval(() => {
    timeelapsed.innerHTML = time
    time += 1
  }, 1000)
  setTimeout(() => {
    clearInterval(b)
    purgingstate.classList.remove('process')
    heatprocess()
  }, 4000)
}

function monitorIngredients ()  {
    if (waterlevel.value < 30) {
      wateravail = 0
      coffeeavail = 0
      latteavail = 0 
      hwaterknob.classList.add('disable')
      coffeeknob.classList.add('disable')
      latteknob.classList.add('disable')
      lowwater.classList.add('alert')
    } 

    if (beanlevel.value < 30) {
      coffeeavail = 0
      latteavail = 0
      coffeeknob.classList.add('disable')
      latteknob.classList.add('disable')
      lowbean.classList.add('alert')
    }

    if (milklevel.value < 30) {
      latteavail = 0 
      latteknob.classList.add('disable')
      lowmilk.classList.add('alert')
    }
}

function cuploader() {
  onecup.addEventListener('click', () => {
    if(!process) {
      onecuploader(item)
      process = 1
    }
  })
}

function caraffeloader() {
  onecaraffe.addEventListener('click', () => {
   if (!process) {
    onecaraffeloader(item)
    process = 1
   }
  })
}
function onecuploader(item) {
  time = 1
  if (item === 'hwater') {
    if (wateravail) {
      loaddispencer('8.3%') // 5units = 8.3% of 100% considering 60 units as limit
      waterlevel.value -= 5
      
      c = setInterval(() => {
        timeelapsed.innerHTML = time
        time += 1
      }, 1000)
      setTimeout(() => {
        clearInterval(c)
        dispensingstate.classList.remove('process')
        jsondata.totalCupsConsumed += 1
        totalCups.innerHTML = jsondata.totalCupsConsumed
        dispenervalue.style.height = 0
        process = 0
      }, 5000)
    }
  } else if ( item === 'coffee') {
    if(coffeeavail) {
      loadchamber('8.3%', 'bean')
      beanlevel.value -= 5
      
      bean = setInterval(() => {
        timeelapsed.innerHTML = time
        time += 1
      }, 1000)
      setTimeout(() => {
        clearInterval(bean)
        grindingstate.classList.remove('process')
        loadchamber('16.6%','water')
        waterlevel.level -= 5
        
        water = setInterval(()=>{
          timeelapsed.innerHTML = time
          time += 1
        }, 1000)
        setTimeout(() => {
          clearInterval(water)
          brewingstate.classList.remove('process')
          chambervalue.style.height = 0
          loaddispencer('16.6%')
          coffeecpl = setInterval( ()=> {
            timeelapsed.innerHTML = time
            time += 1
          },1000)
          setTimeout(() => {
            clearInterval(coffeecpl)
            dispensingstate.classList.remove('process')
            jsondata.totalCupsConsumed += 1
            totalCups.innerHTML = jsondata.totalCupsConsumed
            dispenervalue.style.height = 0
            process = 0
          }, 5000)
        }, 4000)
      }, 3000)
    } 
  }
  else if (item === 'latte') {
    if (latteavail) {
      loadchamber('8.3%', 'bean')
      beanlevel.value -= 5
      
      bean = setInterval(() => {
        timeelapsed.innerHTML = time
        time += 1
      }, 1000)
      setTimeout(() => {
        clearInterval(bean)
        grindingstate.classList.remove('process')
        loadchamber('16.6%','milk')
        milklevel.value -= 5
        loadchamber('25%','water')
        waterlevel.value -= 5
        milk = setInterval( () => {
          timeelapsed.innerHTML = time
          time += 1
        }, 1000)
        setTimeout(() => {
          clearInterval(milk)
          brewingstate.classList.remove('process')
          chambervalue.style.height = 0
          loaddispencer('25%')
          coffeecpl = setInterval( ()=> {
            timeelapsed.innerHTML = time
            time += 1
          },1000)
          setTimeout(() => {
            clearInterval(coffeecpl)
            dispensingstate.classList.remove('process')
            jsondata.totalCupsConsumed += 1
            totalCups.innerHTML = jsondata.totalCupsConsumed
            dispenervalue.style.height = 0
            process = 0 
          }, 5000)
        }, 4000)
      }, 3000)
    }
  }
}

fetchitem() 
function fetchitem () {
  hwaterknob.addEventListener('click', () => {
    if(wateravail && !process) {
      item = 'hwater'
    hwaterknob.classList.remove('disable')
    coffeeknob.classList.add('disable')
    latteknob.classList.add('disable')
    }
  })
  coffeeknob.addEventListener('click', () => {
    if(coffeeavail && !process) {
      item = 'coffee'
      coffeeknob.classList.remove('disable')
    hwaterknob.classList.add('disable')
    latteknob.classList.add('disable')
    }
  })
  latteknob.addEventListener('click', () => {
    if (latteavail && !process) {
      item = 'latte'
    latteknob.classList.remove('disable')
    coffeeknob.classList.add('disable')
    hwaterknob.classList.add('disable')
    }
  })
}

function loaddispencer(value) {
  dispenervalue.style.height = value
  dispensingstate.classList.add('process')
}

function loadchamber (value,item) {
  if(item === 'bean') {
    chambervalue.style.height = value
    grindingstate.classList.add('process')
  }
  if(item === 'water' || item === 'milk') {
    chambervalue.style.height = value
    brewingstate.classList.add('process')
  }
}


function onecaraffeloader(item) {
  time = 1
  if (item === 'hwater') {
    if (wateravail) {
      loaddispencer('33.3%')
      waterlevel.value -= 20
      c = setInterval(() => {
        timeelapsed.innerHTML = time
        time += 1
      }, 1000)
      setTimeout(() => {
        clearInterval(c)
        dispensingstate.classList.remove('process')
        jsondata.totalCupsConsumed += 1
        totalCups.innerHTML = jsondata.totalCupsConsumed
        dispenervalue.style.height = 0
        process = 0
      }, 5000)
    }
  } else if ( item === 'coffee') {
    if(coffeeavail) {
      loadchamber('33.3%', 'bean')
      beanlevel.value -= 20
      bean = setInterval(() => {
        timeelapsed.innerHTML = time
        time += 1
      }, 1000)
      setTimeout(() => {
        clearInterval(bean)
        grindingstate.classList.remove('process')
        loadchamber('66.6%','water')
        waterlevel.value -= 20
        water = setInterval(()=>{
          timeelapsed.innerHTML = time
          time += 1
        }, 1000)
        setTimeout(() => {
          clearInterval(water)
          brewingstate.classList.remove('process')
          chambervalue.style.height = 0
          loaddispencer('66.6%')
          coffeecpl = setInterval( ()=> {
            timeelapsed.innerHTML = time
            time += 1
          },1000)
          setTimeout(() => {
            clearInterval(coffeecpl)
            dispensingstate.classList.remove('process')
            jsondata.totalCupsConsumed += 1
            totalCups.innerHTML = jsondata.totalCupsConsumed
            dispenervalue.style.height = 0
            process = 0
          }, 5000)
        }, 4000)
      }, 3000)
    } 
  }
  else if (item === 'latte') {
    if (latteavail) {
      loadchamber('33.3%', 'bean')
      beanlevel.value -= 20
      bean = setInterval(() => {
        timeelapsed.innerHTML = time
        time += 1
      }, 1000)
      setTimeout(() => {
        clearInterval(bean)
        grindingstate.classList.remove('process')
        loadchamber('66.6%','milk')
        milklevel.value -= 20
        loadchamber('100%','water')
        waterlevel.value -= 20
        milk = setInterval( () => {
          timeelapsed.innerHTML = time
          time += 1
        }, 1000)
        setTimeout(() => {
          clearInterval(milk)
          brewingstate.classList.remove('process')
          chambervalue.style.height = 0
          loaddispencer('100%')
          coffeecpl = setInterval( ()=> {
            timeelapsed.innerHTML = time
            time += 1
          },1000)
          setTimeout(() => {
            clearInterval(coffeecpl)
            dispensingstate.classList.remove('process')
            jsondata.totalCupsConsumed += 1
            totalCups.innerHTML = jsondata.totalCupsConsumed
            dispenervalue.style.height = 0
            process = 0 
          }, 5000)
        }, 4000)
      }, 3000)
    }
  }
}

function monitor () {
  monitorIngredients()
  setInterval(() => {
    monitorIngredients()
    console.log(process)
  }, 100)
}

monitor()
bootfn()
