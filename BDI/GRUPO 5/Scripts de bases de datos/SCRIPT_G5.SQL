/*==============================================================*/
/* DBMS name:      ORACLE Version 11g                           */
/* Created on:     30/10/2020 17:50:57                          */
/*==============================================================*/


alter table ALDEA
   drop constraint FK_ALDEA_REFERENCE_MUNICIPI;

alter table CLIENTE
   drop constraint FK_CLIENTE_REFERENCE_PERSONA;

alter table COLONIA
   drop constraint FK_COLONIA_REFERENCE_ZONA;

alter table DETALLE_ESTADOCTA
   drop constraint FK_DETALLE__REFERENCE_PAGO;

alter table DETALLE_FACTURA
   drop constraint FK_DETALLE__REFERENCE_FACTURA;

alter table DIRECCION
   drop constraint FK_DIRECCIO_REFERENCE_ALDEA;

alter table DIRECCION
   drop constraint FK_DIRECCIO_REFERENCE_COLONIA;

alter table DIRECCION_CLIENTE
   drop constraint FK_DIRECCIO_REFERENCE_CLIENTE;

alter table DIRECCION_CLIENTE
   drop constraint FK_DIRECCIO_REFERENCE_DIRECCIO;

alter table ENCUESTACLIENTE
   drop constraint FK_ENCUESTA_REFERENCE_SUCURSAL;

alter table ENCUESTACLIENTE
   drop constraint FK_ENCUESTA_REFERENCE_PREGUNTA;

alter table ENCUESTACLIENTE
   drop constraint FK_ENCUESTA_REFERENCE_RESPUEST;

alter table ENCUESTACLIENTE
   drop constraint FK_ENCUESTA_REFERENCE_ENCUESTA;

alter table FACTURA
   drop constraint FK_FACTURA_REFERENCE_CLIENTE;

alter table FACTURA
   drop constraint FK_FACTURA_REFERENCE_SUCURSAL;

alter table MUNICIPIO
   drop constraint FK_MUNICIPI_REFERENCE_DEPARTAM;

alter table PAGO
   drop constraint FK_PAGO_REFERENCE_FACTURA;

alter table PAGO_FORMAPAGO
   drop constraint FK_PAGO_FOR_REFERENCE_PAGO;

alter table PAGO_FORMAPAGO
   drop constraint FK_PAGO_FOR_REFERENCE_FORMA_PA;

alter table PERSONA
   drop constraint FK_PERSONA_REFERENCE_TIPO_PER;

alter table PREGUNTA
   drop constraint FK_PREGUNTA_REFERENCE_ENCUESTA;

alter table SUCURSAL
   drop constraint FK_SUCURSAL_REFERENCE_DIRECCIO;

alter table ZONA
   drop constraint FK_ZONA_REFERENCE_MUNICIPI;

drop table ALDEA cascade constraints;

drop table BITACORA cascade constraints;

drop table CLIENTE cascade constraints;

drop table COLONIA cascade constraints;

drop table DEPARTAMENTO cascade constraints;

drop table DETALLE_ESTADOCTA cascade constraints;

drop table DETALLE_FACTURA cascade constraints;

drop table DIRECCION cascade constraints;

drop table DIRECCION_CLIENTE cascade constraints;

drop table ENCUESTA cascade constraints;

drop table ENCUESTACLIENTE cascade constraints;

drop table FACTURA cascade constraints;

drop table FORMA_PAGO cascade constraints;

drop table MUNICIPIO cascade constraints;

drop table PAGO cascade constraints;

drop table PAGO_FORMAPAGO cascade constraints;

drop table PERSONA cascade constraints;

drop table PREGUNTA cascade constraints;

drop table RESPUESTA_OFR cascade constraints;

drop table SUCURSAL cascade constraints;

drop table TIPO_PERSONA cascade constraints;

drop table ZONA cascade constraints;

drop sequence SEQ_ALDEA;

drop sequence SEQ_BITACORA;

drop sequence SEQ_CLIENTE;

drop sequence SEQ_COLONIA;

drop sequence SEQ_DEPTO;

drop sequence SEQ_DIRECCION;

drop sequence SEQ_ENCUESTA;

drop sequence SEQ_EPR;

drop sequence SEQ_ESTADOCTA;

