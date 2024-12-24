-- Создание последовательности для первичного ключа таблицы Players
CREATE SEQUENCE player_id_seq;

-- Создание таблицы Players
CREATE TABLE "Players"
(
    "PlayerID" bigint NOT NULL DEFAULT NEXTVAL('player_id_seq'),
    "Name" character varying(255) NOT NULL,
    CONSTRAINT players_pkey PRIMARY KEY ("PlayerID")
);