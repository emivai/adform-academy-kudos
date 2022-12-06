CREATE TABLE kudos (
    id SERIAL PRIMARY KEY, 
    sent_date DATE,
    reason INTEGER,
    content TEXT,
    exchanged BOOLEAN,
    sender_id INTEGER REFERENCES employee(id),
    receiver_id INTEGER REFERENCES employee(id)
    );