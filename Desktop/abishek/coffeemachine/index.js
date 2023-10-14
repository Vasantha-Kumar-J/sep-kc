let data = await fetch('/coffee.json')
data = await data.json()
console.log(data)
let intervalId=null
const sleep = (delay) => new Promise((resolve) => setTimeout(resolve, delay))

document.querySelector('#power-on').addEventListener('click', startMachine)

async function startMachine()
{   if(data.isProperlyShutdown === true)
    { 
       await Process('.heat', 3000) 
    }
    else
    {   await Process('.purning', 4000)
        await Process('.heat', 5000)

    }
    document.querySelector('#total-cup-count').innerHTML =data.totalCupsConsumed
    document.querySelector('#cup').addEventListener('click', cup )
    document.querySelector('#carafe').addEventListener('click', carafe )

}

async function cup()
{  
       let selectedOption=''
        var ele = document.getElementsByTagName('input');
        for ( let i = 0; i < 3; i++) {
            if (ele[i].type = "radio") {
           
                if (ele[i].checked)
                selectedOption=ele[i].value
                   
            }

        }
    
         
        if(selectedOption==='Hot water')
        {   document.getElementById('water-level').value =  document.getElementById('water-level').value -5;
            document.querySelector('.water').innerHTML= document.getElementById('water-level').value
            console.log(document.querySelector('#water-level').value);
            await Process('.dispensing',5000)
            data.totalCupsConsumed+=1
            document.querySelector('#total-cup-count').innerHTML =data.totalCupsConsumed

        }
        if(selectedOption==='coffee')
        {   
            data.totalCupsConsumed+=1
            document.querySelector('#total-cup-count').innerHTML =data.totalCupsConsumed
             document.getElementById('water-level').value =  document.getElementById('water-level').value -5;
             document.querySelector('.water').innerHTML= document.getElementById('water-level').value
            await Process('.grinding',3000)
            document.getElementById('bean-level').value =  document.getElementById('bean-level').value -5;
            document.querySelector('.bean').innerHTML= document.getElementById('bean-level').value
             await Process('.brewing',4000)
            await Process('.dispensing',5000)
          

        }

        if(selectedOption==='Latte')
        {   
            data.totalCupsConsumed+=1
            document.querySelector('#total-cup-count').innerHTML =data.totalCupsConsumed
             document.getElementById('water-level').value =  document.getElementById('water-level').value -5;
             document.querySelector('.water').innerHTML= document.getElementById('water-level').value
            await Process('.grinding',3000)
            document.getElementById('bean-level').value =  document.getElementById('bean-level').value -5;
            document.getElementById('milk-level').value =  document.getElementById('milk-level').value -5;
            document.querySelector('.bean').innerHTML= document.getElementById('bean-level').value
             await Process('.brewing',4000)
            await Process('.dispensing',5000)
            document.querySelector('.milk').innerHTML= document.getElementById('milk-level').value
          

        }




    
}

async function carafe()
{  
       let selectedOption=''
        var ele = document.getElementsByTagName('input');
        for ( let i = 0; i < 3; i++) {
            if (ele[i].type = "radio") {

                if (ele[i].checked)
                selectedOption=ele[i].value
                   
            }

        }
    
         
        if(selectedOption==='Hot water')
        {   document.getElementById('water-level').value =  document.getElementById('water-level').value -20;
            document.querySelector('.water').innerHTML= document.getElementById('water-level').value
            console.log(document.querySelector('#water-level').value);
            await Process('.dispensing',5000)
            data.totalCupsConsumed+=1
            document.querySelector('#total-cup-count').innerHTML =data.totalCupsConsumed

        }
        if(selectedOption==='coffee')
        {   
            data.totalCupsConsumed+=1
            document.querySelector('#total-cup-count').innerHTML =data.totalCupsConsumed
             document.getElementById('water-level').value =  document.getElementById('water-level').value -20;
             document.querySelector('.water').innerHTML= document.getElementById('water-level').value
            await Process('.grinding',3000)
            document.getElementById('bean-level').value =  document.getElementById('bean-level').value -20;
            document.querySelector('.bean').innerHTML= document.getElementById('bean-level').value
             await Process('.brewing',4000)
            await Process('.dispensing',5000)
          

        }

        if(selectedOption==='Latte')
        {   
            data.totalCupsConsumed+=1
            document.querySelector('#total-cup-count').innerHTML =data.totalCupsConsumed
             document.getElementById('water-level').value =  document.getElementById('water-level').value -20;
             document.querySelector('.water').innerHTML= document.getElementById('water-level').value
            await Process('.grinding',3000)
            document.getElementById('bean-level').value =  document.getElementById('bean-level').value -20;
            document.getElementById('milk-level').value =  document.getElementById('milk-level').value -20;
            document.querySelector('.bean').innerHTML= document.getElementById('bean-level').value
            document.querySelector('.milk').innerHTML= document.getElementById('milk-level').value
             await Process('.brewing',4000)
            await Process('.dispensing',5000)

          

        }


    
}

 

async function  Process(id, time)

{   clearInterval(intervalId)
    let timer= time/1000
    intervalId=setInterval(()=>{
        if (timer==0)
        {   document.querySelector('#elapsed-time-value').innerHTML=timer
            clearInterval(intervalId)
        }
    document.querySelector('#elapsed-time-value').innerHTML=timer
    timer=timer-1
     }, 1000)
     
    document.querySelector(id).style.backgroundColor='red'
    await sleep(time)
        document.querySelector(id).style.backgroundColor='grey'
    
}

