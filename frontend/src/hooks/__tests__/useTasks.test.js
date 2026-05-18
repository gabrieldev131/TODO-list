import { renderHook, waitFor, act } from '@testing-library/react';
import { describe, it, expect, vi, beforeEach } from 'vitest';
import { useTasks } from '../useTasks';
import { apiClient } from '../../services/apiClient';

// Mock the apiClient to prevent actual network requests during unit tests.
vi.mock('../../services/apiClient', () => ({
    apiClient: {
        getTasks: vi.fn(),
        createTask: vi.fn(),
        deleteTask: vi.fn(),
    }
}));

/**
 * useTasks.test.js
 * 
 * Study Material:
 * 1. Testing Hooks: Custom hooks are tested using 'renderHook' from @testing-library/react.
 * 2. Async Waiting: We use 'waitFor' to handle state updates that happen after 
 *    asynchronous API calls.
 * 3. Side Effects: We verify that 'useEffect' correctly triggers 'fetchTasks' 
 *    on initial mount.
 */
describe('useTasks Hook', () => {
    beforeEach(() => {
        vi.clearAllMocks();
    });

    it('should fetch tasks on mount', async () => {
        // Arrange
        const mockTasks = [{ id: '1', title: 'Task 1' }];
        apiClient.getTasks.mockResolvedValue(mockTasks);

        // Act
        const { result } = renderHook(() => useTasks());

        // Assert
        // Rationale: Verify the initial loading state and the eventual data population.
        expect(result.current.loading).toBe(true);
        
        await waitFor(() => {
            expect(result.current.tasks).toEqual(mockTasks);
            expect(result.current.loading).toBe(false);
        });

        expect(apiClient.getTasks).toHaveBeenCalled();
    });

    it('should handle errors during fetch', async () => {
        // Arrange
        apiClient.getTasks.mockRejectedValue(new Error('Network Error'));

        // Act
        const { result } = renderHook(() => useTasks());

        // Assert
        await waitFor(() => {
            expect(result.current.error).toBe('Failed to load tasks');
            expect(result.current.loading).toBe(false);
        });
    });

    it('should remove a task and update local state', async () => {
        // Arrange
        const initialTasks = [{ id: '1', title: 'Task 1' }];
        apiClient.getTasks.mockResolvedValue(initialTasks);
        apiClient.deleteTask.mockResolvedValue();

        const { result } = renderHook(() => useTasks());
        await waitFor(() => expect(result.current.tasks).toHaveLength(1));

        // Act
        // Decision: Wrap state-changing async actions in 'act' to ensure stability.
        await act(async () => {
            await result.current.removeTask('1');
        });

        // Assert
        expect(result.current.tasks).toHaveLength(0);
        expect(apiClient.deleteTask).toHaveBeenCalledWith('1');
    });
});
