import React from 'react';
import { Link } from 'simple-react-routing';

const HomePage: React.FC = () => (
  <div style={{ maxWidth: '800px', margin: '0 auto', textAlign: 'center', padding: '40px 20px' }}>
    <h1 style={{ fontSize: '2.5rem', marginBottom: '16px' }}>Find Jobs by Knowledge</h1>
    <p style={{ fontSize: '1.2rem', color: '#666', marginBottom: '40px' }}>
      Assess your skills, discover your proficiency levels, and find jobs that match your knowledge.
    </p>

    <div style={{ display: 'flex', gap: '24px', justifyContent: 'center', flexWrap: 'wrap' }}>
      <div
        style={{
          flex: '1 1 300px',
          maxWidth: '360px',
          padding: '32px',
          borderRadius: '12px',
          border: '2px solid #007bff',
          backgroundColor: '#f8f9ff',
        }}
      >
        <h2 style={{ color: '#007bff', marginBottom: '12px' }}>Take Assessment</h2>
        <p style={{ color: '#666', marginBottom: '24px' }}>
          Select your technology tags, answer questions for each skill level, and get a detailed proficiency report.
        </p>
        <Link
          to="/assessment"
          style={{
            display: 'inline-block',
            padding: '12px 32px',
            backgroundColor: '#007bff',
            color: 'white',
            textDecoration: 'none',
            borderRadius: '6px',
            fontWeight: 'bold',
            fontSize: '16px',
          }}
        >
          Start Assessment
        </Link>
      </div>

      <div
        style={{
          flex: '1 1 300px',
          maxWidth: '360px',
          padding: '32px',
          borderRadius: '12px',
          border: '2px solid #28a745',
          backgroundColor: '#f8fff9',
        }}
      >
        <h2 style={{ color: '#28a745', marginBottom: '12px' }}>Browse Jobs</h2>
        <p style={{ color: '#666', marginBottom: '24px' }}>
          Search for jobs from external APIs by technology tags. Filter and explore opportunities.
        </p>
        <Link
          to="/jobs"
          style={{
            display: 'inline-block',
            padding: '12px 32px',
            backgroundColor: '#28a745',
            color: 'white',
            textDecoration: 'none',
            borderRadius: '6px',
            fontWeight: 'bold',
            fontSize: '16px',
          }}
        >
          Browse Jobs
        </Link>
      </div>
    </div>
  </div>
);

export default HomePage;
