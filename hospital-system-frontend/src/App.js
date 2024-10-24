import { Link, Route, BrowserRouter as Router, Routes } from 'react-router-dom';
import './App.css';
import 'bootstrap/dist/css/bootstrap.min.css';
import { Container,Row } from 'react-bootstrap';
import AppNavbar from './components/AppNavbar';

import Sidebar from './components/Sidebar';
import AppMain from './components/AppMain';


function App() {  
  return(
    <Router>
     <AppNavbar />
      
      <Container fluid>
        <Row style={{height:'100vh'}}>
          <Sidebar />
          <AppMain />
        </Row>
      </Container>
    </Router>
  
  );
}

export default App;
