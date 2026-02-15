import { describe, it, expect } from 'vitest';
import { render, screen } from '@testing-library/react';
import App from './App';

describe('App', () => {
  it('renders the application with navbar', () => {
    render(<App />);
    const navElement = screen.getByText(/Find Jobs by Knowledge/i);
    expect(navElement).toBeInTheDocument();
  });
});
