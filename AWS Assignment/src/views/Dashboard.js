/*!

=========================================================
* Black Dashboard React v1.2.0
=========================================================

* Product Page: https://www.creative-tim.com/product/black-dashboard-react
* Copyright 2020 Creative Tim (https://www.creative-tim.com)
* Licensed under MIT (https://github.com/creativetimofficial/black-dashboard-react/blob/master/LICENSE.md)

* Coded by Creative Tim

=========================================================

* The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

*/
import React, { useEffect, useState } from "react";
// nodejs library that concatenates classes
import classNames from "classnames";
// react plugin used to create charts
import { Line, Bar } from "react-chartjs-2";

// reactstrap components
import {
  Button,
  ButtonGroup,
  Card,
  CardHeader,
  CardBody,
  CardTitle,
  DropdownToggle,
  DropdownMenu,
  DropdownItem,
  UncontrolledDropdown,
  Label,
  FormGroup,
  Input,
  Table,
  Row,
  Col,
  UncontrolledTooltip,
  Modal, ModalHeader, ModalBody, ModalFooter, CardFooter, Form, CardText
} from "reactstrap";
import axios from "axios";
import Icons from "./Icons";

// core components

const useSignUpForm = (callback) => {
  
  const [inputs, setInputs] = useState({});
  
  const handleSubmit = async(event) => {
    if (event) {
      event.preventDefault();
      const fd = new FormData();
      fd.append("cust_name", inputs.name);
      fd.append("cust_email", inputs.email);
      fd.append("cust_password", inputs.password);
      fd.append("cust_mno", inputs.mobile);
      fd.append("cust_image", inputs.image);

      try {
      await axios.post(
      "https://zkdaqjzwxh.execute-api.us-east-1.amazonaws.com/default/addcustomer",
      fd
      );
      callback();
      } catch (error) {
      console.log(error);
}
      }
  }

  const handleInputChange = (event) => {
    event.persist();
    if(event.target.name === "image")
      setInputs(inputs => ({...inputs, [event.target.name] : event.target.files[0]}))
    else
    setInputs(inputs => ({...inputs, [event.target.name]: event.target.value}));
  }
  return {
    handleSubmit,
    handleInputChange,
    inputs
  };
}

