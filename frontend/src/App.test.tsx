import React from 'react';
import { render, screen } from '@testing-library/react';
import App from './App';

test('renders find jobs by knowledge header', () => {
  render(<App />);
  const headerElement = screen.getByText(/Find Jobs by Knowledge/i);
  expect(headerElement).toBeInTheDocument();
});
