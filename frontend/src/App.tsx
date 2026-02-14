import React, { useState, useEffect } from 'react';
import './App.css';
import { jobService, Job } from './services/jobService';
import JobCard from './components/JobCard';

function App() {
  const [jobs, setJobs] = useState<Job[]>([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState<string | null>(null);
  const [searchTerm, setSearchTerm] = useState('');

  useEffect(() => {
    loadJobs();
  }, []);

  const loadJobs = async () => {
    try {
      setLoading(true);
      setError(null);
      const data = await jobService.getAllJobs();
      setJobs(data);
    } catch (err) {
      setError('Failed to load jobs from external APIs. Please make sure the API is running.');
      console.error(err);
    } finally {
      setLoading(false);
    }
  };

  const handleSearch = async () => {
    if (!searchTerm.trim()) {
      loadJobs();
      return;
    }

    try {
      setLoading(true);
      setError(null);
      const data = await jobService.searchJobsByTag(searchTerm);
      setJobs(data);
    } catch (err) {
      setError('Failed to search jobs');
      console.error(err);
    } finally {
      setLoading(false);
    }
  };

  return (
    <div className="App" style={{ padding: '20px', maxWidth: '1200px', margin: '0 auto' }}>
      <header style={{ marginBottom: '20px' }}>
        <h1>Find Jobs by Tags</h1>
        <p style={{ color: '#666', marginBottom: '16px' }}>
          Search for jobs from external APIs by technology tags
        </p>
        <div style={{ display: 'flex', gap: '8px', marginTop: '16px' }}>
          <input
            type="text"
            placeholder="Search by tag (e.g., React, C#, Docker)"
            value={searchTerm}
            onChange={(e) => setSearchTerm(e.target.value)}
            onKeyPress={(e) => e.key === 'Enter' && handleSearch()}
            style={{
              flex: 1,
              padding: '8px 12px',
              fontSize: '16px',
              borderRadius: '4px',
              border: '1px solid #ddd'
            }}
          />
          <button 
            onClick={handleSearch}
            style={{
              padding: '8px 24px',
              backgroundColor: '#007bff',
              color: 'white',
              border: 'none',
              borderRadius: '4px',
              cursor: 'pointer',
              fontSize: '16px'
            }}
          >
            Search
          </button>
          <button 
            onClick={loadJobs}
            style={{
              padding: '8px 24px',
              backgroundColor: '#6c757d',
              color: 'white',
              border: 'none',
              borderRadius: '4px',
              cursor: 'pointer',
              fontSize: '16px'
            }}
          >
            Show All
          </button>
        </div>
      </header>

      {loading && <p>Loading jobs from external APIs...</p>}
      {error && <div style={{ color: 'red', padding: '16px', backgroundColor: '#fee', borderRadius: '4px' }}>{error}</div>}

      <div>
        {jobs.length === 0 && !loading && (
          <p style={{ textAlign: 'center', color: '#666' }}>
            No jobs found. Try searching with different tags or check that external APIs are accessible.
          </p>
        )}
        {jobs.map(job => (
          <JobCard key={job.id} job={job} />
        ))}
      </div>
    </div>
  );
}

export default App;
