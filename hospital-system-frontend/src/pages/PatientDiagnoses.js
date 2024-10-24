import React, { useState, useEffect } from "react";
import { Row, Form, Col, Button, Alert } from "react-bootstrap";
import axios from "axios";

const PatientDiagnosis = () => {
  const [patientDetails, setPatientDetails] = useState({
    tcNumber: "",
    firstName: "",
    lastName: "",
    diagnosis: "",
    doctorId: "",
    diagnosisDate: new Date().toISOString().slice(0, 10),
  });

  const [doctors, setDoctors] = useState([]);
  const [diagnoses, setDiagnoses] = useState([]);
  const [departmentId, setDepartmentId] = useState("");
  const [referralId, setRefferalId] = useState("");
  const [departments, setDepartments] = useState([]);
  const [message, setMessage] = useState("");
  const [patientId, setPatientId] = useState(null);

  const fetchDepartments = async () => {
    try {
      const response = await axios.get("https://localhost:7228/api/Department");
      setDepartments(response.data);
    } catch (error) {
      console.error("Departman verilerini alırken hata oluştu:", error);
    }
  };

  const fetchPatientDetails = async (tcNumber) => {
    try {
      const response = await axios.get(`https://localhost:7228/api/Patients/tc/${tcNumber}`);
      const patientData = response.data;

      setPatientDetails((prevDetails) => ({
        ...prevDetails,
        firstName: patientData.firstName,
        lastName: patientData.lastName,
      }));

      setPatientId(patientData.id); 

      const referralResponse = await axios.get(`https://localhost:7228/api/Referral/tc/${tcNumber}`);
      setDepartmentId(referralResponse.data.departmentId);

      const referralId = referralResponse.data.id;
      setRefferalId(referralId);
    } catch (error) {
      console.error("Hasta bilgilerini alırken hata oluştu:", error);
    }
  };

  useEffect(() => {
    if (departmentId) {
      axios.get(`https://localhost:7228/api/Diagnosis/departmentId/${departmentId}`)
        .then((response) => {
          setDiagnoses(response.data);
        })
        .catch((error) => {
          console.error("Teşhis verilerini alırken hata oluştu:", error);
        });
    }
  }, [departmentId]);

  useEffect(() => {
    const fetchDoctors = async () => {
      try {
        const response = await axios.get(`https://localhost:7228/api/Doctors`);
        setDoctors(response.data);
      } catch (error) {
        console.error("Doktor verilerini alırken hata oluştu:", error);
      }
    };

    fetchDoctors();
    fetchDepartments();
  }, []);

  const handleInputChange = (e) => {
    const { name, value } = e.target;
    setPatientDetails((prevDetails) => ({
      ...prevDetails,
      [name]: value,
    }));
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    console.log("Muayene bilgileri gönderildi:", patientDetails);

    const postData = {
      patientId: patientId, 
      referralId: referralId, 
      diagnosisId: patientDetails.diagnosis, 
      date: patientDetails.diagnosisDate,
    };

    axios.post("https://localhost:7228/api/PatientDiagnosis", postData)
      .then((response) => {
        console.log("Muayene kaydedildi:", response.data);
        setMessage("Muayene bilgileri başarıyla kaydedildi!");
      })
      .catch((error) => {
        console.error("Muayene kaydedilirken hata oluştu:", error);
        setMessage("Muayene bilgileri kaydedilirken bir hata oluştu: " + error.response.data);
      });
  };

  return (
    <div>
      <h2>Hasta Muayene İşlemi</h2>
      {message && <Alert variant={message.includes("hata") ? "danger" : "success"}>{message}</Alert>}
      <Form onSubmit={handleSubmit}>
        <Row className="mb-3">
          <Form.Group as={Col} controlId="formTcNumber">
            <Form.Label>TC Kimlik Numarası</Form.Label>
            <Form.Control
              type="text"
              name="tcNumber"
              value={patientDetails.tcNumber}
              onChange={handleInputChange}
              required
            />
          </Form.Group>
          <Button onClick={() => fetchPatientDetails(patientDetails.tcNumber)}>
            Hasta Bilgilerini Getir
          </Button>
        </Row>

        <Row className="mb-3">
          <Form.Group as={Col} controlId="formFirstName">
            <Form.Label>Adı</Form.Label>
            <Form.Control
              type="text"
              name="firstName"
              value={patientDetails.firstName}
              onChange={handleInputChange}
              disabled
            />
          </Form.Group>

          <Form.Group as={Col} controlId="formLastName">
            <Form.Label>Soyadı</Form.Label>
            <Form.Control
              type="text"
              name="lastName"
              value={patientDetails.lastName}
              onChange={handleInputChange}
              disabled
            />
          </Form.Group>
        </Row>

        <Row className="mb-3">
          <Form.Group as={Col} controlId="formDepartment">
            <Form.Label>Departman</Form.Label>
            <Form.Control
              as="select"
              name="departmentId"
              value={departmentId}
              onChange={(e) => setDepartmentId(e.target.value)}
              required
            >
              <option value="">Departman Seçiniz</option>
              {departments.map((dept) => (
                <option key={dept.id} value={dept.id}>
                  {dept.name}
                </option>
              ))}
            </Form.Control>
          </Form.Group>

          <Form.Group as={Col} controlId="formDiagnosis">
            <Form.Label>Teşhis</Form.Label>
            <Form.Control
              as="select"
              name="diagnosis"
              value={patientDetails.diagnosis}
              onChange={handleInputChange}
              required
            >
              <option value="">Teşhis Seçiniz</option>
              {diagnoses.map((diag) => (
                <option key={diag.id} value={diag.id}>
                  {diag.name}
                </option>
              ))}
            </Form.Control>
          </Form.Group>
        </Row>

        <Button variant="primary" type="submit">
          Muayene Bilgilerini Kaydet
        </Button>
      </Form>
    </div>
  );
};

export default PatientDiagnosis;
