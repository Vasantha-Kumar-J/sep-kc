let power = document.querySelector('.power-button')
let powerOn=false
power.addEventListener('click',actionOnPowerClick )

let allElements = document.querySelectorAll('*')

function actionOnPowerClick() {
    if (power.innerText==='on') {
        powerOn= false
        power.innerText='off'
        for(let i of allElements) {
            if(i.classList.contains('on')) {
                i.classList.remove('on')
            }
        }
    } else if (power.innerText==='off') {
        powerOn= true
        power.innerText='on'
    }
}


let knobs= document.querySelectorAll('.knob')
let leds=document.querySelectorAll('.led')

knobs.forEach((knob) => {
    knob.addEventListener('click', (knob) => actionOnKnobClick(knob))
})

function actionOnKnobClick(knob) {
    if(!powerOn) {
        alert('switch on the machine first')
        return 0
    }
    let divNum = knobSelector(knob.currentTarget.parentElement.classList[0])
    knobSwitch(divNum)
}

function knobSelector(ledName) {
    let divNum
    switch (ledName) {
        case 'coffee-knob':
            divNum=0
            break
        case 'latte-knob':
            divNum=2
            break
        case 'hot-water-knob':
            divNum=1
            break
    }
    return divNum
}


function knobSwitch(divNum) {
    for(let i=0; i<3;i++) {
        let led=knobs[i].querySelector('.led')
        if(i === divNum) {
            led.classList.add('on')
        }else {
            led.classList.remove('on')
        }
    }
}



let cupSelector= document.querySelector('.cup-selector')
let carafeSelector =document.querySelector('.carafe-selector')

cupSelector.addEventListener('click', actionOnCupClick)

carafeSelector.addEventListener('click', actionOnCarafeClick)

function actionOnCupClick () {
    if(!powerOn) {
        alert('switch on the machine first')
        return 0
    }
    let selectedTypeNum = isTypeSelected()
    if(selectedTypeNum===-1) {
        alert('select a type first')
        return 0
    }
    if(selectedTypeNum===0) {
        createCoffee(1)
    } else if (selectedTypeNum===1) {
        createWater(1)
    } else if (selectedTypeNum===2) {
        createLatte(1)
    }
}

function actionOnCarafeClick() {
    if(!powerOn) {
        alert('switch on the machine first')
        return 0
    }
    let selectedTypeNum = isTypeSelected()
    if(selectedTypeNum===-1) {
        alert('select a type first')
        return 0
    }
    if(selectedTypeNum===0) {
        createCoffee(4)
    } else if (selectedTypeNum===1) {
        createWater(4)
    } else if (selectedTypeNum===2) {
        createLatte(4)
    }
}

function isTypeSelected() {
    for(let i=0 ; i<3 ;i++) {
        if(leds[i].classList.contains('on')) {
            return i
        }
    }
    return -1
}

