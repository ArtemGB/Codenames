-- Создание типа сardсolor для поля Color таблицы RoomCards
CREATE TYPE "сardсolor" AS ENUM ('Red', 'Blue', 'Gray', 'Black');

-- Создание таблицы RoomCards
CREATE TABLE "RoomCards"
(
    "RoomID" bigint NOT NULL,
    "CardID" bigint NOT NULL,
    "CardIndex" int NOT NULL,
    "Color" сardсolor NOT NULL,
    "IsDone" boolean DEFAULT FALSE NOT NULL,
    CONSTRAINT room_cards_pkey PRIMARY KEY ("RoomID", "CardID"),
    CONSTRAINT room_cards_fk_room_id FOREIGN KEY ("RoomID") REFERENCES "Rooms"("RoomID") ON DELETE CASCADE,
    CONSTRAINT room_cards_fk_card_id FOREIGN KEY ("CardID") REFERENCES "Cards"("CardID") ON DELETE CASCADE
);