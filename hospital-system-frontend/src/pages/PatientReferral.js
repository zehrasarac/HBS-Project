import axios from "axios";
import React, { useEffect, useState } from "react";
import {Row, Form, Col, Button,Table} from 'react-bootstrap';
import PatientDiagnoses from "./PatientDiagnoses";

const PatientReferral = () => {
    const [patients, setPatients] = useState([]);
    const [filteredDoctors, setFilteredDoctors] = useState([]);//filtrelenmiş doktorlar
    const [departments, setDepartments] = useState([]);
    const [selectedPatient, setSelectedPatient] = useState({
      id:"",
      tcNumber: "",
      firstName: "",
      lastName: "",
      address: "",
      phone: ""
    });
    const [referralData, setReferralData] = useState({
      patientId: "",
      departmentId: "",
      doctorId: "",
      referralDate: new Date().toISOString().slice(0,10),
    });

    const [error, setError] = useState('');
    const [success, setSuccess] = useState('');

    useEffect(() => {
      fetchPatientRegistred();
      fetcDepartments();
    },[]);

    //hasta verileri
    const fetchPatientRegistred = async () => {
      try {
        var response = await axios.get(`https://localhost:7228/api/Patients`);
        setPatients(response.data);
      }catch(error){
        setError('Bilgiler Yüklenirken Hata Oluştu');
      }
    }

    //bölüm verileri get
    const fetcDepartments = async () => {
      try {
        var response = await axios.get(`https://localhost:7228/api/Department`);
        setDepartments(response.data);
      }catch(error){
        setError('Bilgiler Yüklenirken Hata Oluştu');
      }
    }


    //filter bölüm => doktor verileri get
    const fetcDoctorsByDepartment = async (departmentId) => {
      try {
        const response = await axios.get(`https://localhost:7228/api/Doctors/departmentId/${departmentId}`,{
          params: {departmentId}
        });
        setFilteredDoctors(response.data);
      }catch(error){
        setError('Bilgiler Yüklenirken Hata Oluştu');
      }
    }

    const handleInputChange= (e) => {
      const { name, value } = e.target;

      if(name === "departmentId"){
        setReferralData({ ...referralData, departmentId: value,doctorId:""});
      fetcDoctorsByDepartment(value)
      }
      else{
        setReferralData({ ...referralData, [name]: value });
      }
    }

    const handleSelectPatient = (patient) => {
      setSelectedPatient({
        tcNumber: patient.tcNumber,
        firstName: patient.firstName,
        lastName: patient.lastName,
        address: patient.address,
        phone: patient.phone,
        id: patient.id
      });
      setReferralData((ptData) => ({
      ...ptData,
      patientId: patient.id
    }));

    };

    
    const fetchReferralRecord = async (referralData) => {
      try {
        const response = await axios.post(`https://localhost:7228/api/Referral`,referralData);
        setSuccess('Bilgiler Kaydedildi');
      }catch(err){
        setError('Bilgiler Kaydedilirken Hata Oluştu');
      }
    }

    const handleSubmit = async (e) => {
      e.preventDefault();
      await fetchReferralRecord(referralData);
    }
  
    return(
        <div>
        <h2>Hasta Sevk İşlemi</h2>
        <Form onSubmit={handleSubmit}>
        <Row className="mb-3">
            <Form.Group as={Col} controlId="formGridKimlikNo">
            <Form.Label>TC Kimlik Numarası</Form.Label>
            <Form.Control 
            type="text" 
            value={selectedPatient.tcNumber}
            readOnly/>
            </Form.Group>
        </Row>

        <Row className="mb-3">
            <Form.Group as={Col} controlId="formGridFirstName">
            <Form.Label>Adı</Form.Label>
            <Form.Control 
            type="text"
            value={selectedPatient.firstName}
            readOnly />
            </Form.Group>

            <Form.Group as={Col} controlId="formGridLastName">
            <Form.Label>Soyadı</Form.Label>
            <Form.Control 
            type="Text" 
            value={selectedPatient.lastName}
            readOnly/>
            </Form.Group>

            <Form.Group as={Col} controlId="formGridPhone">
            <Form.Label>Telefon Numarası</Form.Label>
            <Form.Control 
            type="text"
            value={selectedPatient.phone}
            readOnly />
            </Form.Group>
        </Row>

        <Row className="mb-3">
            <Form.Group as={Col}>
          <Form.Control
            as="select"
            name="departmentId"
            onChange={handleInputChange}
          >
          <option value="">Bölüm Seçin</option>
            {departments.map((department) => (
              <option key={department.id} value={department.id}>
                {department.name}
              </option>
            ))}
          </Form.Control>
        </Form.Group>

        <Form.Group as={Col}>
            <Form.Control 
            as="select"
            name="doctorId"
            onChange={handleInputChange}
            >
             <option value="">Doktor Seçin</option>
            {filteredDoctors.map((doctor) => (
              <option key={doctor.id} value={doctor.id}>
                {doctor.firstName} {doctor.lastName}
              </option>
            ))}
            </Form.Control>
            </Form.Group>
        </Row>

            {error && (<p style={{color:'red'}}>{error}</p>)}
            {success && (<p style={{color:'green'}}>{success}</p>)}

        <Button type="submit" variant="danger" onClick={handleSubmit}>Kaydet</Button>
        </Form>
        <Row className="mt-5">
        {patients.length > 0 && (
          <Table striped bordered hover size="sm">
            <thead>
              <tr>
                <th>Adı</th>
                <th>Soyadı</th>
                <th>TC Kimlik Numarası</th>
                <th>Telefon Numarası</th>
                <th>İşlem</th>
              </tr>
            </thead>
            <tbody>
              {patients.map((patient) => (
                <tr key={patient.id}>
                  <td>{patient.firstName}</td>
                  <td>{patient.lastName}</td>
                  <td>{patient.tcNumber}</td>
                  <td>{patient.phone}</td>
                  <td>
                    <Button
                      variant="primary"
                      onClick={() => handleSelectPatient(patient)}
                    >
                      İşleme Al
                    </Button>
                  </td>
                </tr>
              ))}
            </tbody>
          </Table>
        )}
      </Row>
    
      </div>
    );
}

export default PatientReferral;