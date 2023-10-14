const powerstatus = document.getElementsByClassName("power-status")[0];
const totalCups = document.getElementById("total-cups-used");
const timeelapsed = document.getElementById("elapsed-time");
const heatingstate = document.getElementById("heating-state");
const purgingstate = document.getElementById("purging-state");
const dispensingstate = document.getElementById("dispensing-state");
const waterlevel = document.getElementById("water-level");
const milklevel = document.getElementById("milk-level");
const beanlevel = document.getElementById("bean-level");
const hwaterknob = document.getElementById("hwater-knob");
const coffeeknob = document.getElementById("coffee-knob");
const latteknob = document.getElementById("latte-knob");
const lowwater = document.getElementById("low-water-alert");
const lowmilk = document.getElementById("low-milk-alert");
const lowbean = document.getElementById("low-bean-alert");
const onecup = document.getElementById("one-cup");
const dispenervalue = document.getElementById("dispenser-value");

let flag = 0;
let time = 1;
let item = "hwater";
let dispenserheight = parseInt(dispenervalue.style.height);
async function bootfn() {
  const res = await fetch("./coffee.json");
  jsondata = await res.json();
  powerhandlder(jsondata);
  console.log(jsondata);
}

function powerhandlder(jsondata) {
  powerstatus.addEventListener("click", () => {
    flag = !flag;
    if (flag) {
      powerstatus.innerHTML = "On";
      time = 1;
      loadvalues(jsondata);
      initprocess(jsondata);
      monitorIngredients();
      cuploader();
    } else {
      powerstatus.innerHTML = "Off";
      loadvalues(jsondata);
      timeelapsed = 0
    }
  });
}

function loadvalues(jsondata) {
  if (powerstatus.innerHTML === "On") {
    totalCups.innerHTML = jsondata.totalCupsConsumed;
  } else {
    totalCups.innerHTML = 0;
    timeelapsed.innerHTML = 0;
  }
}

function initprocess(jsondata) {
  if (jsondata.isProperlyShutdown) {
    heatprocess();
  } else {
    purgingprocess();
  }
}

function heatprocess(jsondata) {
  heatingstate.classList.add("process");
  a = setInterval(() => {
    timeelapsed.innerHTML = time;
    time += 1;
  }, 1000);
  setTimeout(() => {
    clearInterval(a);
    heatingstate.classList.remove("process");
  }, 5000);
}

function purgingprocess(jsondata) {
  purgingstate.classList.add("process");
  b = setInterval(() => {
    timeelapsed.innerHTML = time;
    time += 1;
  }, 1000);
  setTimeout(() => {
    clearInterval(b);
    purgingstate.classList.remove("process");
    heatprocess();
  }, 4000);
}

function monitorIngredients() {
  waterlevel.addEventListener("change", () => {
    if (waterlevel.value < 30) {
      hwaterknob.classList.add("disable");
      coffeeknob.classList.add("disable");
      latteknob.classList.add("disable");
      lowwater.classList.add("alert");
    } else {
      hwaterknob.classList.remove("disable");
      coffeeknob.classList.remove("disable");
      latteknob.classList.remove("disable");
      lowwater.classList.remove("alert");
    }
  });
  beanlevel.addEventListener("change", () => {
    if (beanlevel.value < 30) {
      coffeeknob.classList.add("disable");
      latteknob.classList.add("disable");
      lowbean.classList.add("alert");
    } else {
      coffeeknob.classList.remove("disable");
      latteknob.classList.remove("disable");
      lowbean.classList.remove("alert");
    }
  });
  milklevel.addEventListener("change", () => {
    if (waterlevel.value < 30) {
      latteknob.classList.add("disable");
      lowmilk.classList.add("alert");
    } else {
      latteknob.classList.remove("disable");
      lowmilk.classList.remove("alert");
    }
  });
}

function cuploader() {
  onecup.addEventListener("click", () => {
    onecuploader("hwater");
  });
}
function onecuploader(item) {
  if (item === "hwater") {
    if (waterlevel < 30) {
      window.alert("LOW WATER");
    } else {
      loaddispencer("8.3%"); // 5units = 8.3% of 100% considering 60 units as limit
      waterlevel.value -= 5
      c = setInterval(() => {
        timeelapsed.innerHTML = time;
        time += 1;
      }, 1000);
      setTimeout(() => {
        clearInterval(c);
        dispensingstate.classList.remove("process");
        jsondata.totalCupsConsumed += 1;
        totalCups.innerHTML = jsondata.totalCupsConsumed;
        dispenervalue.style.height = 0
      }, 5000);
    }
  }
}

function loaddispencer(value) {
  dispenervalue.style.height = value;
  dispensingstate.classList.add("process");
}
bootfn();
