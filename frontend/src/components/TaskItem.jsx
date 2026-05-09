import React from 'react';
import { TagBadge } from './TagBadge';

/**
 * TaskItem Component.
 * 
 * Study Material:
 * Represents a single task in the list. 
 * SOLID: Single Responsibility Principle. 
 * This component's only job is to display a task and emit actions like 'remove'.
 */
export const TaskItem = ({ task, onRemove }) => {
    return (
        <div style={{
            display: 'flex',
            justifyContent: 'space-between',
            alignItems: 'center',
            padding: '15px',
            borderBottom: '1px solid #eee',
            backgroundColor: task.isCompleted ? '#f9f9f9' : '#fff'
        }}>
            <div style={{ flex: 1 }}>
                <h4 style={{ margin: '0 0 5px 0' }}>{task.title}</h4>
                <p style={{ margin: '0 0 8px 0', fontSize: '0.9em', color: '#666' }}>{task.description}</p>
                
                <div style={{ marginBottom: '8px' }}>
                    {task.tags && task.tags.map((tag, index) => (
                        <TagBadge key={index} tag={tag} />
                    ))}
                </div>

                <span style={{ 
                    fontSize: '0.8em', 
                    fontWeight: 'bold',
                    color: task.priority === 'High' ? 'red' : task.priority === 'Medium' ? 'orange' : 'blue'
                }}>
                    Priority: {task.priority}
                </span>
            </div>
            
            <button 
                onClick={() => onRemove(task.id)}
                style={{
                    backgroundColor: '#ff4d4d',
                    color: 'white',
                    border: 'none',
                    padding: '8px 12px',
                    borderRadius: '4px',
                    cursor: 'pointer',
                    marginLeft: '15px'
                }}
            >
                Remove
            </button>
        </div>
    );
};
