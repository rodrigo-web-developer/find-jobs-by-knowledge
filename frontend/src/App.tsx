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
      setError('Failed to load jobs. Please make sure the API is running.');
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
      const data = await jobService.searchJobsByKnowledge(searchTerm);
      setJobs(data);
    } catch (err) {
      setError('Failed to search jobs');
      console.error(err);
    } finally {
      setLoading(false);
    }
  };

  const handleDelete = async (id: string) => {
    try {
      await jobService.deleteJob(id);
      setJobs(jobs.filter(job => job.id !== id));
    } catch (err) {
      setError('Failed to delete job');
      console.error(err);
    }
  };

  return (
    <div className="App" style={{ padding: '20px', maxWidth: '1200px', margin: '0 auto' }}>
      <header style={{ marginBottom: '20px' }}>
        <h1>Find Jobs by Knowledge</h1>
        <div style={{ display: 'flex', gap: '8px', marginTop: '16px' }}>
          <input
            type="text"
            placeholder="Search by required knowledge (e.g., React, Python)"
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
            Clear
          </button>
        </div>
      </header>

      {loading && <p>Loading jobs...</p>}
      {error && <div style={{ color: 'red', padding: '16px', backgroundColor: '#fee', borderRadius: '4px' }}>{error}</div>}

      <div>
        {jobs.length === 0 && !loading && (
          <p style={{ textAlign: 'center', color: '#666' }}>No jobs found. The database might be empty.</p>
        )}
        {jobs.map(job => (
          <JobCard key={job.id} job={job} onDelete={handleDelete} />
        ))}
      </div>
    </div>
  );
}

export default App;
