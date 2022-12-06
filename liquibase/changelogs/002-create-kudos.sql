CREATE TABLE kudos (
    id SERIAL PRIMARY KEY, 
    sent TIMESTAMP NOT NULL,
    reason INTEGER NOT NULL,
    content TEXT NOT NULL,
    exchanged BOOLEAN NOT NULL DEFAULT FALSE,
    sender_id INTEGER REFERENCES employee(id) NOT NULL,
    receiver_id INTEGER REFERENCES employee(id) NOT NULL
    );