-- Создание последовательности для первичного ключа таблицы Rooms
CREATE SEQUENCE room_id_seq;

-- Создание таблицы Rooms
CREATE TABLE "Rooms"
(
    "RoomID" bigint NOT NULL DEFAULT NEXTVAL('room_id_seq'),
    "Description" character varying(255) NOT NULL,
    "Password" character varying(100) NOT NULL,
    "IsRedMove" boolean NOT NULL,
    "FinalTime" timestamp with time zone,
    "NumberOfAssociations" int DEFAULT 0 NOT NULL,
    "WSChannel" character varying(255) NOT NULL,
    "MaxUsersAmount" int NOT NULL,
    CONSTRAINT rooms_pkey PRIMARY KEY ("RoomID")
);