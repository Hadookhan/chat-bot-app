-- STORES 2 USERS WHO ARE FRIENDS

CREATE TABLE connection_requests (
    id           INT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    from_user_id INT NOT NULL REFERENCES users(id),
    to_user_id   INT NOT NULL REFERENCES users(id),
    status       TEXT NOT NULL CHECK (status IN ('pending', 'accepted', 'rejected')),
    created_at   TIMESTAMPTZ NOT NULL DEFAULT now(),
    updated_at   TIMESTAMPTZ NOT NULL DEFAULT now()
);


CREATE TABLE connection (
    user_id INT NOT NULL REFERENCES users(id),
    friend_id INT NOT NULL REFERENCES user(id),
    created_at TIMESTAMPTZ NOT NULL DEFAULT now(), -- Timestamp with Timezone -> automatically sets default to now() time
    PRIMARY KEY (user_id, friend_id)
);