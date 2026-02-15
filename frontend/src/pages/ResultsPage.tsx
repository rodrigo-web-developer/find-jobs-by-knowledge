import React, { useState, useEffect } from 'react';
import { useRouter, useNavigation } from 'simple-react-routing';
import questionaryService from '../services/questionaryService';
import type { AssessmentResultDto, TagResultDto } from '../services/types';
import { getLevelColor } from '../utils/levelUtils';
import LoadingSpinner from '../components/LoadingSpinner';
import ErrorMessage from '../components/ErrorMessage';

const ResultsPage: React.FC = () => {
  const { pathParams } = useRouter();
  const { navigateTo } = useNavigation();
  const questionaryId = pathParams['id'];

  const [results, setResults] = useState<AssessmentResultDto | null>(null);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState<string | null>(null);

  useEffect(() => {
    if (!questionaryId) return;
    loadResults();
  }, [questionaryId]);

  const loadResults = async () => {
    setLoading(true);
    setError(null);
    const response = await questionaryService.getResults(questionaryId);
    setLoading(false);

    if (response.success) {
      setResults(response.data);
    } else {
      setError('Failed to load results.');
    }
  };

  if (loading) return <LoadingSpinner message="Loading results..." />;
  if (error) return <ErrorMessage message={error} onRetry={loadResults} />;
  if (!results) return <ErrorMessage message="Results not found." />;

  return (
    <div style={{ maxWidth: '800px', margin: '0 auto', padding: '20px' }}>
      <h1 style={{ marginBottom: '8px' }}>Assessment Results</h1>
      <p style={{ color: '#666', marginBottom: '24px' }}>
        Here's how you performed in each skill area.
      </p>

      <div style={{ display: 'flex', flexDirection: 'column', gap: '20px', marginBottom: '32px' }}>
        {results.results.map((result) => (
          <TagResultCard key={result.tag} result={result} />
        ))}
      </div>

      {results.recommendedSearchTags.length > 0 && (
        <div
          style={{
            padding: '20px',
            backgroundColor: '#e7f1ff',
            borderRadius: '10px',
            marginBottom: '24px',
          }}
        >
          <h3 style={{ margin: '0 0 12px' }}>Recommended Job Search Tags</h3>
          <div style={{ display: 'flex', gap: '8px', flexWrap: 'wrap' }}>
            {results.recommendedSearchTags.map((t) => (
              <span
                key={t.tag}
                style={{
                  padding: '6px 14px',
                  borderRadius: '20px',
                  backgroundColor: getLevelColor(t.level),
                  color: 'white',
                  fontSize: '14px',
                  fontWeight: '500',
                }}
              >
                {t.tag} — Level {t.level}
              </span>
            ))}
          </div>
        </div>
      )}

      <div style={{ display: 'flex', gap: '12px', justifyContent: 'center' }}>
        <button
          onClick={() => navigateTo(null, `/jobs/knowledge/${questionaryId}`)}
          style={{
            padding: '12px 28px',
            backgroundColor: '#007bff',
            color: 'white',
            border: 'none',
            borderRadius: '8px',
            cursor: 'pointer',
            fontSize: '16px',
            fontWeight: 'bold',
          }}
        >
          Find Jobs Based on Results
        </button>
        <button
          onClick={() => navigateTo(null, '/assessment')}
          style={{
            padding: '12px 28px',
            backgroundColor: '#6c757d',
            color: 'white',
            border: 'none',
            borderRadius: '8px',
            cursor: 'pointer',
            fontSize: '16px',
          }}
        >
          Take Another Assessment
        </button>
      </div>
    </div>
  );
};

const TagResultCard: React.FC<{ result: TagResultDto }> = ({ result }) => {
  const color = getLevelColor(result.determinedLevel);

  return (
    <div
      style={{
        border: '1px solid #dee2e6',
        borderRadius: '10px',
        padding: '20px',
        borderLeft: `5px solid ${color}`,
      }}
    >
      <div style={{ display: 'flex', justifyContent: 'space-between', alignItems: 'center', marginBottom: '12px' }}>
        <h2 style={{ margin: 0, fontSize: '20px' }}>{result.tag}</h2>
        <span
          style={{
            padding: '4px 14px',
            borderRadius: '20px',
            backgroundColor: color,
            color: 'white',
            fontWeight: 'bold',
            fontSize: '14px',
          }}
        >
          {result.determinedLevelName}
        </span>
      </div>

      <div style={{ marginBottom: '16px' }}>
        <div style={{ display: 'flex', justifyContent: 'space-between', marginBottom: '4px', fontSize: '14px' }}>
          <span>Overall Correct</span>
          <span style={{ fontWeight: 'bold' }}>{result.correctPercentage.toFixed(0)}%</span>
        </div>
        <div style={{ height: '10px', backgroundColor: '#e9ecef', borderRadius: '5px' }}>
          <div
            style={{
              height: '100%',
              width: `${result.correctPercentage}%`,
              backgroundColor: color,
              borderRadius: '5px',
              transition: 'width 0.5s',
            }}
          />
        </div>
      </div>

      <div>
        <p style={{ fontSize: '13px', color: '#666', marginBottom: '8px' }}>Performance by Level</p>
        <div style={{ display: 'flex', flexDirection: 'column', gap: '6px' }}>
          {Object.entries(result.percentagePerLevel)
            .sort(([a], [b]) => Number(a) - Number(b))
            .map(([level, pct]) => (
              <div key={level} style={{ display: 'flex', alignItems: 'center', gap: '8px' }}>
                <span style={{ width: '100px', fontSize: '13px', color: '#555' }}>
                  Level {level}
                </span>
                <div style={{ flex: 1, height: '6px', backgroundColor: '#e9ecef', borderRadius: '3px' }}>
                  <div
                    style={{
                      height: '100%',
                      width: `${pct}%`,
                      backgroundColor: getLevelColor(Number(level)),
                      borderRadius: '3px',
                    }}
                  />
                </div>
                <span style={{ width: '40px', fontSize: '13px', textAlign: 'right', fontWeight: '500' }}>
                  {pct.toFixed(0)}%
                </span>
              </div>
            ))}
        </div>
      </div>
    </div>
  );
};

export default ResultsPage;
