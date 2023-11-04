const express = require('express')
const fs = require('fs')
const app = express()

const filename = './coffee.json'

app.use(express.static(__dirname))
app.use(express.json())

app.post('/coffeejson', (req,res) => {
    const postdata = req.body
    fs.writeFileSync(filename,JSON.stringify(postdata))
    return
})

const port = process.env.PORT || 3000
app.listen(port)