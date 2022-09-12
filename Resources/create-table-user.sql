create table users
(
    user_id  UNIQUEIDENTIFIER PRIMARY KEY default NEWID(),
    name     varchar(255) not null,
    email    varchar(255) not null,
    password varchar(255) not null
);