drop sequence SEQ_FACTURA;

drop sequence SEQ_FORMAPA;

drop sequence SEQ_MUNICIPIO;

drop sequence SEQ_PERSONA;

drop sequence SEQ_PREGUNTA;

drop sequence SEQ_RESPOFR;

drop sequence SEQ_SUCURSAL;

drop sequence SEQ_TIPOPERSONA;

drop sequence SEQ_ZONA;

create sequence SEQ_ALDEA
increment by 1
start with 1
 maxvalue 99999
 minvalue 1;

create sequence SEQ_BITACORA
increment by 1
start with 1
 maxvalue 999999
 minvalue 1;

create sequence SEQ_CLIENTE
increment by 1
start with 1
 maxvalue 99999
 minvalue 1;

create sequence SEQ_COLONIA
increment by 1
start with 1
 maxvalue 99999
 minvalue 1;

create sequence SEQ_DEPTO
increment by 1
start with 1
 maxvalue 99999
 minvalue 1;

create sequence SEQ_DIRECCION
increment by 1
start with 1
 maxvalue 99999
 minvalue 1;

create sequence SEQ_ENCUESTA
increment by 1
start with 1
 maxvalue 99999
 minvalue 1;

create sequence SEQ_EPR
increment by 1
start with 1
 maxvalue 99999
 minvalue 1;

create sequence SEQ_ESTADOCTA
increment by 1
start with 1
 maxvalue 99999
 minvalue 1;

create sequence SEQ_FACTURA
increment by 1
start with 1
 maxvalue 999999
 minvalue 1;

create sequence SEQ_FORMAPA;

create sequence SEQ_MUNICIPIO
increment by 1
start with 1
 maxvalue 99999
 minvalue 1;

create sequence SEQ_PERSONA
increment by 1
start with 1
 maxvalue 99999
 minvalue 1;

create sequence SEQ_PREGUNTA
increment by 1
start with 1
 maxvalue 99999
 minvalue 1;

create sequence SEQ_RESPOFR
increment by 1
start with 1
 maxvalue 99999
 minvalue 1;

create sequence SEQ_SUCURSAL
increment by 1
start with 1
 maxvalue 99999
 minvalue 1;

create sequence SEQ_TIPOPERSONA
increment by 1
start with 1
 maxvalue 99999
 minvalue 1;

create sequence SEQ_ZONA
increment by 1
start with 1
 maxvalue 100
 minvalue 1;

/*==============================================================*/
/* Table: ALDEA                                                 */
/*==============================================================*/
create table ALDEA 
(
   COD_ALDEA            NUMBER(10)           not null,
   COD_MUNICIPIO        NUMBER(10),
   ALDEA                varchar2(100)        not null,
   constraint PK_ALDEA primary key (COD_ALDEA)
);

/*==============================================================*/
/* Table: BITACORA                                              */
/*==============================================================*/
create table BITACORA 
(
   CORRELATIVO          NUMBER(6)            not null,
   NOMBRE_TABLA         varchar2(100),
   USUARIO              varchar2(100),
   FECHA                DATE,
   VALOR_ANTIGUO        NUMBER(15),
   VALOR_NUEVO          NUMBER(15),
   ATRIBUTO             varchar2(30),
   ATRIBUTO_LLAVE       varchar2(30),
   ATRIBUTO_ORACLE      varchar2(30),
   TIPO                 varchar2(200),
   constraint PK_BITACORA primary key (CORRELATIVO)
);

/*==============================================================*/
/* Table: CLIENTE                                               */
/*==============================================================*/
create table CLIENTE 
(
   ID_CLIENTE           NUMBER(10)           not null,
   ID_PERSONA           NUMBER(10),
   constraint PK_CLIENTE primary key (ID_CLIENTE)
);

/*==============================================================*/
/* Table: COLONIA                                               */
/*==============================================================*/
create table COLONIA 
(
   COD_COLONIA          NUMBER(10)           not null,
   COD_ZONA             NUMBER(10),
   COLONIA              varchar2(100)        not null,
   constraint PK_COLONIA primary key (COD_COLONIA)
);

