-- Создание последовательности для первичного ключа таблицы Contents
CREATE SEQUENCE content_id_seq;

-- Создание таблицы Contents
CREATE TABLE "Contents"
(
    "ContentID" bigint NOT NULL DEFAULT NEXTVAL('content_id_seq'),
    "ContentTypeID" bigint NOT NULL,
    "Entity" text NOT NULL,
    CONSTRAINT contents_pkey PRIMARY KEY ("ContentID"),
    CONSTRAINT contents_fk_content_type_id FOREIGN KEY ("ContentTypeID") REFERENCES "ContentTypes"("ContentTypeID") ON DELETE CASCADE
);