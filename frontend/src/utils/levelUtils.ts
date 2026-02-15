const levelNames: Record<number, string> = {
  1: 'Beginner',
  2: 'Intermediate',
  3: 'Self-sufficient',
  4: 'Expert',
  5: 'Proficient',
};

export function getLevelName(level: number): string {
  return levelNames[level] ?? 'Unknown';
}

export function getLevelColor(level: number): string {
  switch (level) {
    case 1: return '#6c757d';
    case 2: return '#17a2b8';
    case 3: return '#28a745';
    case 4: return '#fd7e14';
    case 5: return '#dc3545';
    default: return '#6c757d';
  }
}