/*==============================================================*/
/* Table: DEPARTAMENTO                                          */
/*==============================================================*/
create table DEPARTAMENTO 
(
   COD_DEPTO            NUMBER(10)           not null,
   DEPARTAMENTO         varchar2(200)        not null,
   constraint PK_DEPARTAMENTO primary key (COD_DEPTO)
);

/*==============================================================*/
/* Table: DETALLE_ESTADOCTA                                     */
/*==============================================================*/
create table DETALLE_ESTADOCTA 
(
   ID_DETALLE           NUMBER(15)           not null,
   ID_FACTURA           NUMBER(10),
   SERIE_FACTURA        VARCHAR2(10),
   NUM_DOC_PAGO         NUMBER(10),
   FECHA                DATE,
   DESCRIPCION          varchar2(300),
   DEBITO               NUMBER(10,2),
   CREDITO              NUMBER(10,2),
   SALDO                NUMBER(10,2),
   constraint PK_DETALLE_ESTADOCTA primary key (ID_DETALLE)
);

/*==============================================================*/
/* Table: DETALLE_FACTURA                                       */
/*==============================================================*/
create table DETALLE_FACTURA 
(
   ID_FACTURA           NUMBER(10)           not null,
   SERIE_FACTURA        VARCHAR2(10)         not null,
   ID_PRODUCTO          NUMBER(10)           not null,
   CANTIDAD             NUMBER(10)           not null,
   PRECIO               NUMBER(8,2)          not null,
   constraint PK_DETALLE_FACTURA primary key (ID_FACTURA, SERIE_FACTURA)
);

/*==============================================================*/
/* Table: DIRECCION                                             */
/*==============================================================*/
create table DIRECCION 
(
   ID_DIRECCION         NUMBER(10)           not null,
   COD_ALDEA            NUMBER(10),
   COD_COLONIA          NUMBER(10),
   CALLE_AVENIDA        varchar2(200),
   NUMERO_CASA          varchar2(30),
   OBSERVACIONES        varchar2(700),
   constraint PK_DIRECCION primary key (ID_DIRECCION)
);

/*==============================================================*/
/* Table: DIRECCION_CLIENTE                                     */
/*==============================================================*/
create table DIRECCION_CLIENTE 
(
   ID_CLIENTE           NUMBER(10),
   ID_DIRECCION         NUMBER(10)           not null,
   constraint PK_DIRECCION_CLIENTE primary key (ID_DIRECCION)
);

/*==============================================================*/
/* Table: ENCUESTA                                              */
/*==============================================================*/
create table ENCUESTA 
(
   ID_ENCUESTA          NUMBER(10)           not null,
   DESCRIPCION          varchar2(300),
   FECHA_INICIO         DATE,
   FECHA_FIN            DATE,
   ESTADO               varchar2(1),
   constraint PK_ENCUESTA primary key (ID_ENCUESTA)
);

/*==============================================================*/
/* Table: ENCUESTACLIENTE                                       */
/*==============================================================*/
create table ENCUESTACLIENTE 
(
   ID_ENC               NUMBER(10)           not null,
   ID_SUCURSAL          NUMBER(5)            not null,
   ID_ENCUESTA          NUMBER(10),
   ID_PREGUNTA          NUMBER(10),
   ID_RESPOF            NUMBER(10)           not null,
   FECHA                DATE,
   constraint PK_ENCUESTACLIENTE primary key (ID_ENC)
);

/*==============================================================*/
/* Table: FACTURA                                               */
/*==============================================================*/
create table FACTURA 
(
   ID_FACTURA           NUMBER(10)           not null,
   SERIE_FACTURA        VARCHAR2(10)         not null,
   ID_CLIENTE           NUMBER(10),
   ID_SUCURSAL          NUMBER(5),
   FECHA                DATE                 not null,
   constraint PK_FACTURA primary key (ID_FACTURA, SERIE_FACTURA)
);

/*==============================================================*/
/* Table: FORMA_PAGO                                            */
/*==============================================================*/
create table FORMA_PAGO 
(
   ID_FORMPAGO          NUMBER(6)            not null,
   FORMA_PAGO           VARCHAR2(100)        not null,
   constraint PK_FORMA_PAGO primary key (ID_FORMPAGO)
);

