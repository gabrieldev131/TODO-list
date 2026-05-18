/**
 * apiClient.js
 * 
 * Study Material: 
 * This service centralizes all API communication. 
 * SOLID: Single Responsibility Principle. 
 * By encapsulating the fetch logic here, we make it easier to add global 
 * configurations like base URLs, headers, or error handling in one place.
 * 
 * Environment Configuration:
 * We use Vite's 'import.meta.env' to decouple the API address from the source code.
 * This allows us to point to different backends (staging, production) without changes.
 */

const BASE_URL = import.meta.env.VITE_API_URL || 'http://localhost:5115/api';

export const apiClient = {
    /**
     * Sends a GET request to retrieve all tasks.
     */
    async getTasks(sortBy = '') {
        const url = `${BASE_URL}/tasks${sortBy ? `?sortBy=${sortBy}` : ''}`;
        const response = await fetch(url);
        return this.handleResponse(response);
    },

    /**
     * Sends a POST request to register a new task.
     */
    async createTask(taskData) {
        const response = await fetch(`${BASE_URL}/tasks`, {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(taskData)
        });
        return this.handleResponse(response);
    },

    /**
     * Sends a DELETE request to remove a task.
     */
    async deleteTask(id) {
        const response = await fetch(`${BASE_URL}/tasks/${id}`, {
            method: 'DELETE'
        });
        return this.handleResponse(response);
    },

    /**
     * Centralized response handling to simplify the caller logic.
     */
    async handleResponse(response) {
        if (!response.ok) {
            const error = await response.text();
            throw new Error(error || 'Network response was not ok');
        }
        
        // DELETE requests return 204 No Content
        if (response.status === 204) {
            return null;
        }

        return response.json();
    }
};
