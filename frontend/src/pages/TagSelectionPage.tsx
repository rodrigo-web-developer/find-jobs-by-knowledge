import React, { useState } from 'react';
import { useNavigation } from 'simple-react-routing';
import questionaryService from '../services/questionaryService';
import TagBadge from '../components/TagBadge';
import LoadingSpinner from '../components/LoadingSpinner';
import ErrorMessage from '../components/ErrorMessage';

const AVAILABLE_TAGS = ['C#', 'React', 'Docker'];

const TagSelectionPage: React.FC = () => {
  const [selectedTags, setSelectedTags] = useState<string[]>([]);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);
  const { navigateTo } = useNavigation();

  const toggleTag = (tag: string) => {
    setSelectedTags((prev) =>
      prev.includes(tag) ? prev.filter((t) => t !== tag) : [...prev, tag]
    );
  };

  const handleGenerate = async () => {
    if (selectedTags.length === 0) return;

    try {
      setLoading(true);
      setError(null);
      const questionary = await questionaryService.generate({ tags: selectedTags });
      navigateTo(null, `/questionary/${questionary.id}`);
    } catch (err) {
      setError('Failed to generate questionary. Make sure the API is running.');
      console.error(err);
    } finally {
      setLoading(false);
    }
  };

  if (loading) return <LoadingSpinner message="Generating your assessment..." />;

  return (
    <div style={{ maxWidth: '700px', margin: '0 auto', padding: '20px' }}>
      <h1>Start Assessment</h1>
      <p style={{ color: '#666', marginBottom: '24px' }}>
        Select the technology tags you want to be assessed on. You'll answer questions across 5 difficulty levels
        for each selected tag.
      </p>

      {error && <ErrorMessage message={error} />}

      <h3 style={{ marginBottom: '12px' }}>Available Tags</h3>
      <div style={{ display: 'flex', gap: '12px', flexWrap: 'wrap', marginBottom: '24px' }}>
        {AVAILABLE_TAGS.map((tag) => {
          const isSelected = selectedTags.includes(tag);
          return (
            <button
              key={tag}
              onClick={() => toggleTag(tag)}
              style={{
                padding: '12px 24px',
                fontSize: '16px',
                borderRadius: '8px',
                border: `2px solid ${isSelected ? '#007bff' : '#dee2e6'}`,
                backgroundColor: isSelected ? '#007bff' : '#fff',
                color: isSelected ? '#fff' : '#333',
                cursor: 'pointer',
                fontWeight: isSelected ? 'bold' : 'normal',
                transition: 'all 0.2s',
              }}
            >
              {isSelected ? '✓ ' : ''}{tag}
            </button>
          );
        })}
      </div>

      {selectedTags.length > 0 && (
        <div style={{ marginBottom: '24px' }}>
          <h4 style={{ marginBottom: '8px' }}>Selected Tags:</h4>
          <div>
            {selectedTags.map((tag) => (
              <TagBadge key={tag} tag={tag} onRemove={() => toggleTag(tag)} />
            ))}
          </div>
        </div>
      )}

      <p style={{ color: '#666', fontSize: '14px', marginBottom: '16px' }}>
        {selectedTags.length === 0
          ? 'Select at least one tag to start the assessment.'
          : `You will answer up to ${selectedTags.length * 25} questions (5 per level × 5 levels × ${selectedTags.length} tag${selectedTags.length > 1 ? 's' : ''}).`}
      </p>

      <button
        onClick={handleGenerate}
        disabled={selectedTags.length === 0}
        style={{
          width: '100%',
          padding: '14px 32px',
          fontSize: '18px',
          backgroundColor: selectedTags.length > 0 ? '#007bff' : '#adb5bd',
          color: 'white',
          border: 'none',
          borderRadius: '8px',
          cursor: selectedTags.length > 0 ? 'pointer' : 'not-allowed',
          fontWeight: 'bold',
        }}
      >
        Generate Assessment
      </button>
    </div>
  );
};

export default TagSelectionPage;
