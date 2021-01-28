const Pool = require('pg').Pool
const pool = new Pool({
  user: 'postgres',
  host: 'localhost',
  database: 'CarDetail',
  password: '12345',
  port: 5432,
})

//get all the cars
const getCars = (request, response) => {
  pool.query('select car.id as "Car_ID", car."name" as Car_Name, make."name" as Make_Name , model."name"as Model_Name from car left join make on car.makeid=make.id 	left join model on car.modelid=model.id ;  ', (error, results) => {
    if (error) {
      throw error
    }
    response.status(200).json(results.rows)
  })
}

//get the specific car using id
const getCarsById = (request, response) => {
  const id = parseInt(request.params.id)

  pool.query('select car.id as "Car_ID", car."name" as Car_Name, make."name" as Make_Name , model."name"as Model_Name from car left join make on car.makeid=make.id 	left join model on car.modelid=model.id  WHERE car.id = $1', [id], (error, results) => {
    if (error) {
      throw error
    }
    response.status(200).json(results.rows)
  })
}


module.exports = {
  getCars,
  getCarsById,
  // createCar,
  // updateCar,
  // deleteCar,
}
