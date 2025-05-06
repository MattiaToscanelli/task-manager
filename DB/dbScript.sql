-- Create the database (run this separately, not within the same transaction)
CREATE DATABASE task_manager;

-- Connect to the database before running the below:
-- \c task_manager

CREATE TABLE boards (
    id SERIAL PRIMARY KEY,
    name VARCHAR(255) NOT NULL
);

CREATE TABLE lists (
    id SERIAL PRIMARY KEY,
    name VARCHAR(255) NOT NULL,
    board_id INT,
    FOREIGN KEY (board_id) REFERENCES boards(id)
);

CREATE TABLE task_priority (
    id SERIAL PRIMARY KEY,
    name VARCHAR(50) NOT NULL
);

CREATE TABLE tasks (
    id SERIAL PRIMARY KEY,
    title VARCHAR(255) NOT NULL,
    description TEXT,
    task_priority_id INT,
    list_id INT,
    FOREIGN KEY (task_priority_id) REFERENCES task_priority(id),
    FOREIGN KEY (list_id) REFERENCES lists(id)
);