function Dashboard(props) {
  const toggle = () => setModal(!modal);
  const toggle1 = () => setModal1(!modal1);
  const {inputs, handleInputChange, handleSubmit} = useSignUpForm(() => props.history.push("/admin"));
  const [bigChartData, setbigChartData] = React.useState("data1");
  const [customer, setcustomer] = useState([])
  const [modal, setModal] = useState(false);
  const [modal1, setModal1] = useState(false);
  const [customerById, setcustomerById] = useState({})
  
  const getCustomer  = (callback,id) => {
    var requestOptions = {
      method: 'GET',
      redirect: 'follow'
    };
    
    fetch("https://infnenzluj.execute-api.us-east-1.amazonaws.com/default/getcustomerbyid?id="+id, requestOptions)
      .then(response => response.json())
      .then(result => {setcustomerById(result[0]);callback()})
      .catch(error => console.log('error', error));
  }


  useEffect(() => {
    var requestOptions = {
      method: 'GET',
      redirect: 'follow'
    };
    
    fetch("https://lncw7qo4c7.execute-api.us-east-1.amazonaws.com/default/getcustomer", requestOptions)
      .then(response => response.json())
      .then(result => setcustomer(result))
      .catch(error => console.log('error', error));
  }, [])
  
  return (
    
    <>
      <div className="content">
        <Row>
          
          <Col lg="12" md="12">
            <Card>
              <CardHeader>
                <CardTitle tag="h4"><button onClick={toggle} className="btn btn-primary">Add User</button></CardTitle>
              </CardHeader>
              <Modal  isOpen={modal} toggle={toggle}>
              
              <div className="content">
        <Row>
          <Col md="12">
            <Card style={{marginBottom:"0px"}}>
              <CardHeader>
                <ModalHeader toggle={toggle}><h3 className="text-primary title">Add User</h3></ModalHeader>
              </CardHeader>
              <Form onSubmit={handleSubmit}>
              <CardBody>
                
                <Row>
                    <Col className="pr-md-1" md="6">
                      <FormGroup>
                        <label>Name</label>
                        <Input
                        onChange={handleInputChange}  name="name" value={inputs.name} required
                          placeholder="Name"
                          type="text"
                        />
                      </FormGroup>
                    </Col>
                    <Col className="pl-md-1" md="6">
                      <FormGroup>
                        <label>Mobile Number</label>
                        <Input
                          onChange={handleInputChange} name="mobile"  value={inputs.mobile} required
                          placeholder="Number"
                          type="Number"
                        />
                      </FormGroup>
                    </Col>
                  </Row>
                  <Row>
                    <Col className="pl-md-4" md="12">
                      <FormGroup>
                        <label htmlFor="exampleInputEmail1">
                          Email address
                        </label>
                        <Input onChange={handleInputChange} name="email"  value={inputs.email} required placeholder="mike@email.com" type="email" />
                      </FormGroup>
                    </Col>
                  </Row>
                  
                  <Row>
                    <Col md="12">
                      <FormGroup>
                        <label>Password</label>
                        <Input
                        onChange={handleInputChange} name="password"  value={inputs.password} required
                          placeholder="Password"
                          type="password"
                        />
                      </FormGroup>
                    </Col>
                  </Row>
                  <Row>
                    <Col md="5">
                        <label>Profile Picture</label>
                        </Col>
                        <Col md="7">   <Input type="file" onChange={handleInputChange} name="image" class="form-control-file"/>
                        </Col>
                    
                   
                  </Row>
                
              </CardBody>
              <CardFooter>
              
                <Button className="btn-fill" color="primary" type="submit">
                  Save
                </Button>
              </CardFooter>
              </Form>
            </Card>
          </Col>
        </Row>
      </div>
            </Modal>





            {/* card */}



            <Modal  isOpen={modal1} toggle={toggle1}>
              {customerById !== {} ?
              <div className="content">
        <Row>
          <Col md="12">
          <Card style={{marginBottom:"0px"}} className="card-user">
          <CardHeader>
          <ModalHeader style={{position:"relative",zIndex:99}} toggle={toggle1}></ModalHeader>
              </CardHeader>
              <CardBody>
                <CardText />
                <div className="author">
                  <div className="block block-one" />
                  <div className="block block-two" />
                  <div className="block block-three" />
                  <div className="block block-four" />
                  <a href="#pablo" onClick={(e) => e.preventDefault()}>
                    <img
                      alt="..."
                      className="avatar"
                      src={customerById.cust_image}
                    />
                    <h3 className="title">{customerById.cust_name}
                    { customerById.status === 0 ? <Button className="ml-3 btn-icon btn-round" color="twitter">
                    <i className=" tim-icons icon-check-2" />
                  </Button> : <></> }</h3>
                  </a>
                  <p className="description">(+91) {customerById.cust_mno}</p>
                  <div className="card-description">
                  {customerById.cust_email}
                </div>
                </div>
                
              </CardBody>
            </Card>
          </Col>
        </Row>
      </div> : <></>}
            </Modal>

              <CardBody>
                <Table className="tablesorter" responsive>
                  <thead className="text-primary">
                    <tr>
                    <th className="text-center">Image</th>
                      <th>Name</th>
                      <th>Status</th>
                      <th>Email</th>
                      <th>Contact Number</th>                      
                    </tr>
                  </thead>
                  <tbody>
                    {customer.map(item => {
                    return(
                    <tr key={item.cust_id}>
                      <td><img width="100px" class="rounded mx-auto d-block" src={item.cust_image}/></td>
                      <td>{item.cust_name}</td>
                      <td>{item.status === 0 ? <i className="tim-icons icon-check-2"/>:<></>}</td>
                      <td>{item.cust_email}</td>
                      <td>{item.cust_mno}</td>
                      <td><button onClick={() => getCustomer(toggle1,item.cust_id)} className="btn btn-secondary">View</button></td>
                    </tr>
                    );})}
                  </tbody>
                </Table>
              </CardBody>
            </Card>
          </Col>
        </Row>
      </div>
    </>
  );
}

export default Dashboard;
