const frontsetup = document.getElementById('front')
const backsetup = document.getElementById('back')
const rightsetup = document.getElementById('right')
const leftsetup = document.getElementById('left')
const zoneorder = document.getElementById('zone-order')
const zonetime = document.getElementById('zone-time')
const ordervaluedisp = document.querySelector('.order-value')
const saveconfig = document.getElementsByClassName('save-config')[0]
const runmodeinput = document.getElementById('run-mode-input')
const rightindicator = document.getElementsByClassName('right-ind')[0]
const leftindicator = document.getElementsByClassName('left-ind')[0]
const backindicator = document.getElementsByClassName('back-ind')[0]
const frontindicator = document.getElementsByClassName('front-ind')[0]
const seconds = document.getElementById('sec')
const setuppanel = document.getElementsByClassName('setup-mode')[0]
const power = document.getElementsByClassName('power-status-area')[0]
const mainarea =document.getElementsByClassName('main-functional-area')[0]
let foundRecordindex = 4
let one,two,third,fourth
let state =true;
let zonename
let currentorder
let jsonData;


(async () => {
    const res = await fetch('/data.json')
    jsonData = await res.json()
    setupEventListeners(jsonData)
    // savezoneconfig(jsonData,zonename)
    runmode(jsonData)
})()

function setupEventListeners(jsonData) {
    frontsetup.addEventListener('click',()=>{
        clearconfig()
        frontsetup.classList.add('enable')
        loadconfig(jsonData,'front')
    })
    backsetup.addEventListener('click',()=>{
        clearconfig()
        backsetup.classList.add('enable')
        loadconfig(jsonData,'back')
    })
    rightsetup.addEventListener('click',()=>{
        clearconfig()
        rightsetup.classList.add('enable')
        loadconfig(jsonData,'right')
    })
    leftsetup.addEventListener('click',()=>{
        clearconfig()
        leftsetup.classList.add('enable')
        loadconfig(jsonData,'left')
    })
}


function clearconfig() {

    frontsetup.classList.remove('enable')
    backsetup.classList.remove('enable')
    leftsetup.classList.remove('enable')
    rightsetup.classList.remove('enable')

    zoneorder.value = 0
    ordervaluedisp.innerText = 0
    zonetime.value = 0
}

function loadconfig(jsonData,name) {
    const foundzone = jsonData.zones.find((fzone) => fzone.zone === name)
    
    //display order
    zoneorder.value = foundzone.order
    ordervaluedisp.innerText = zoneorder.value
    currentorder = foundzone.order

    //display time
    zonetime.value = foundzone.time
    foundRecordindex = jsonData.zones.findIndex((record) => record.zone == name);   
}

saveconfig.addEventListener('click',()=>{
    if(foundRecordindex === 4) return

    let tosaveorder = zoneorder.value
    const dataexistent = jsonData.zones.findIndex((record) => record.order == tosaveorder)

    if(dataexistent) {
        jsonData.zones[dataexistent].order = currentorder
    }
    jsonData.zones[foundRecordindex].time = zonetime.value
    jsonData.zones[foundRecordindex].order = zoneorder.value
    console.log(jsonData.zones)
})

function runmode(jsonData) {
    runmodeinput.addEventListener('click',async ()=>{
        if(runmodeinput.checked) {
            clearconfig()
            setuppanel.style.pointerEvents = "none"
            sprinkler(jsonData)
        } else {
            setuppanel.style.pointerEvents = "all"
            clearAllIntervals()
        }
    } )
}

function sprinkler(jsonData) {
    let sec = 1
            const sortedzones = jsonData.zones.sort((a,b) => a.order - b.order)
            seconds.innerHTML = sec 

            one = setInterval(() => {
                seconds.innerHTML = sec
                sec += 1
            }, 1000)

            indicator(sortedzones[0].zone,sortedzones[0].time)

            setTimeout(() => {

                clearInterval(one)
                
                two = setInterval(()=>{
                    seconds.innerHTML = sec
                    sec += 1
                }, 1000)
                
                indicator(sortedzones[1].zone,sortedzones[1].time)

                setTimeout(()=>{

                clearInterval(two)

                third = setInterval(()=>{
                    seconds.innerHTML = sec
                    sec += 1
                }, 1000)
                
                indicator(sortedzones[2].zone,sortedzones[2].time)

                setTimeout(() => {

                clearInterval(third)
                fourth = setInterval(()=>{
                    seconds.innerHTML = sec
                    sec += 1
                }, 1000)

                indicator(sortedzones[3].zone,sortedzones[3].time)

                setTimeout(()=>{
                    clearInterval(fourth)
                },sortedzones[3].time*1000)

                }, sortedzones[2].time*1000);
                },sortedzones[1].time*1000)
            },sortedzones[0].time*1000);

}

function indicator(zone,time) {
    if(zone === 'front') {
        frontindicator.classList.add('indicator')
        setTimeout(()=>{
            frontindicator.classList.remove('indicator')
            return
        },time*1000)
    }
    if(zone === 'back') {
        backindicator.classList.add('indicator')
        setTimeout(()=>{
            backindicator.classList.remove('indicator')
            return
        },time*1000)
    }
    if(zone === 'right') {
        rightindicator.classList.add('indicator')
        setTimeout(()=>{
            rightindicator.classList.remove('indicator')
            return
        },time*1000)
    }
    if(zone === 'left') {
        leftindicator.classList.add('indicator')
        setTimeout(()=>{
            leftindicator.classList.remove('indicator')
            return
        },time*1000)
    }
}

mainarea.style.pointerEvents = "none"
power.addEventListener('click',()=>{
    if(power.innerText == 'Off') {
        power.innerText = 'On'
        power.classList.add('indicator')
        mainarea.style.pointerEvents = "all"
    } else{
        mainarea.style.pointerEvents = "none"
        power.innerText = 'Off'
    }
})

zoneorder.addEventListener('click',()=>{
    ordervaluedisp.innerText = zoneorder.value
})

