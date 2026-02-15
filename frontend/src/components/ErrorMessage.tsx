import React from 'react';

interface ErrorMessageProps {
  message: string;
  onRetry?: () => void;
}

const ErrorMessage: React.FC<ErrorMessageProps> = ({ message, onRetry }) => (
  <div
    style={{
      padding: '16px',
      backgroundColor: '#f8d7da',
      color: '#721c24',
      borderRadius: '8px',
      border: '1px solid #f5c6cb',
      marginBottom: '16px',
      display: 'flex',
      alignItems: 'center',
      justifyContent: 'space-between',
    }}
  >
    <span>{message}</span>
    {onRetry && (
      <button
        onClick={onRetry}
        style={{
          padding: '6px 16px',
          backgroundColor: '#721c24',
          color: 'white',
          border: 'none',
          borderRadius: '4px',
          cursor: 'pointer',
          fontSize: '14px',
        }}
      >
        Retry
      </button>
    )}
  </div>
);

export default ErrorMessage;