/*==============================================================*/
/* Table: MUNICIPIO                                             */
/*==============================================================*/
create table MUNICIPIO 
(
   COD_MUNICIPIO        NUMBER(10)           not null,
   COD_DEPTO            NUMBER(10),
   MUNICIPIO            varchar2(200)        not null,
   COLUMN_4             CHAR(10),
   constraint PK_MUNICIPIO primary key (COD_MUNICIPIO)
);

/*==============================================================*/
/* Table: PAGO                                                  */
/*==============================================================*/
create table PAGO 
(
   ID_FACTURA           NUMBER(10)           not null,
   SERIE_FACTURA        VARCHAR2(10)         not null,
   FECHA                DATE                 not null,
   MONTO                NUMBER(10,2)         not null,
   NUM_DOC_PAGO         NUMBER(10)           not null,
   constraint PK_PAGO primary key (ID_FACTURA, SERIE_FACTURA, NUM_DOC_PAGO),
   constraint AK_KEY_2_PAGO unique (NUM_DOC_PAGO)
);

/*==============================================================*/
/* Table: PAGO_FORMAPAGO                                        */
/*==============================================================*/
create table PAGO_FORMAPAGO 
(
   ID_FACTURA           NUMBER(10)           not null,
   SERIE_FACTURA        VARCHAR2(10)         not null,
   NUM_DOC_PAGO         NUMBER(10)           not null,
   ID_FORMPAGO          INTEGER              not null,
   constraint PK_PAGO_FORMAPAGO primary key (NUM_DOC_PAGO)
);

/*==============================================================*/
/* Table: PERSONA                                               */
/*==============================================================*/
create table PERSONA 
(
   ID_PERSONA           NUMBER(10)           not null,
   ID_TIPOPER           NUMBER(10)           not null,
   NOMBRE               varchar2(400)        not null,
   APELLIDO             varchar2(400),
   NIT                  VARCHAR2(8),
   TELEFONO             NUMBER(8),
   CORREO               VARCHAR2(200),
   constraint PK_PERSONA primary key (ID_PERSONA)
);

/*==============================================================*/
/* Table: PREGUNTA                                              */
/*==============================================================*/
create table PREGUNTA 
(
   ID_PREGUNTA          NUMBER(10)           not null,
   ID_ENCUESTA          NUMBER(10),
   TEXTO_PREGUNTA       varchar2(3000),
   constraint PK_PREGUNTA primary key (ID_PREGUNTA)
);

/*==============================================================*/
/* Table: RESPUESTA_OFR                                         */
/*==============================================================*/
create table RESPUESTA_OFR 
(
   ID_RESPOF            NUMBER(10)           not null,
   RESPUESTA            varchar2(4000),
   constraint PK_RESPUESTA_OFR primary key (ID_RESPOF)
);

/*==============================================================*/
/* Table: SUCURSAL                                              */
/*==============================================================*/
create table SUCURSAL 
(
   ID_SUCURSAL          NUMBER(5)            not null,
   ID_DIRECCION         NUMBER(10),
   SUCURSAL             VARCHAR2(50),
   constraint PK_SUCURSAL primary key (ID_SUCURSAL)
);

/*==============================================================*/
/* Table: TIPO_PERSONA                                          */
/*==============================================================*/
create table TIPO_PERSONA 
(
   ID_TIPOPER           NUMBER(10)           not null,
   TIPO_PERSONA         VARCHAR2(300),
   constraint PK_TIPO_PERSONA primary key (ID_TIPOPER)
);

/*==============================================================*/
/* Table: ZONA                                                  */
/*==============================================================*/
create table ZONA 
(
   COD_ZONA             NUMBER(10)           not null,
   COD_MUNICIPIO        NUMBER(10),
   ZONA                 NUMBER(2),
   constraint PK_ZONA primary key (COD_ZONA)
);

alter table ALDEA
   add constraint FK_ALDEA_REFERENCE_MUNICIPI foreign key (COD_MUNICIPIO)
      references MUNICIPIO (COD_MUNICIPIO);

alter table CLIENTE
   add constraint FK_CLIENTE_REFERENCE_PERSONA foreign key (ID_PERSONA)
      references PERSONA (ID_PERSONA);

alter table COLONIA
   add constraint FK_COLONIA_REFERENCE_ZONA foreign key (COD_ZONA)
      references ZONA (COD_ZONA);

