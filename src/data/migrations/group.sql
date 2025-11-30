-- GROUP DATA

CREATE TABLE groups (
    id INT GENERATED ALWAYS AS IDENTITY PRIMARY KEY, -- Increments id automatically
    group_name TEXT NOT NULL,
    created_at TIMESTAMPTZ NOT NULL DEFAULT now() -- Timestamp with Timezone -> automatically sets default to now() time
);