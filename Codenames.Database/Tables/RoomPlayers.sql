-- Создание таблицы RoomPlayers
CREATE TABLE "RoomPlayers"
(
    "RoomID" bigint NOT NULL,
    "PlayerID" bigint NOT NULL,
    "IsCaptain" boolean NOT NULL,
    "IsRed" boolean NOT NULL,
    "SelectedCardID" bigint,
    CONSTRAINT room_players_pkey PRIMARY KEY ("RoomID", "PlayerID"),
    CONSTRAINT room_players_fk_room_id FOREIGN KEY ("RoomID") REFERENCES "Rooms"("RoomID") ON DELETE CASCADE,
    CONSTRAINT room_players_fk_player_id FOREIGN KEY ("PlayerID") REFERENCES "Players"("PlayerID") ON DELETE CASCADE,
    CONSTRAINT room_players_fk_card_id FOREIGN KEY ("SelectedCardID") REFERENCES "Cards"("CardID") ON DELETE CASCADE
);