alter table DETALLE_ESTADOCTA
   add constraint FK_DETALLE__REFERENCE_PAGO foreign key (ID_FACTURA, SERIE_FACTURA, NUM_DOC_PAGO)
      references PAGO (ID_FACTURA, SERIE_FACTURA, NUM_DOC_PAGO);

alter table DETALLE_FACTURA
   add constraint FK_DETALLE__REFERENCE_FACTURA foreign key (ID_FACTURA, SERIE_FACTURA)
      references FACTURA (ID_FACTURA, SERIE_FACTURA);

alter table DIRECCION
   add constraint FK_DIRECCIO_REFERENCE_ALDEA foreign key (COD_ALDEA)
      references ALDEA (COD_ALDEA);

alter table DIRECCION
   add constraint FK_DIRECCIO_REFERENCE_COLONIA foreign key (COD_COLONIA)
      references COLONIA (COD_COLONIA);

alter table DIRECCION_CLIENTE
   add constraint FK_DIRECCIO_REFERENCE_CLIENTE foreign key (ID_CLIENTE)
      references CLIENTE (ID_CLIENTE);

alter table DIRECCION_CLIENTE
   add constraint FK_DIRECCIO_REFERENCE_DIRECCIO foreign key (ID_DIRECCION)
      references DIRECCION (ID_DIRECCION);

alter table ENCUESTACLIENTE
   add constraint FK_ENCUESTA_REFERENCE_SUCURSAL foreign key (ID_SUCURSAL)
      references SUCURSAL (ID_SUCURSAL);

alter table ENCUESTACLIENTE
   add constraint FK_ENCUESTA_REFERENCE_PREGUNTA foreign key (ID_PREGUNTA)
      references PREGUNTA (ID_PREGUNTA);

alter table ENCUESTACLIENTE
   add constraint FK_ENCUESTA_REFERENCE_RESPUEST foreign key (ID_RESPOF)
      references RESPUESTA_OFR (ID_RESPOF);

alter table ENCUESTACLIENTE
   add constraint FK_ENCUESTA_REFERENCE_ENCUESTA foreign key (ID_ENCUESTA)
      references ENCUESTA (ID_ENCUESTA);

alter table FACTURA
   add constraint FK_FACTURA_REFERENCE_CLIENTE foreign key (ID_CLIENTE)
      references CLIENTE (ID_CLIENTE);

alter table FACTURA
   add constraint FK_FACTURA_REFERENCE_SUCURSAL foreign key (ID_SUCURSAL)
      references SUCURSAL (ID_SUCURSAL);

alter table MUNICIPIO
   add constraint FK_MUNICIPI_REFERENCE_DEPARTAM foreign key (COD_DEPTO)
      references DEPARTAMENTO (COD_DEPTO);

alter table PAGO
   add constraint FK_PAGO_REFERENCE_FACTURA foreign key (ID_FACTURA, SERIE_FACTURA)
      references FACTURA (ID_FACTURA, SERIE_FACTURA);

alter table PAGO_FORMAPAGO
   add constraint FK_PAGO_FOR_REFERENCE_PAGO foreign key (ID_FACTURA, SERIE_FACTURA, NUM_DOC_PAGO)
      references PAGO (ID_FACTURA, SERIE_FACTURA, NUM_DOC_PAGO);

alter table PAGO_FORMAPAGO
   add constraint FK_PAGO_FOR_REFERENCE_FORMA_PA foreign key (ID_FORMPAGO)
      references FORMA_PAGO (ID_FORMPAGO);

alter table PERSONA
   add constraint FK_PERSONA_REFERENCE_TIPO_PER foreign key (ID_TIPOPER)
      references TIPO_PERSONA (ID_TIPOPER);

alter table PREGUNTA
   add constraint FK_PREGUNTA_REFERENCE_ENCUESTA foreign key (ID_ENCUESTA)
      references ENCUESTA (ID_ENCUESTA);

alter table SUCURSAL
   add constraint FK_SUCURSAL_REFERENCE_DIRECCIO foreign key (ID_DIRECCION)
      references DIRECCION (ID_DIRECCION);

alter table ZONA
   add constraint FK_ZONA_REFERENCE_MUNICIPI foreign key (COD_MUNICIPIO)
      references MUNICIPIO (COD_MUNICIPIO);

