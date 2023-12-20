const frontsetup = document.getElementById('front')
const backsetup = document.getElementById('back')
const rightsetup = document.getElementById('right')
const leftsetup = document.getElementById('left')
const zoneorder = document.getElementById('zone-order')
const zonetime = document.getElementById('zone-time')
const ordervaluedisp = document.querySelector('.order-value')
const saveconfig = document.querySelector('.save-config')
const runmodeinput = document.getElementById('run-mode-input')
const rightindicator = document.getElementsByClassName('right-ind')[0]
const leftindicator = document.getElementsByClassName('left-ind')[0]
const backindicator = document.getElementsByClassName('back-ind')[0]
const frontindicator = document.getElementsByClassName('front-ind')[0]
const seconds = document.getElementById('sec')
let state =true;
let jsonData;


(async () => {
    const res = await fetch('/data.json')
    jsonData = await res.json()
    setupEventListeners(jsonData)
    runmode(jsonData)
})()

function setupEventListeners(jsonData,state) {
    frontsetup.addEventListener('click',()=>{
        clearconfig()
        frontsetup.classList.add('enable')
        loadconfig(jsonData,'front')
        savezoneconfig(jsonData,'front')
    })
    backsetup.addEventListener('click',()=>{
        clearconfig()
        backsetup.classList.add('enable')
        loadconfig(jsonData,'back')
        savezoneconfig(jsonData,'back')
    })
    rightsetup.addEventListener('click',()=>{
        clearconfig()
        rightsetup.classList.add('enable')
        savezoneconfig(jsonData,'right')
    })
    leftsetup.addEventListener('click',()=>{
        clearconfig()
        leftsetup.classList.add('enable')
        loadconfig(jsonData,'left')
        savezoneconfig(jsonData,'left')
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
    const currentorder = foundzone.order

    //display time
    zonetime.value = foundzone.time
}


function savezoneconfig(jsonData,name) {
    saveconfig.addEventListener('click',()=> {
        const foundRecordindex = jsonData.zones.findIndex(record => record.zone == name);
        jsonData.zones[foundRecordindex].time = zonetime.value
        jsonData.zones[foundRecordindex].order = Number(zoneorder.value)

        loadconfig(jsonData,name)
    })

    loadconfig(jsonData,name)
}

function runmode(jsonData) {
    runmodeinput.addEventListener('click',async ()=>{
        if(runmodeinput.checked) {
            clearconfig()
            state = false
            let sec = 1
            const sortedzones = jsonData.zones.sort((a,b) => a.order - b.order)
            seconds.innerHTML = sec 

            indicator(sortedzones[0].zone,sortedzones[0].time)
            const a = setInterval(() => {
                sec+=1
                seconds.innerHTML = sec 
            },1000);

            const b = setInterval(() =>
            {
                indicator(sortedzones[1].zone,sortedzones[1].time)

            const c = setInterval(() => {
                    indicator(sortedzones[2].zone,sortedzones[2].time)
            }, sortedzones[2].time*1000);

            const d = setInterval(() => {
                indicator(sortedzones[3].zone,sortedzones[3].time)
            }, sortedzones[1].time*1000);
            clearInterval(b)
            }, sortedzones[2].time*1000);
        } 
    } )
}

function indicator(zone,time) {
    console.log(zone)
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