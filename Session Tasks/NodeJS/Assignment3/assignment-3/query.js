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

//insert the new car record
const addCar = async(request, response) => {
  let carname  = request.body.carname;
  let makename = request.body.makename;
  let modelname = request.body.modelname;
  let n_model_id;
  let n_make_id

  console.log("CarName = " + carname + "\n MakeName = " + makename + "\n ModelName = " + modelname);

  //query to check wether the car exist already or not
  const oldCarCheck = await pool.query('select car.name from car where car.name = $1',[carname]);

  if(oldCarCheck.rowCount >= 1)
  {
    //if exist it comes here
    response.send("Car already exist");
  }
  else
  {
    //query to fetch the id,name of the model if already exist
    const oldModelCheck = await pool.query('select id,name from model where name = $1',[modelname]);
    //query to fetch the id,name of the make if already exist
    const oldMakeCheck = await pool.query('select id,name from make where name = $1',[makename]);
    
    //to check wether model exist or to add new model
    if(oldModelCheck.rowCount >= 1)
    {
      //executes if model is already present
      n_model_id = oldModelCheck.rows[0].id;
      console.log(" exist model id = " + n_model_id);
    }
    else
    {
      const addModelQuery =  await pool.query ('Insert into model (name) values ($1) returning id', [modelname]);  
      n_model_id = addModelQuery.rows[0].id;
      console.log(" new model id = " + n_model_id);
    }

    //to check wether make exist or to add new make
    if(oldMakeCheck.rowCount >= 1)
    {
      //executes if make is already exist
      n_make_id = oldMakeCheck.rows[0].id;
      console.log(" exist make id = " + n_make_id);
    }
    else
    {
      const addMakeQuery = await pool.query ('Insert into make (name) values ($1) returning id', [makename]);  
      n_make_id = addMakeQuery.rows[0].id;
      console.log(" new make id = " + n_make_id);
    }

    //to insert new car
    pool.query('insert into car (name, makeid, modelid) values ($1, $2, $3)', [carname, n_make_id, n_model_id], (error, results) => {
        if (error) {
          throw error
        }
        response.status(201).send(`New Car Added Successfully`)

      })
    
  }

}

// to update a car value
const updateCar = async(request, response) => {
  const urlid = parseInt(request.params.id)
  let u_carname  = request.body.carname;
  let u_makename = request.body.makename;
  let u_modelname = request.body.modelname;
  let u_model_id;
  let u_make_id

  console.log("CarName = " + u_carname + "\n MakeName = " + u_makename + "\n ModelName = " + u_modelname);

  //query to check wether the car exist already or not
  const idCheck = await pool.query('select id from car where id = $1',[urlid]);

  if(idCheck.rowCount >= 1)
  {
    //if exist it comes here

    //query to fetch the id,name of the model if already exist
    const oldModelCheck = await pool.query('select id,name from model where name = $1',[u_modelname]);
    //query to fetch the id,name of the make if already exist
    const oldMakeCheck = await pool.query('select id,name from make where name = $1',[u_makename]);
    
    //to check wether model exist or to add new model
    if(oldModelCheck.rowCount >= 1)
    {
      //executes if model is already present
      u_model_id = oldModelCheck.rows[0].id;
      console.log(" exist model id = " + u_model_id);
    }
    else
    {
      const addModelQuery =  await pool.query ('Insert into model (name) values ($1) returning id', [u_modelname]);  
      u_model_id = addModelQuery.rows[0].id;
      console.log(" new model id = " + u_model_id);
    }

    //to check wether make exist or to add new make
    if(oldMakeCheck.rowCount >= 1)
    {
      //executes if make is already exist
      u_make_id = oldMakeCheck.rows[0].id;
      console.log(" exist make id = " + u_make_id);
    }
    else
    {
      const addMakeQuery = await pool.query ('Insert into make (name) values ($1) returning id', [u_makename]);  
      u_make_id = addMakeQuery.rows[0].id;
      console.log(" new make id = " + u_make_id);
    }

    //to insert new car
    pool.query('update car set name = $1, makeid = $2, modelid =$3 where id = $4', [u_carname, u_make_id, u_model_id, urlid], (error, results) => {
        if (error) {
          throw error
        }
        response.status(201).send(`Car is updated succesfully..`)

      })
    
    
  }
  else
  {
    response.send("Car id doesnot exist...");
  }
}

//to delete a car by id
const deleteCar = (request, response) => {
  const urlid = parseInt(request.params.id)

  pool.query('delete from car where id = $1;',[urlid], (error, results) => {
    if (error) {
      throw error
    }
    response.status(201).send('Car is deleted succesfully...')
  })
}

module.exports = {
  getCars,
  getCarsById,
  addCar,
  updateCar,
  deleteCar,
}
