import { describe, it, expect } from 'vitest';
import { render, screen } from '@testing-library/react';
import App from './App';

describe('App', () => {
  it('renders find jobs by tags header', () => {
    render(<App />);
    const headerElement = screen.getByText(/Find Jobs by Tags/i);
    expect(headerElement).toBeInTheDocument();
  });
});
