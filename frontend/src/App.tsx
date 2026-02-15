import React from 'react';
import { BrowserRouter, RenderComponent } from 'simple-react-routing';
import { routes } from './routes';
import Navbar from './components/Navbar';
import './App.css';

function App() {
  return (
    <BrowserRouter routes={routes}>
      <Navbar />
      <main style={{ minHeight: 'calc(100vh - 60px)' }}>
        <RenderComponent />
      </main>
    </BrowserRouter>
  );
}

export default App;
