import { render, screen, fireEvent } from '@testing-library/react';
import { describe, it, expect, vi } from 'vitest';
import { TaskItem } from '../TaskItem';

/**
 * TaskItem.test.jsx
 * 
 * Study Material:
 * 1. React Testing Library (RTL): We test how the user interacts with the component,
 *    not the internal state or implementation details.
 * 2. Accessibility-first: We use 'screen.getByText' which mimics how a screen reader 
 *    or a user would find content.
 * 3. Mocking callbacks: We use 'vi.fn()' to verify that the component correctly 
 *    triggers external actions.
 */
describe('TaskItem Component', () => {
    const mockTask = {
        id: '1',
        title: 'Test Task',
        description: 'Test Description',
        priority: 'High',
        tags: ['tag1', 'tag2'],
        isCompleted: false
    };

    it('renders task details correctly', () => {
        // Arrange & Act
        render(<TaskItem task={mockTask} onRemove={() => {}} />);

        // Assert
        // Rationale: We verify that the user can see the title, description, and priority.
        expect(screen.getByText('Test Task')).toBeDefined();
        expect(screen.getByText('Test Description')).toBeDefined();
        expect(screen.getByText(/Priority: High/i)).toBeDefined();
    });

    it('calls onRemove when the remove button is clicked', () => {
        // Arrange
        const onRemoveMock = vi.fn();
        render(<TaskItem task={mockTask} onRemove={onRemoveMock} />);

        // Act
        const removeButton = screen.getByText('Remove');
        fireEvent.click(removeButton);

        // Assert
        // Rationale: Interaction testing ensures the "Controller" part of the View logic works.
        expect(onRemoveMock).toHaveBeenCalledWith('1');
    });

    it('displays tag badges if tags are present', () => {
        // Arrange & Act
        render(<TaskItem task={mockTask} onRemove={() => {}} />);

        // Assert
        // Rationale: We use regex matching because the component prepends '#' to the tag name.
        expect(screen.getByText(/tag1/i)).toBeDefined();
        expect(screen.getByText(/tag2/i)).toBeDefined();
    });
});
