const express = require('express')
const path = require('path')
const fs = require('fs')
const bodyParser = require('body-parser')

const app = express()
const port = 3030

// To serve the static files
app.use(express.static(path.join(__dirname, '../')))

// app.use(bodyParser.urlencoded({ extended: false }))
app.use(bodyParser.json())

// API EndPoints

app.get('/api/v1/', (req, res) => {
  res.setHeader("Access-Control-Allow-Origin", "*");
  res.setHeader("Access-Control-Allow-Methods", "POST, GET, PUT");
  res.setHeader("Access-Control-Allow-Headers", "Content-Type");

  fs.readFile('coffee.json', (err, output) => {
    if (err) throw err;
    else {
      res.status(200).send(output.toString())  
    }
  })
})

app.post('/api/v1/', (req, res) => {
  res.setHeader("Access-Control-Allow-Origin", "*");
  res.setHeader("Access-Control-Allow-Methods", "POST, GET, PUT");
  res.setHeader("Access-Control-Allow-Headers", "Content-Type");
  console.log(req.body)
  fs.writeFile('coffee.json', JSON.stringify(req.body), (err) => {
    if (err) throw err;
    else res.end("Data Updated successfully")
  })
})

// Handle invalid requests
app.get('/*', (req, res) => {
  res.setHeader("Access-Control-Allow-Origin", "*");
  res.setHeader("Access-Control-Allow-Methods", "POST, GET, PUT");
  res.setHeader("Access-Control-Allow-Headers", "Content-Type");
  res.status(400)
    .json({ Error: 'Invalid request, kindly check the API doc' })
})

app.listen(port, () => console.log(`App is listening on ${port}`))
