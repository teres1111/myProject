PGDMP  ,    
            	    |         	   TestStady    16.3    16.3     �           0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                      false            �           0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                      false            �           0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                      false            �           1262    25399 	   TestStady    DATABASE        CREATE DATABASE "TestStady" WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE_PROVIDER = libc LOCALE = 'Russian_Russia.1251';
    DROP DATABASE "TestStady";
                postgres    false                        2615    33548 
   Accounting    SCHEMA        CREATE SCHEMA "Accounting";
    DROP SCHEMA "Accounting";
                postgres    false            �            1259    33566    income    TABLE     �   CREATE TABLE "Accounting".income (
    "Id" integer NOT NULL,
    "Date" timestamp with time zone NOT NULL,
    "Category" text NOT NULL,
    "Amount" numeric NOT NULL,
    "Comment" text NOT NULL
);
     DROP TABLE "Accounting".income;
    
   Accounting         heap    postgres    false    8            �            1259    33565    income_Id_seq    SEQUENCE     �   CREATE SEQUENCE "Accounting"."income_Id_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 ,   DROP SEQUENCE "Accounting"."income_Id_seq";
    
   Accounting          postgres    false    8    228            �           0    0    income_Id_seq    SEQUENCE OWNED BY     O   ALTER SEQUENCE "Accounting"."income_Id_seq" OWNED BY "Accounting".income."Id";
       
   Accounting          postgres    false    227            �            1259    41741    transaction    TABLE     �   CREATE TABLE "Accounting".transaction (
    "Id" integer NOT NULL,
    "Date" timestamp with time zone NOT NULL,
    type text NOT NULL,
    "Category" text NOT NULL,
    "Amount" numeric NOT NULL,
    "Comment" text NOT NULL
);
 %   DROP TABLE "Accounting".transaction;
    
   Accounting         heap    postgres    false    8            �            1259    41740    transaction_Id_seq    SEQUENCE     �   CREATE SEQUENCE "Accounting"."transaction_Id_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 1   DROP SEQUENCE "Accounting"."transaction_Id_seq";
    
   Accounting          postgres    false    230    8            �           0    0    transaction_Id_seq    SEQUENCE OWNED BY     Y   ALTER SEQUENCE "Accounting"."transaction_Id_seq" OWNED BY "Accounting".transaction."Id";
       
   Accounting          postgres    false    229            ;           2604    33569 	   income Id    DEFAULT     v   ALTER TABLE ONLY "Accounting".income ALTER COLUMN "Id" SET DEFAULT nextval('"Accounting"."income_Id_seq"'::regclass);
 @   ALTER TABLE "Accounting".income ALTER COLUMN "Id" DROP DEFAULT;
    
   Accounting          postgres    false    228    227    228            <           2604    41744    transaction Id    DEFAULT     �   ALTER TABLE ONLY "Accounting".transaction ALTER COLUMN "Id" SET DEFAULT nextval('"Accounting"."transaction_Id_seq"'::regclass);
 E   ALTER TABLE "Accounting".transaction ALTER COLUMN "Id" DROP DEFAULT;
    
   Accounting          postgres    false    230    229    230            �          0    33566    income 
   TABLE DATA           U   COPY "Accounting".income ("Id", "Date", "Category", "Amount", "Comment") FROM stdin;
 
   Accounting          postgres    false    228   x       �          0    41741    transaction 
   TABLE DATA           `   COPY "Accounting".transaction ("Id", "Date", type, "Category", "Amount", "Comment") FROM stdin;
 
   Accounting          postgres    false    230   �       �           0    0    income_Id_seq    SEQUENCE SET     C   SELECT pg_catalog.setval('"Accounting"."income_Id_seq"', 4, true);
       
   Accounting          postgres    false    227            �           0    0    transaction_Id_seq    SEQUENCE SET     H   SELECT pg_catalog.setval('"Accounting"."transaction_Id_seq"', 6, true);
       
   Accounting          postgres    false    229            >           2606    33573    income PK_income 
   CONSTRAINT     X   ALTER TABLE ONLY "Accounting".income
    ADD CONSTRAINT "PK_income" PRIMARY KEY ("Id");
 B   ALTER TABLE ONLY "Accounting".income DROP CONSTRAINT "PK_income";
    
   Accounting            postgres    false    228            @           2606    41748    transaction PK_transaction 
   CONSTRAINT     b   ALTER TABLE ONLY "Accounting".transaction
    ADD CONSTRAINT "PK_transaction" PRIMARY KEY ("Id");
 L   ALTER TABLE ONLY "Accounting".transaction DROP CONSTRAINT "PK_transaction";
    
   Accounting            postgres    false    230            �   v   x�U�A�0E�3�`o��Li{7�Am"�PB���_���@Y;���x��%՚Wށ�k,i�P@B�F������Ҙ���7��F|�,Zߚxu�o�<�a �u��t�K��u �      �   �   x���[
�@E�3�迴$����Z��:ց>���܌��Pw�)"x�	!pn"��UH"�$#�Ha:C�Zե���X /��E&��dxQ�'H^k ���U�V�7�:$����@n������Bα(1��#�>ش{W�����X%�F�����v���w_w?�~$-"!���R(     