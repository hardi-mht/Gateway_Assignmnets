const express = require('express')
const bodyParser = require('body-parser')
const db = require('./query')

const app = express()
const port = 4000

app.use(bodyParser.json())
app.use(
  bodyParser.urlencoded({
    extended: true,
  })
)

app.get('/', (request, response) => {
  response.json({ info: 'Node.js, Express, and Postgres API' })
})
app.get('/cars', db.getCars)
app.get('/cars/:id', db.getCarsById)
app.post('/cars', db.addCar)
app.put('/cars/:id', db.updateCar)
app.delete('/cars/:id', db.deleteCar)



app.listen(port, () => {
  console.log(`App running on port ${port}.`)
})
