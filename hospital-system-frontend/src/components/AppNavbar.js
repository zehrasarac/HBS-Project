import React, { useEffect, useState } from "react";
import { Nav,Navbar,NavDropdown,Form,Button,Container } from 'react-bootstrap';

const AppNavbar = () => {
  const [currentTime,setCurrentTime] = useState(new Date());

  useEffect(()=>{
    const timer= setInterval(()=>{
      setCurrentTime(new Date());
    },1000);
    return ()=> clearInterval(timer);
  },[]);

  const formDate = (date) =>{
    return `${date.toLocaleDateString()} ${date.toLocaleTimeString()}`
  }


  return(
    <Navbar expand="lg" className="bg-body-tertiary">
      <Container fluid>
        <Navbar.Brand href="/">HBS</Navbar.Brand>
      </Container>
    </Navbar>
  );
}

export default AppNavbar;