import axios from "axios";
import React, { useState } from "react";
import {Row, Form, Col, Button} from 'react-bootstrap';
const PatientRegistration = () => {

  const [patientData, setPatientData] = useState({
    tcNumber: "",
    firstName: "",
    lastName: "",
    address: "",
    phone: ""
  });
  const [error, setError] = useState('');
  const [success, setSuccess] = useState('');

  const fetchPatientRegistration = async () => {
    try {
      const response = await axios.post(`https://localhost:7228/api/Patients`,patientData);
      setSuccess('Kullanıcı Kaydı Başarıyla Yapıldı');
      setPatientData({
        tcNumber: "",
        firstName: "",
        lastName: "",
        address: "",
        phone: ""
      });
    }catch(err){
      setError('Kullanıcı Kaydı Yapılamadı');
      console.error(err)
    }
  }

  const handleInputChange = (e) => {
    const {name, value} = e.target;
    setPatientData({
      ...patientData,
      [name]: value
    });
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    fetchPatientRegistration();
  }

  return (
    <div>
    <h2>Hasta Kayıt İşlemi</h2>
    <Form onSubmit={handleSubmit}>
        <Row className="mb-3">
        <Form.Group as={Col} controlId="formGridKimlikNo">
          <Form.Label>TC Kimlik Numarası</Form.Label>
          <Form.Control
          name="tcNumber"
          type="text" 
          value={patientData.tcNumber}
          onChange={handleInputChange}
          required/>
        </Form.Group>
        </Row>

      <Row className="mb-3">
        <Form.Group as={Col} controlId="formGridFirstName">
          <Form.Label>Adı</Form.Label>
          <Form.Control 
          type="text" 
          name="firstName"
          value={patientData.firstName} 
          onChange={handleInputChange}
          required/>
        </Form.Group>

        <Form.Group as={Col} controlId="formGridLastName">
          <Form.Label>Soyadı</Form.Label>
          <Form.Control 
          type="text"
          name="lastName"
          value={patientData.lastName}
          onChange={handleInputChange}
          required />
        </Form.Group>
        <Form.Group as={Col} controlId="formGridPhone">
          <Form.Label>Telefon Numarası</Form.Label>
          <Form.Control
          type="text" 
          name="phone"
          value={patientData.phone}
          onChange={handleInputChange}
          required/>
        </Form.Group>
      </Row>

      <Form.Group className="mb-3" controlId="formGridAddress">
        <Form.Label>Adres</Form.Label>
        <Form.Control
        type="text"
        name="address"
        value={patientData.address}
        onChange={handleInputChange}
        required />
      </Form.Group>

      {error && <p style={{color: 'red'}}>{error}</p>}
      {success && <p style={{color: 'green'}}>{success}</p>}

      <Button variant="primary" type="submit">
        Kaydet
      </Button>
    </Form>
    </div>
  );
}


export default PatientRegistration;