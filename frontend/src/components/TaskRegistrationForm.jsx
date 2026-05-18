import { useState } from 'react';

/**
 * TaskRegistrationForm Component.
 * 
 * Study Material:
 * Handles user input to register new tasks. 
 * Zero Friction: All fields are grouped logically and the 'Add' action is immediate.
 */
export const TaskRegistrationForm = ({ onAdd }) => {
    const [title, setTitle] = useState('');
    const [description, setDescription] = useState('');
    const [priority, setPriority] = useState('Medium');
    const [tagsInput, setTagsInput] = useState('');
    const [reminderAt, setReminderAt] = useState('');

    const handleSubmit = async (e) => {
        e.preventDefault();
        if (!title.trim()) return;

        // Process tags: comma-separated string to array
        const tags = tagsInput.split(',')
                             .map(t => t.trim())
                             .filter(t => t.length > 0);

        try {
            await onAdd(title, description, priority, tags, reminderAt || null);
            setTitle('');
            setDescription('');
            setTagsInput('');
            setReminderAt('');
        } catch {
            alert('Error adding task');
        }
    };

    return (
        <form onSubmit={handleSubmit} style={{ 
            padding: '20px', 
            backgroundColor: '#f4f4f4', 
            borderRadius: '8px',
            marginBottom: '20px'
        }}>
            <div style={{ marginBottom: '10px' }}>
                <input 
                    type="text" 
                    placeholder="Task Title (Required)" 
                    value={title}
                    onChange={(e) => setTitle(e.target.value)}
                    style={{ width: '100%', padding: '10px', borderRadius: '4px', border: '1px solid #ccc', boxSizing: 'border-box' }}
                />
            </div>
            <div style={{ marginBottom: '10px' }}>
                <textarea 
                    placeholder="Description (Optional)" 
                    value={description}
                    onChange={(e) => setDescription(e.target.value)}
                    style={{ width: '100%', padding: '10px', borderRadius: '4px', border: '1px solid #ccc', boxSizing: 'border-box' }}
                />
            </div>
            <div style={{ marginBottom: '10px' }}>
                <input 
                    type="text" 
                    placeholder="Tags (comma-separated, e.g., Work, Home)" 
                    value={tagsInput}
                    onChange={(e) => setTagsInput(e.target.value)}
                    style={{ width: '100%', padding: '10px', borderRadius: '4px', border: '1px solid #ccc', boxSizing: 'border-box' }}
                />
            </div>
            <div style={{ marginBottom: '10px' }}>
                <label style={{ display: 'block', marginBottom: '5px', fontSize: '14px', color: '#666' }}>Set Reminder (Optional):</label>
                <input 
                    type="datetime-local" 
                    value={reminderAt}
                    onChange={(e) => setReminderAt(e.target.value)}
                    style={{ width: '100%', padding: '10px', borderRadius: '4px', border: '1px solid #ccc', boxSizing: 'border-box' }}
                />
            </div>
            <div style={{ display: 'flex', gap: '10px', alignItems: 'center' }}>
                <select 
                    value={priority}
                    onChange={(e) => setPriority(e.target.value)}
                    style={{ padding: '10px', borderRadius: '4px' }}
                >
                    <option value="High">High</option>
                    <option value="Medium">Medium</option>
                    <option value="Low">Low</option>
                </select>
                
                <button type="submit" style={{ 
                    flex: 1, 
                    padding: '10px', 
                    backgroundColor: '#4CAF50', 
                    color: 'white', 
                    border: 'none', 
                    borderRadius: '4px',
                    cursor: 'pointer'
                }}>
                    Add Task
                </button>
            </div>
        </form>
    );
};
