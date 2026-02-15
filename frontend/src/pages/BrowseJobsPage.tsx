import React, { useState } from 'react';
import jobService from '../services/jobsService';
import type { Job } from '../services/types';
import LoadingSpinner from '../components/LoadingSpinner';
import ErrorMessage from '../components/ErrorMessage';

const BrowseJobsPage: React.FC = () => {
  const [tag, setTag] = useState('');
  const [jobs, setJobs] = useState<Job[]>([]);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);
  const [searched, setSearched] = useState(false);

  const handleSearch = async () => {
    const trimmed = tag.trim();
    if (!trimmed) return;

    try {
      setLoading(true);
      setError(null);
      const results = await jobService.searchByTag(trimmed);
      setJobs(results);
      setSearched(true);
    } catch (err) {
      setError('Failed to search jobs.');
      console.error(err);
    } finally {
      setLoading(false);
    }
  };

  const handleKeyDown = (e: React.KeyboardEvent) => {
    if (e.key === 'Enter') handleSearch();
  };

  return (
    <div style={{ maxWidth: '900px', margin: '0 auto', padding: '20px' }}>
      <h1 style={{ marginBottom: '8px' }}>Browse Jobs</h1>
      <p style={{ color: '#666', marginBottom: '24px' }}>
        Search for jobs by technology or skill tag.
      </p>

      <div style={{ display: 'flex', gap: '8px', marginBottom: '24px' }}>
        <input
          type="text"
          value={tag}
          onChange={(e) => setTag(e.target.value)}
          onKeyDown={handleKeyDown}
          placeholder="e.g. React, C#, Docker..."
          style={{
            flex: 1,
            padding: '10px 16px',
            border: '2px solid #dee2e6',
            borderRadius: '8px',
            fontSize: '15px',
            outline: 'none',
          }}
        />
        <button
          onClick={handleSearch}
          disabled={loading || !tag.trim()}
          style={{
            padding: '10px 28px',
            backgroundColor: tag.trim() ? '#007bff' : '#adb5bd',
            color: 'white',
            border: 'none',
            borderRadius: '8px',
            cursor: tag.trim() ? 'pointer' : 'not-allowed',
            fontSize: '15px',
            fontWeight: 'bold',
          }}
        >
          {loading ? 'Searching...' : 'Search'}
        </button>
      </div>

      {loading && <LoadingSpinner message="Searching for jobs..." />}
      {error && <ErrorMessage message={error} onRetry={handleSearch} />}

      {!loading && !error && searched && (
        <>
          {jobs.length === 0 ? (
            <div
              style={{
                textAlign: 'center',
                padding: '48px 20px',
                backgroundColor: '#f8f9fa',
                borderRadius: '10px',
              }}
            >
              <h3 style={{ color: '#666' }}>No jobs found</h3>
              <p style={{ color: '#888' }}>Try searching for a different tag.</p>
            </div>
          ) : (
            <>
              <p style={{ color: '#666', marginBottom: '16px', fontSize: '14px' }}>
                Found {jobs.length} job{jobs.length !== 1 && 's'} for "{tag.trim()}"
              </p>
              <div style={{ display: 'flex', flexDirection: 'column', gap: '16px' }}>
                {jobs.map((job) => (
                  <div
                    key={job.id}
                    style={{
                      border: '1px solid #dee2e6',
                      borderRadius: '10px',
                      padding: '20px',
                      backgroundColor: '#fff',
                    }}
                  >
                    <div style={{ display: 'flex', justifyContent: 'space-between', alignItems: 'flex-start' }}>
                      <div>
                        <h3 style={{ margin: '0 0 4px', fontSize: '18px' }}>{job.title}</h3>
                        <p style={{ margin: '0 0 8px', color: '#007bff', fontWeight: '500' }}>{job.company}</p>
                      </div>
                      {job.source && (
                        <span
                          style={{
                            fontSize: '11px',
                            padding: '2px 8px',
                            borderRadius: '4px',
                            backgroundColor: '#e9ecef',
                            color: '#666',
                          }}
                        >
                          {job.source}
                        </span>
                      )}
                    </div>
                    {job.location && (
                      <p style={{ margin: '0 0 8px', fontSize: '14px', color: '#666' }}>📍 {job.location}</p>
                    )}
                    {job.description && (
                      <p style={{ margin: '0 0 12px', fontSize: '14px', color: '#555', lineHeight: '1.5' }}>
                        {job.description.length > 200 ? `${job.description.slice(0, 200)}...` : job.description}
                      </p>
                    )}
                    {job.tags && job.tags.length > 0 && (
                      <div style={{ display: 'flex', gap: '6px', flexWrap: 'wrap' }}>
                        {job.tags.map((t) => (
                          <span
                            key={t}
                            style={{
                              padding: '3px 10px',
                              borderRadius: '12px',
                              backgroundColor: '#f0f0f0',
                              fontSize: '12px',
                              color: '#555',
                            }}
                          >
                            {t}
                          </span>
                        ))}
                      </div>
                    )}
                  </div>
                ))}
              </div>
            </>
          )}
        </>
      )}
    </div>
  );
};

export default BrowseJobsPage;
