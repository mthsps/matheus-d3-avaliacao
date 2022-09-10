create table users
(
    user_id     numeric not null unique,
    user_name   varchar(255)   not null,
    email       varchar(255)   not null,
    pass    varchar(50)     not null
);