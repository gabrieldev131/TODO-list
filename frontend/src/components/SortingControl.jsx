import React from 'react';

/**
 * SortingControl Component.
 * 
 * Study Material:
 * Allows the user to select the sorting criteria. 
 * This follows the "Simple & Clear" mandate by providing a single, 
 * easy-to-use dropdown.
 */
export const SortingControl = ({ value, onChange }) => {
    return (
        <div style={{ display: 'flex', alignItems: 'center', gap: '10px', justifyContent: 'flex-end', marginBottom: '10px' }}>
            <label style={{ fontSize: '0.9em', color: '#666' }}>Sort by:</label>
            <select 
                value={value} 
                onChange={(e) => onChange(e.target.value)}
                style={{ padding: '5px', borderRadius: '4px', border: '1px solid #ccc' }}
            >
                <option value="">Default</option>
                <option value="priority">Priority</option>
                <option value="title">Title</option>
            </select>
        </div>
    );
};
