import React from 'react';
import { useTasks } from './hooks/useTasks';
import { useReminders } from './hooks/useReminders';
import { TaskRegistrationForm } from './components/TaskRegistrationForm';
import { TaskList } from './components/TaskList';
import { SortingControl } from './components/SortingControl';

/**
 * App Component.
 * 
 * Study Material:
 * The entry point of the Single-Page Application (SPA). 
 * Mandate: "Front end deve ser claro e simples".
 */
function App() {
  const { tasks, addTask, removeTask, loading, error, sortBy, setSortBy } = useTasks();
  
  // Activate reminders system
  useReminders(tasks);

  return (
    <div style={{ maxWidth: '600px', margin: '40px auto', padding: '0 20px', fontFamily: 'Arial, sans-serif' }}>
      <h1 style={{ textAlign: 'center', color: '#333' }}>TODO List</h1>
      
      {error && <p style={{ color: 'red', textAlign: 'center' }}>{error}</p>}
      
      <TaskRegistrationForm onAdd={addTask} />
      
      <hr style={{ border: '0', borderTop: '1px solid #ddd', margin: '20px 0' }} />
      
      <SortingControl value={sortBy} onChange={setSortBy} />
      
      <TaskList tasks={tasks} onRemove={removeTask} loading={loading} />
      
      <footer style={{ marginTop: '40px', fontSize: '0.8em', color: '#999', textAlign: 'center' }}>
        <p>Built with SOLID & Object Calisthenics Principles</p>
      </footer>
    </div>
  );
}

export default App;
