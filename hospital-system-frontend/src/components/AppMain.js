import React from "react";
import 'bootstrap/dist/css/bootstrap.min.css';
import { Nav,Navbar,NavDropdown,Form,Button,Container,Row,Col } from 'react-bootstrap';
import { Link, Route, BrowserRouter as Router, Routes } from 'react-router-dom';
import PatientRegistration from "../pages/PatientRegistration";
import PatientReferral from "../pages/PatientReferral";
import PatientDiagnoses from "../pages/PatientDiagnoses";
import PatientHistory from "../pages/PatientHistory";

const AppMain = () => {
    return(
        <Col xs={9} md={8}>
            <Routes>
              <Route path="/hastakayit" element={<PatientRegistration />} />
              <Route path="/" element={<PatientRegistration />} />
              <Route path="/poliklinikayit" element={<PatientReferral />} />
              <Route path="/muayene" element={<PatientDiagnoses />} />
              <Route path="/hastagecmisi" element={<PatientHistory />} />
            </Routes>
          </Col>
    );
}

export default AppMain;