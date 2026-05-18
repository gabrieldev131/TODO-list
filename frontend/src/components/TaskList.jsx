
import { TaskItem } from './TaskItem';

/**
 * TaskList Component.
 * 
 * Study Material:
 * Orchestrates the display of multiple TaskItem components. 
 * SOLID: Separation of Concerns. 
 * This component focuses on layout and mapping the list of tasks.
 */
export const TaskList = ({ tasks, onRemove, loading }) => {
    // Single level of indentation logic (simulated in JSX)
    if (loading) return <p>Loading tasks...</p>;
    
    // Check if list is empty to provide clear feedback
    if (tasks.length === 0) return <p style={{ textAlign: 'center', color: '#999' }}>No tasks found. Add one above!</p>;

    return (
        <div style={{ marginTop: '20px' }}>
            {tasks.map(task => (
                <TaskItem key={task.id} task={task} onRemove={onRemove} />
            ))}
        </div>
    );
};
