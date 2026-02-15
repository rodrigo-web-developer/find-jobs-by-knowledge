import React from 'react';

interface TagBadgeProps {
  tag: string;
  level?: number;
  levelName?: string;
  color?: string;
  onRemove?: () => void;
}

const TagBadge: React.FC<TagBadgeProps> = ({ tag, level, levelName, color = '#007bff', onRemove }) => (
  <span
    style={{
      display: 'inline-flex',
      alignItems: 'center',
      gap: '6px',
      backgroundColor: color,
      color: 'white',
      padding: '4px 10px',
      borderRadius: '16px',
      fontSize: '13px',
      fontWeight: 500,
      marginRight: '6px',
      marginBottom: '6px',
    }}
  >
    {tag}
    {level !== undefined && (
      <span style={{ opacity: 0.85, fontSize: '11px' }}>
        Lv.{level}{levelName ? ` (${levelName})` : ''}
      </span>
    )}
    {onRemove && (
      <button
        onClick={onRemove}
        style={{
          background: 'none',
          border: 'none',
          color: 'white',
          cursor: 'pointer',
          fontSize: '14px',
          padding: '0 2px',
          lineHeight: 1,
          opacity: 0.8,
        }}
        title="Remove"
      >
        ×
      </button>
    )}
  </span>
);

export default TagBadge;
