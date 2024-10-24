import React, { useState, useEffect } from "react";
import {Row, Form, Col, Button,Table} from 'react-bootstrap';
import axios from "axios";

const PatientHistory = () => {
    const [tcNumber, setTcNumber] = useState('');
    const [patientHistory, setPatientHistory] = useState([]);
    const [error,setError] = useState('');

    const fetchPatientHistory = async () => {
        try{
            setError('');
            const response = await axios.get(`https://localhost:7228/api/PatientHistory/${tcNumber}`);
            setPatientHistory(response.data);
        }catch(err){
            setError('Hasta bilgileri alınırken bir hata oluştu. Lütfen TC kimlik numarasını kontrol edin.');
            console.error(err);
        }
    }

    const handleInputChange = (e) => {
        setTcNumber(e.target.value);
    }

    const handleSubmit = (e) => {
        e.preventDefault();
        fetchPatientHistory();
    }

return(
    <div>
        <h2>Hasta Geçmişi</h2>
        <Row className="mb-3">
            <Form.Group as={Col}>
                <Form.Label>TC Kimlik Numarası</Form.Label>
                <Form.Control
                type="text"
                value={tcNumber}
                onChange={handleInputChange}
                required
                />
                <Button type="submit" variant="danger" onClick={handleSubmit}>Sorgula</Button>
            </Form.Group>
        </Row>

        {error && <p style={{color: 'red'}}>{error}</p>}

        {patientHistory.length > 0 && (
            <Row className="mt-5">
                <Table striped bordered hover size="sm">
              <thead>
                <tr>
                  <th>Adı</th>
                  <th>Soyadı</th>
                  <th>Bölüm</th>
                  <th>Doktor</th>
                  <th>Teşhis</th>
                  <th>Sevk Tarihi</th>
                  <th>Muayene Tarihi</th>
                </tr>
              </thead>
              <tbody>
                {patientHistory.map((history,index) => (
                    <tr key={index}>
                        <td>{history.patientName}</td>
                        <td>{history.patientLastName}</td>
                        <td>{history.department}</td>
                        <td>{history.doctor}</td>
                        <td>{history.diagnosis}</td>
                        <td>{history.referralDate}</td>
                        <td>{history.patientDiagnosisDate}</td>
                    </tr>
                ))}
               
              </tbody>
            </Table>
            </Row>
        )}
        
    </div>
);

}

export default PatientHistory;