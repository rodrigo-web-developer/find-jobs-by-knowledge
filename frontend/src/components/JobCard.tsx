import React, { useState } from 'react';
import { Job } from '../services/jobService';

interface JobCardProps {
  job: Job;
}

const JobCard: React.FC<JobCardProps> = ({ job }) => {
  const [expanded, setExpanded] = useState(false);

  return (
    <div style={{ 
      border: '1px solid #ddd', 
      borderRadius: '8px', 
      padding: '16px', 
      marginBottom: '16px',
      backgroundColor: '#fff'
    }}>
      <h3 style={{ margin: '0 0 8px 0' }}>{job.title}</h3>
      <p style={{ margin: '4px 0', color: '#666' }}>
        <strong>{job.company}</strong> - {job.location}
      </p>
      {job.salary && (
        <p style={{ margin: '4px 0', color: '#28a745' }}>
          ${job.salary.toLocaleString()}
        </p>
      )}
      <p style={{ margin: '8px 0', fontSize: '14px', color: '#888' }}>
        Posted: {new Date(job.postedDate).toLocaleDateString()} • Source: {job.source}
      </p>
      
      {expanded && (
        <div style={{ marginTop: '12px' }}>
          <p style={{ margin: '8px 0' }}>{job.description}</p>
          <div style={{ marginTop: '12px' }}>
            <strong>Tags:</strong>
            <div style={{ marginTop: '4px' }}>
              {job.tags.map((tag, index) => (
                <span 
                  key={index} 
                  style={{ 
                    display: 'inline-block', 
                    backgroundColor: '#007bff', 
                    color: 'white', 
                    padding: '4px 8px', 
                    borderRadius: '4px', 
                    marginRight: '4px',
                    marginBottom: '4px',
                    fontSize: '12px'
                  }}
                >
                  {tag}
                </span>
              ))}
            </div>
          </div>
        </div>
      )}
      
      <div style={{ marginTop: '12px', display: 'flex', gap: '8px' }}>
        <button 
          onClick={() => setExpanded(!expanded)}
          style={{
            padding: '8px 16px',
            backgroundColor: '#007bff',
            color: 'white',
            border: 'none',
            borderRadius: '4px',
            cursor: 'pointer'
          }}
        >
          {expanded ? 'Show Less' : 'Show More'}
        </button>
      </div>
    </div>
  );
};

export default JobCard;
