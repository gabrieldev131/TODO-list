

/**
 * TagBadge Component.
 * 
 * Study Material:
 * A simple presentational component for displaying task tags. 
 * SOLID: Single Responsibility Principle.
 */
export const TagBadge = ({ tag }) => {
    return (
        <span style={{
            display: 'inline-block',
            padding: '2px 8px',
            margin: '0 5px 5px 0',
            backgroundColor: '#e0e0e0',
            borderRadius: '12px',
            fontSize: '0.75em',
            color: '#333'
        }}>
            #{tag}
        </span>
    );
};
