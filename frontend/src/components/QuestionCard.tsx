import React from 'react';
import type { QuestionaryItemDto } from '../services/types';

interface QuestionCardProps {
  item: QuestionaryItemDto;
  index: number;
  total: number;
  selectedAnswer: number | null;
  onSelect: (optionIndex: number) => void;
  isSubmitted: boolean;
}

const QuestionCard: React.FC<QuestionCardProps> = ({
  item,
  index,
  total,
  selectedAnswer,
  onSelect,
  isSubmitted,
}) => {
  const getLevelLabel = (level: number) => {
    const labels: Record<number, string> = {
      1: 'Beginner',
      2: 'Intermediate',
      3: 'Self-sufficient',
      4: 'Expert',
      5: 'Proficient',
    };
    return labels[level] ?? 'Unknown';
  };

  return (
    <div
      style={{
        border: '1px solid #dee2e6',
        borderRadius: '10px',
        padding: '20px',
        marginBottom: '16px',
        backgroundColor: isSubmitted
          ? item.isCorrect
            ? '#d4edda'
            : item.isCorrect === false
            ? '#f8d7da'
            : '#fff'
          : '#fff',
      }}
    >
      <div style={{ display: 'flex', justifyContent: 'space-between', marginBottom: '8px' }}>
        <span style={{ fontSize: '13px', color: '#666' }}>
          Question {index + 1} of {total}
        </span>
        <span
          style={{
            fontSize: '12px',
            padding: '2px 8px',
            borderRadius: '12px',
            backgroundColor: '#e9ecef',
            color: '#495057',
          }}
        >
          {item.tag} — Level {item.level} ({getLevelLabel(item.level)})
        </span>
      </div>

      <h3 style={{ margin: '8px 0 16px', fontSize: '16px' }}>{item.text}</h3>

      <div style={{ display: 'flex', flexDirection: 'column', gap: '8px' }}>
        {item.options.map((option, optIdx) => {
          const isSelected = selectedAnswer === optIdx;
          const isCorrectOption = isSubmitted && item.selectedOptionIndex === optIdx && item.isCorrect;
          const isWrongOption = isSubmitted && item.selectedOptionIndex === optIdx && item.isCorrect === false;

          let borderColor = '#dee2e6';
          let bgColor = '#fff';
          if (isSelected && !isSubmitted) {
            borderColor = '#007bff';
            bgColor = '#e7f1ff';
          }
          if (isCorrectOption) {
            borderColor = '#28a745';
            bgColor = '#d4edda';
          }
          if (isWrongOption) {
            borderColor = '#dc3545';
            bgColor = '#f8d7da';
          }

          return (
            <button
              key={optIdx}
              onClick={() => !isSubmitted && onSelect(optIdx)}
              disabled={isSubmitted}
              style={{
                padding: '10px 16px',
                textAlign: 'left',
                border: `2px solid ${borderColor}`,
                borderRadius: '6px',
                backgroundColor: bgColor,
                cursor: isSubmitted ? 'default' : 'pointer',
                fontSize: '14px',
                transition: 'all 0.15s',
              }}
            >
              <strong style={{ marginRight: '8px' }}>
                {String.fromCharCode(65 + optIdx)}.
              </strong>
              {option}
            </button>
          );
        })}
      </div>
    </div>
  );
};

export default QuestionCard;
