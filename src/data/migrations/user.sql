-- USER DATA

CREATE TABLE users (
    id INT GENERATED ALWAYS AS IDENTITY PRIMARY KEY, -- Increments id automatically
    email TEXT UNIQUE NOT NULL,
    username TEXT,
    created_at TIMESTAMPTZ NOT NULL DEFAULT now() -- Timestamp with Timezone -> automatically sets default to now() time
    -- password will be stored in env variable and used by auth database
);