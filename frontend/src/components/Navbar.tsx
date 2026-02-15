import React from 'react';
import { Link } from 'simple-react-routing';

const Navbar: React.FC = () => (
  <nav
    style={{
      display: 'flex',
      alignItems: 'center',
      gap: '24px',
      padding: '12px 24px',
      backgroundColor: '#343a40',
      color: 'white',
      marginBottom: '24px',
    }}
  >
    <Link to="/" style={{ color: 'white', textDecoration: 'none', fontWeight: 'bold', fontSize: '18px' }}>
      Find Jobs by Knowledge
    </Link>
    <div style={{ display: 'flex', gap: '16px', marginLeft: 'auto' }}>
      <Link to="/" style={{ color: '#adb5bd', textDecoration: 'none' }}>
        Home
      </Link>
      <Link to="/assessment" style={{ color: '#adb5bd', textDecoration: 'none' }}>
        Start Assessment
      </Link>
      <Link to="/jobs" style={{ color: '#adb5bd', textDecoration: 'none' }}>
        Browse Jobs
      </Link>
    </div>
  </nav>
);

export default Navbar;
