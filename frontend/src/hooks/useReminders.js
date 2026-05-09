import { useEffect, useRef } from 'react';

/**
 * useReminders Hook.
 * 
 * Tracks active reminders and triggers alerts when the time is reached.
 */
export const useReminders = (tasks) => {
    const notifiedRef = useRef(new Set());

    useEffect(() => {
        const interval = setInterval(() => {
            const now = new Date();
            
            tasks.forEach(task => {
                if (task.reminderAt && !notifiedRef.current.has(task.id)) {
                    const reminderTime = new Date(task.reminderAt);
                    
                    // If reminder time has passed (within the last minute to avoid old ones)
                    if (reminderTime <= now && now.getTime() - reminderTime.getTime() < 60000) {
                        alert(`REMINDER: ${task.title}\n${task.description || ''}`);
                        notifiedRef.current.add(task.id);
                    }
                }
            });
        }, 5000); // Check every 5 seconds

        return () => clearInterval(interval);
    }, [tasks]);
};
