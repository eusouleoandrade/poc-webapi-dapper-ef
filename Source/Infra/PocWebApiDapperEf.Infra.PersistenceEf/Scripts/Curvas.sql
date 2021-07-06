CREATE TABLE IF NOT EXISTS public."Curvas"
(
    "Id" uuid NOT NULL,
    "Description" character varying(128) COLLATE pg_catalog."default" NOT NULL,
    CONSTRAINT "PK_Customers" PRIMARY KEY ("Id")
)