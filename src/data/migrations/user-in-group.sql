-- USERS IN GROUPS DATA

CREATE TABLE user_in_group (
    user_id INT NOT NULL REFERENCES users(id),
    group_id INT NOT NULL REFERENCES groups(id),
    is_admin BOOLEAN NOT NULL DEFAULT false,
    PRIMARY KEY (user_id, group_id) -- Composite Primary Key
);