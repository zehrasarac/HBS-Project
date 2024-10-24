import React from "react";
import 'bootstrap/dist/css/bootstrap.min.css';
import { Nav,Navbar,NavDropdown,Form,Button,Container,Row,Col } from 'react-bootstrap';
import { Link, Route, BrowserRouter as Router, Routes } from 'react-router-dom';

const Sidebar = () => {
    return(
        <Col xs={3} className='sidebar'>
            <Navbar bg='dark' variant='dark' expand="lg" className='flex-column'>
              <Nav className='flex-column'>
                <Nav.Link as={Link} to="/hastakayit">Hasta Kabul</Nav.Link>
                <Nav.Link as={Link} to="/poliklinikayit">Poliklinik Kayıt</Nav.Link>
                <Nav.Link as={Link} to="/muayene">Muayene</Nav.Link>
                <Nav.Link as={Link} to="/hastagecmisi">Hasta Geçmişi</Nav.Link>
              </Nav>
            </Navbar>
        </Col>
    );
}

export default Sidebar;