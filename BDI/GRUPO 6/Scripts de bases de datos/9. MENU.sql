/*==============================================================*/
/* DBMS name:      ORACLE Version 12c                           */
/* Created on:     31/10/2020 01:14:55                          */
/*==============================================================*/


alter table MENU
   drop constraint FK_MENU_REFERENCE_MENU;

alter table ROL_USUARIO
   drop constraint FK_ROL_USUA_REFERENCE_USUARIO;

alter table ROL_USUARIO
   drop constraint FK_ROL_USUA_REFERENCE_ROL2;

alter table ROL_USUARIO_MENU
   drop constraint FK_ROL_USUA_REFERENCE_ROL_USUA;

alter table ROL_USUARIO_MENU
   drop constraint FK_ROL_USUA_REFERENCE_MENU;

drop table MENU cascade constraints;

drop table ROL2 cascade constraints;

drop table ROL_USUARIO cascade constraints;

drop table ROL_USUARIO_MENU cascade constraints;

drop table USUARIO cascade constraints;

/*==============================================================*/
/* Table: MENU                                                  */
/*==============================================================*/
create table MENU (
   ID_MENU              NUMBER(6)             not null,
   NIVEL                NUMBER(2)             not null,
   NOMBRE               VARCHAR2(20)          not null,
   ID_MENU_SUPERIOR     NUMBER(6),
   constraint PK_MENU primary key (ID_MENU)
);

/*==============================================================*/
/* Table: ROL2                                                  */
/*==============================================================*/
create table ROL2 (
   ID_ROL2              NUMBER(6)             not null,
   NOMBRE               VARCHAR2(20)          not null,
   constraint PK_ROL2 primary key (ID_ROL2)
);

/*==============================================================*/
/* Table: ROL_USUARIO                                           */
/*==============================================================*/
create table ROL_USUARIO (
   ID_ROL_USUARIO       NUMBER(6)             not null,
   ID_USUARIO           NUMBER(6)             not null,
   ID_ROL               NUMBER(6)             not null,
   constraint PK_ROL_USUARIO primary key (ID_ROL_USUARIO, ID_USUARIO, ID_ROL)
);

/*==============================================================*/
/* Table: ROL_USUARIO_MENU                                      */
/*==============================================================*/
create table ROL_USUARIO_MENU (
   ID_ROL_USUARIO_MENU  NUMBER(6)             not null,
   ID_ROL_USUARIO       NUMBER(6)             not null,
   ID_USUARIO           NUMBER(6),
   ID_ROL               NUMBER(6),
   ID_MENU              NUMBER(6)             not null,
   constraint PK_ROL_USUARIO_MENU primary key (ID_ROL_USUARIO_MENU, ID_ROL_USUARIO, ID_MENU)
);

/*==============================================================*/
/* Table: USUARIO                                               */
/*==============================================================*/
create table USUARIO (
   ID_USUARIO           NUMBER(6)             not null,
   NOMBRE               VARCHAR2(20)          not null,
   CLAVE                VARHCAR2(20)          not null,
   constraint PK_USUARIO primary key (ID_USUARIO)
);

alter table MENU
   add constraint FK_MENU_REFERENCE_MENU foreign key (ID_MENU_SUPERIOR)
      references MENU (ID_MENU);

alter table ROL_USUARIO
   add constraint FK_ROL_USUA_REFERENCE_USUARIO foreign key (ID_USUARIO)
      references USUARIO (ID_USUARIO);

alter table ROL_USUARIO
   add constraint FK_ROL_USUA_REFERENCE_ROL2 foreign key (ID_ROL)
      references ROL2 (ID_ROL2);

alter table ROL_USUARIO_MENU
   add constraint FK_ROL_USUA_REFERENCE_ROL_USUA foreign key (ID_ROL_USUARIO, ID_USUARIO, ID_ROL)
      references ROL_USUARIO (ID_ROL_USUARIO, ID_USUARIO, ID_ROL);

alter table ROL_USUARIO_MENU
   add constraint FK_ROL_USUA_REFERENCE_MENU foreign key (ID_MENU)
      references MENU (ID_MENU);

