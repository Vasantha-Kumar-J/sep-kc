const frontsetup = document.getElementById('front')
const backsetup = document.getElementById('back')
const rightsetup = document.getElementById('right')
const leftsetup = document.getElementById('left')
const zoneorder = document.getElementById('zone-order')
const zonetime = document.getElementById('zone-time')
const ordervaluedisp = document.querySelector('.order-value')
const saveconfig = document.querySelector('.save-config')
const runmodeinput = document.getElementById('run-mode-input')
let state =true;
let jsonData;


(async () => {
    const res = await fetch('/data.json')
    jsonData = await res.json()
    setupEventListeners(jsonData,state)
    runmode(jsonData)
})()

function setupEventListeners(jsonData,state) {
    if(state) return 
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
    
    if(!state) return
    const foundzone = jsonData.zones.find((fzone) => fzone.zone === name)
    
    //display order
    zoneorder.value = foundzone.order
    ordervaluedisp.innerText = zoneorder.value
    const currentorder = foundzone.order

    //display time
    zonetime.value = foundzone.time
}


function savezoneconfig(jsonData,name) {

    if(!state) return
    saveconfig.addEventListener('click',()=> {
        const foundRecordindex = jsonData.zones.findIndex(record => record.zone == name);
        jsonData.zones[foundRecordindex].time = zonetime.value
        jsonData.zones[foundRecordindex].order = Number(zoneorder.value)

        loadconfig(jsonData,name)
    })

    loadconfig(jsonData,name)
}

function runmode(jsonData) {
    runmodeinput.addEventListener('click',()=>{
        if(runmodeinput.checked) {
            clearconfig()
            state = false
        }
    } )
}