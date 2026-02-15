import React, { useState, useEffect } from 'react';
import { useRouter, useNavigation } from 'simple-react-routing';
import questionaryService from '../services/questionaryService';
import jobService from '../services/jobsService';
import type { AssessmentResultDto, Job } from '../services/types';
import { getLevelColor } from '../utils/levelUtils';
import LoadingSpinner from '../components/LoadingSpinner';
import ErrorMessage from '../components/ErrorMessage';

const JobsByKnowledgePage: React.FC = () => {
  const { pathParams } = useRouter();
  const { navigateTo } = useNavigation();
  const questionaryId = pathParams['id'];

  const [results, setResults] = useState<AssessmentResultDto | null>(null);
  const [jobs, setJobs] = useState<Job[]>([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState<string | null>(null);

  useEffect(() => {
    if (!questionaryId) return;
    loadJobsByKnowledge();
  }, [questionaryId]);

  const loadJobsByKnowledge = async () => {
    try {
      setLoading(true);
      setError(null);

      const assessmentResults = await questionaryService.getResults(questionaryId);
      setResults(assessmentResults);

      if (assessmentResults.recommendedSearchTags.length > 0) {
        const foundJobs = await jobService.searchByTags(assessmentResults.recommendedSearchTags);
        setJobs(foundJobs);
      }
    } catch (err) {
      setError('Failed to load jobs.');
      console.error(err);
    } finally {
      setLoading(false);
    }
  };

  if (loading) return <LoadingSpinner message="Finding jobs matching your skills..." />;
  if (error) return <ErrorMessage message={error} onRetry={loadJobsByKnowledge} />;
  if (!results) return <ErrorMessage message="Results not found." />;

  return (
    <div style={{ maxWidth: '900px', margin: '0 auto', padding: '20px' }}>
      <h1 style={{ marginBottom: '8px' }}>Jobs Matching Your Skills</h1>
      <p style={{ color: '#666', marginBottom: '16px' }}>
        Based on your assessment results, we found jobs matching your skill levels.
      </p>

      {/* Search tags used */}
      <div style={{ marginBottom: '24px' }}>
        <span style={{ fontSize: '14px', color: '#666', marginRight: '8px' }}>Search tags:</span>
        {results.recommendedSearchTags.map((t) => (
          <span
            key={t.tag}
            style={{
              display: 'inline-block',
              padding: '4px 12px',
              margin: '0 4px 4px 0',
              borderRadius: '16px',
              backgroundColor: getLevelColor(t.level),
              color: 'white',
              fontSize: '13px',
            }}
          >
            {t.tag} (Lvl {t.level})
          </span>
        ))}
      </div>

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
          <p style={{ color: '#888' }}>No positions match your current skill profile at this time.</p>
          <button
            onClick={() => navigateTo(null, '/jobs')}
            style={{
              padding: '10px 24px',
              backgroundColor: '#007bff',
              color: 'white',
              border: 'none',
              borderRadius: '6px',
              cursor: 'pointer',
              fontSize: '14px',
              marginTop: '12px',
            }}
          >
            Browse All Jobs
          </button>
        </div>
      ) : (
        <>
          <p style={{ color: '#666', marginBottom: '16px', fontSize: '14px' }}>
            Found {jobs.length} job{jobs.length !== 1 && 's'}
          </p>
          <div style={{ display: 'flex', flexDirection: 'column', gap: '16px' }}>
            {jobs.map((job) => (
              <JobResultCard key={job.id} job={job} />
            ))}
          </div>
        </>
      )}

      <div style={{ display: 'flex', gap: '12px', justifyContent: 'center', marginTop: '32px' }}>
        <button
          onClick={() => navigateTo(null, `/results/${questionaryId}`)}
          style={{
            padding: '10px 24px',
            backgroundColor: '#6c757d',
            color: 'white',
            border: 'none',
            borderRadius: '6px',
            cursor: 'pointer',
            fontSize: '14px',
          }}
        >
          ← Back to Results
        </button>
        <button
          onClick={() => navigateTo(null, '/jobs')}
          style={{
            padding: '10px 24px',
            backgroundColor: '#007bff',
            color: 'white',
            border: 'none',
            borderRadius: '6px',
            cursor: 'pointer',
            fontSize: '14px',
          }}
        >
          Browse All Jobs
        </button>
      </div>
    </div>
  );
};

const JobResultCard: React.FC<{ job: Job }> = ({ job }) => (
  <div
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
        {job.tags.map((tag) => (
          <span
            key={tag}
            style={{
              padding: '3px 10px',
              borderRadius: '12px',
              backgroundColor: '#f0f0f0',
              fontSize: '12px',
              color: '#555',
            }}
          >
            {tag}
          </span>
        ))}
      </div>
    )}
  </div>
);

export default JobsByKnowledgePage;
