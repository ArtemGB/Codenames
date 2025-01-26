CREATE SEQUENCE content_type_id_seq;

-- Создание таблицы ContentTypes
CREATE TABLE "ContentTypes"
(
    "ContentTypeID" bigint NOT NULL DEFAULT NEXTVAL('content_type_id_seq'),
    "Description" character varying(255) NOT NULL,
    CONSTRAINT content_types_pkey PRIMARY KEY ("ContentTypeID")
);