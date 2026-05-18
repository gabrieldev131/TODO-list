import { useState, useEffect, useCallback } from 'react';
import { apiClient } from '../services/apiClient';

/**
 * useTasks Hook.
 * 
 * Study Material:
 * This custom hook encapsulates all state management and side effects related 
 * to tasks. 
 */
export const useTasks = () => {
    const [tasks, setTasks] = useState([]);
    const [loading, setLoading] = useState(false);
    const [error, setError] = useState(null);
    const [sortBy, setSortBy] = useState('');

    /**
     * Fetches the current list of tasks from the backend, with optional sorting.
     */
    const fetchTasks = useCallback(async () => {
        setLoading(true);
        try {
            const data = await apiClient.getTasks(sortBy);
            setTasks(data);
            setError(null);
        } catch (err) {
            setError('Failed to load tasks');
            console.error(err);
        } finally {
            setLoading(false);
        }
    }, [sortBy]);

    /**
     * Registers a new task with tags and optional reminder.
     */
    const addTask = async (title, description, priority, tags, reminderAt) => {
        try {
            await apiClient.createTask({ title, description, priority, tags, reminderAt });
            // Re-fetch or update local state (re-fetching ensures sorting is maintained)
            await fetchTasks();
        } catch (err) {
            setError('Failed to add task');
            throw err;
        }
    };

    /**
     * Removes a task by ID.
     */
    const removeTask = async (id) => {
        try {
            await apiClient.deleteTask(id);
            setTasks(prev => prev.filter(t => t.id !== id));
        } catch (err) {
            setError('Failed to remove task');
            throw err;
        }
    };

    // Load tasks whenever sorting changes or on initial mount
    useEffect(() => {
        const initialize = async () => {
            await fetchTasks();
        };
        initialize();
    }, [fetchTasks]);

    return {
        tasks,
        loading,
        error,
        addTask,
        removeTask,
        sortBy,
        setSortBy,
        refresh: fetchTasks
    };
};
