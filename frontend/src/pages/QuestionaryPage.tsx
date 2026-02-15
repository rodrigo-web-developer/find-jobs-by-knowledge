import React, { useState, useEffect, useMemo } from 'react';
import { useRouter, useNavigation } from 'simple-react-routing';
import questionaryService from '../services/questionaryService';
import type { QuestionaryDto, AnswerItem } from '../services/types';
import QuestionCard from '../components/QuestionCard';
import LoadingSpinner from '../components/LoadingSpinner';
import ErrorMessage from '../components/ErrorMessage';

const QuestionaryPage: React.FC = () => {
  const { pathParams } = useRouter();
  const { navigateTo } = useNavigation();
  const questionaryId = pathParams['id'];

  const [questionary, setQuestionary] = useState<QuestionaryDto | null>(null);
  const [answers, setAnswers] = useState<Record<string, number>>({});
  const [loading, setLoading] = useState(true);
  const [submitting, setSubmitting] = useState(false);
  const [error, setError] = useState<string | null>(null);
  const [currentTagIndex, setCurrentTagIndex] = useState(0);

  useEffect(() => {
    if (!questionaryId) return;
    loadQuestionary();
  }, [questionaryId]);

  const loadQuestionary = async () => {
    setLoading(true);
    setError(null);
    const response = await questionaryService.getById(questionaryId);
    setLoading(false);

    if (response.success) {
      if (response.data.isCompleted) {
        navigateTo(null, `/results/${questionaryId}`);
        return;
      }
      setQuestionary(response.data);
    } else {
      setError('Failed to load questionary.');
    }
  };

  const tags = useMemo(() => questionary?.tags ?? [], [questionary]);

  const currentTag = tags[currentTagIndex] ?? '';

  const currentItems = useMemo(
    () => questionary?.items.filter((i) => i.tag === currentTag) ?? [],
    [questionary, currentTag]
  );

  const answeredCount = useMemo(() => {
    if (!questionary) return 0;
    return questionary.items.filter((i) => answers[i.id] !== undefined).length;
  }, [questionary, answers]);

  const totalCount = questionary?.items.length ?? 0;

  const tagAnsweredCount = useMemo(
    () => currentItems.filter((i) => answers[i.id] !== undefined).length,
    [currentItems, answers]
  );

  const allAnswered = answeredCount === totalCount && totalCount > 0;

  const handleSelect = (itemId: string, optionIndex: number) => {
    setAnswers((prev) => ({ ...prev, [itemId]: optionIndex }));
  };

  const handleSubmit = async () => {
    if (!questionary || !allAnswered) return;

    setSubmitting(true);
    setError(null);

    const answerItems: AnswerItem[] = Object.entries(answers).map(([itemId, selectedOptionIndex]) => ({
      itemId,
      selectedOptionIndex,
    }));

    const response = await questionaryService.submitAnswers(questionary.id, { answers: answerItems });
    setSubmitting(false);

    if (response.success) {
      navigateTo(null, `/results/${questionary.id}`);
    } else {
      setError('Failed to submit answers.');
    }
  };

  if (loading) return <LoadingSpinner message="Loading questionary..." />;
  if (error) return <ErrorMessage message={error} onRetry={loadQuestionary} />;
  if (!questionary) return <ErrorMessage message="Questionary not found." />;

  return (
    <div style={{ maxWidth: '800px', margin: '0 auto', padding: '20px' }}>
      <div style={{ display: 'flex', justifyContent: 'space-between', alignItems: 'center', marginBottom: '16px' }}>
        <h1 style={{ margin: 0 }}>Assessment</h1>
        <span style={{ color: '#666', fontSize: '14px' }}>
          {answeredCount}/{totalCount} answered
        </span>
      </div>

      {/* Progress bar */}
      <div style={{ height: '8px', backgroundColor: '#e9ecef', borderRadius: '4px', marginBottom: '24px' }}>
        <div
          style={{
            height: '100%',
            width: `${(answeredCount / totalCount) * 100}%`,
            backgroundColor: '#007bff',
            borderRadius: '4px',
            transition: 'width 0.3s',
          }}
        />
      </div>

      {/* Tag tabs */}
      <div style={{ display: 'flex', gap: '4px', marginBottom: '20px', borderBottom: '2px solid #dee2e6' }}>
        {tags.map((tag, idx) => {
          const tagItems = questionary.items.filter((i) => i.tag === tag);
          const tagDone = tagItems.filter((i) => answers[i.id] !== undefined).length;
          const isActive = idx === currentTagIndex;

          return (
            <button
              key={tag}
              onClick={() => setCurrentTagIndex(idx)}
              style={{
                padding: '10px 20px',
                border: 'none',
                borderBottom: isActive ? '3px solid #007bff' : '3px solid transparent',
                backgroundColor: 'transparent',
                color: isActive ? '#007bff' : '#666',
                fontWeight: isActive ? 'bold' : 'normal',
                cursor: 'pointer',
                fontSize: '15px',
              }}
            >
              {tag} ({tagDone}/{tagItems.length})
            </button>
          );
        })}
      </div>

      {/* Questions for current tag */}
      <div style={{ marginBottom: '8px', color: '#666', fontSize: '14px' }}>
        {currentTag} — {tagAnsweredCount}/{currentItems.length} answered
      </div>

      {currentItems.map((item, idx) => (
        <QuestionCard
          key={item.id}
          item={item}
          index={idx}
          total={currentItems.length}
          selectedAnswer={answers[item.id] ?? null}
          onSelect={(optIdx) => handleSelect(item.id, optIdx)}
          isSubmitted={false}
        />
      ))}

      {/* Navigation & Submit */}
      <div style={{ display: 'flex', justifyContent: 'space-between', marginTop: '24px' }}>
        <button
          onClick={() => setCurrentTagIndex((prev) => Math.max(0, prev - 1))}
          disabled={currentTagIndex === 0}
          style={{
            padding: '10px 24px',
            backgroundColor: currentTagIndex === 0 ? '#e9ecef' : '#6c757d',
            color: currentTagIndex === 0 ? '#adb5bd' : 'white',
            border: 'none',
            borderRadius: '6px',
            cursor: currentTagIndex === 0 ? 'not-allowed' : 'pointer',
            fontSize: '15px',
          }}
        >
          ← Previous Tag
        </button>

        {currentTagIndex < tags.length - 1 ? (
          <button
            onClick={() => setCurrentTagIndex((prev) => Math.min(tags.length - 1, prev + 1))}
            style={{
              padding: '10px 24px',
              backgroundColor: '#007bff',
              color: 'white',
              border: 'none',
              borderRadius: '6px',
              cursor: 'pointer',
              fontSize: '15px',
            }}
          >
            Next Tag →
          </button>
        ) : (
          <button
            onClick={handleSubmit}
            disabled={!allAnswered || submitting}
            style={{
              padding: '10px 32px',
              backgroundColor: allAnswered ? '#28a745' : '#adb5bd',
              color: 'white',
              border: 'none',
              borderRadius: '6px',
              cursor: allAnswered && !submitting ? 'pointer' : 'not-allowed',
              fontSize: '15px',
              fontWeight: 'bold',
            }}
          >
            {submitting ? 'Submitting...' : allAnswered ? 'Submit Answers' : `Answer all questions (${answeredCount}/${totalCount})`}
          </button>
        )}
      </div>
    </div>
  );
};

export default QuestionaryPage;
