-- �������� �� Codenames
CREATE DATABASE "Codenames"
    WITH
    OWNER = postgres
    ENCODING = 'UTF8';


-- �������� ������������������ ��� ���������� ����� ������� ContentTypes
CREATE SEQUENCE content_type_id_seq;

-- �������� ������� ContentTypes
CREATE TABLE "ContentTypes"
(
    "ContentTypeID" bigint NOT NULL DEFAULT NEXTVAL('content_type_id_seq'),
    "Description" character varying(255) NOT NULL,
    CONSTRAINT content_types_pkey PRIMARY KEY ("ContentTypeID")
);

-- �������� ������������������ ��� ���������� ����� ������� Contents
CREATE SEQUENCE content_id_seq;

-- �������� ������� Contents
CREATE TABLE "Contents"
(
    "ContentID" bigint NOT NULL DEFAULT NEXTVAL('content_id_seq'),
    "ContentTypeID" bigint NOT NULL,
    "Entity" text NOT NULL,
    CONSTRAINT contents_pkey PRIMARY KEY ("ContentID"),
    CONSTRAINT contents_fk_content_type_id FOREIGN KEY ("ContentTypeID") REFERENCES "ContentTypes"("ContentTypeID") ON DELETE CASCADE
);

-- �������� ������������������ ��� ���������� ����� ������� Cards
CREATE SEQUENCE card_id_seq;

-- �������� ������� Cards
CREATE TABLE "Cards"
(
    "CardID" bigint NOT NULL DEFAULT NEXTVAL('card_id_seq'),
    "ContentID" bigint NOT NULL,
    CONSTRAINT cards_pkey PRIMARY KEY ("CardID"),
    CONSTRAINT cards_fk_content_id FOREIGN KEY ("ContentID") REFERENCES "Contents"("ContentID") ON DELETE CASCADE
);

-- �������� ������������������ ��� ���������� ����� ������� Players
CREATE SEQUENCE player_id_seq;

-- �������� ������� Players
CREATE TABLE "Players"
(
    "PlayerID" bigint NOT NULL DEFAULT NEXTVAL('player_id_seq'),
    "Name" character varying(255) NOT NULL,
    CONSTRAINT players_pkey PRIMARY KEY ("PlayerID")
);

-- �������� ������������������ ��� ���������� ����� ������� Rooms
CREATE SEQUENCE room_id_seq;

-- �������� ������� Rooms
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

-- �������� ���� �ard�olor ��� ���� Color ������� RoomCards
CREATE TYPE "�ard�olor" AS ENUM ('Red', 'Blue', 'Gray', 'Black');

-- �������� ������� RoomCards
CREATE TABLE "RoomCards"
(
    "RoomID" bigint NOT NULL,
    "CardID" bigint NOT NULL,
    "CardIndex" int NOT NULL,
    "Color" �ard�olor NOT NULL,
    "IsDone" boolean DEFAULT FALSE NOT NULL,
    CONSTRAINT room_cards_pkey PRIMARY KEY ("RoomID", "CardID"),
    CONSTRAINT room_cards_fk_room_id FOREIGN KEY ("RoomID") REFERENCES "Rooms"("RoomID") ON DELETE CASCADE,
    CONSTRAINT room_cards_fk_card_id FOREIGN KEY ("CardID") REFERENCES "Cards"("CardID") ON DELETE CASCADE
);

-- �������� ������� RoomPlayers
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
