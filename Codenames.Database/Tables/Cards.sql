-- Создание последовательности для первичного ключа таблицы Cards
CREATE SEQUENCE card_id_seq;

-- Создание таблицы Cards
CREATE TABLE "Cards"
(
    "CardID" bigint NOT NULL DEFAULT NEXTVAL('card_id_seq'),
    "ContentID" bigint NOT NULL,
    CONSTRAINT cards_pkey PRIMARY KEY ("CardID"),
    CONSTRAINT cards_fk_content_id FOREIGN KEY ("ContentID") REFERENCES "Contents"("ContentID") ON DELETE CASCADE
);