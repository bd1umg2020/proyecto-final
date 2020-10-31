/*==============================================================*/
/* DBMS name:      ORACLE Version 12c                           */
/* Created on:     10/29/2020 11:08:00 PM                       */
/*==============================================================*/


alter table CONTACTO
   drop constraint FK_CONTACTO_REFERENCE_PROVEEDO;

alter table CONTACTO
   drop constraint FK_CONTACTO_REFERENCE_PERSONA;

alter table CUENTA_BANCO
   drop constraint FK_CUENTA_B_REFERENCE_TIPO_CUE;

alter table CUENTA_BANCO
   drop constraint FK_CUENTA_B_REFERENCE_BANCO;

alter table CUENTA_PAGAR
   drop constraint FK_CUENTA_P_REFERENCE_FACTURA_;

alter table DEPARTAMENTO_ESTADO_
   drop constraint FK_DEPARTAM_REFERENCE_PAIS;

alter table DETALLE_COMPRA
   drop constraint FK_DETALLE__REFERENCE_ORDEN_CO;

alter table DETALLE_COMPRA
   drop constraint FK_DETALLE__REFERENCE_PRODUCTO;

alter table DETALLE_RECEPCION
   drop constraint FK_DETALLE__REFERENCE_RECEPCIO;

alter table DETALLE_RECEPCION
   drop constraint FK_DETALLE__REFERENCE_DETALLE_;

alter table DETALLE_RECEPCION
   drop constraint FK_DETALLE__REFERENCE_SUCURSAL;

alter table DIRECCION
   drop constraint FK_DIRECCIO_REFERENCE_ZONA_SEC;

alter table EMPLEADO
   drop constraint FK_EMPLEADO_REFERENCE_PERSONA;

alter table EXISTENCIAS_SUCURSAL
   drop constraint FK_EXISTENC_REFERENCE_PRODUCTO;

alter table EXISTENCIAS_SUCURSAL
   drop constraint FK_EXISTENC_REFERENCE_SUCURSAL;

alter table FACTURA_PROVEEDOR
   drop constraint FK_FACTURA__REFERENCE_SERVICIO;

alter table FACTURA_PROVEEDOR
   drop constraint FK_FACTURA__REFERENCE_ORDEN_CO;

alter table MOV_BANCO
   drop constraint FK_MOV_BANC_REFERENCE_PAGAR_CU;

alter table MUNICIPIO_CIUDAD_
   drop constraint FK_MUNICIPI_REFERENCE_DEPARTAM;

alter table ORDEN_COMPRA
   drop constraint FK_ORDEN_CO_REFERENCE_PROVEEDO;

alter table ORDEN_COMPRA
   drop constraint FK_ORDEN_CO_REFERENCE_PUESTO_E;

alter table PAGAR_CUENTA
   drop constraint FK_PAGAR_CU_REFERENCE_CUENTA_P;

alter table PAGAR_CUENTA
   drop constraint FK_PAGAR_CU_REFERENCE_CUENTA_B;

alter table PAGAR_CUENTA
   drop constraint FK_PAGAR_CU_REFERENCE_FORMA_PA;

alter table PERSONA
   drop constraint FK_PERSONA_REFERENCE_DIRECCIO;

alter table PROVEEDOR
   drop constraint FK_PROVEEDO_REFERENCE_TIPO_PRO;

alter table PROVEEDOR
   drop constraint FK_PROVEEDO_REFERENCE_DIRECCIO;

alter table PUESTO_EMPLEADO
   drop constraint FK_PUESTO_E_REFERENCE_PUESTO;

alter table PUESTO_EMPLEADO
   drop constraint FK_PUESTO_E_REFERENCE_EMPLEADO;

alter table RECEPCION
   drop constraint FK_RECEPCIO_REFERENCE_PUESTO_E;

alter table ROL_EMPLEADO
   drop constraint FK_ROL_EMPL_REFERENCE_PUESTO_E;

alter table ROL_EMPLEADO
   drop constraint FK_ROL_EMPL_REFERENCE_ROL;

alter table SERVICIO
   drop constraint FK_SERVICIO_REFERENCE_PUESTO_E;

alter table SERVICIO
   drop constraint FK_SERVICIO_REFERENCE_PROVEEDO;

alter table SUCURSAL
   drop constraint FK_SUCURSAL_REFERENCE_TIPO_SUC;

alter table SUCURSAL
   drop constraint FK_SUCURSAL_REFERENCE_DIRECCIO;

alter table ZONA_SECTOR_
   drop constraint FK_ZONA_SEC_REFERENCE_MUNICIPI;

drop table BANCO cascade constraints;

drop table BITACORA cascade constraints;

drop table CONTACTO cascade constraints;

drop table CUENTA_BANCO cascade constraints;

drop table CUENTA_PAGAR cascade constraints;

drop table DEPARTAMENTO_ESTADO_ cascade constraints;

drop table DETALLE_COMPRA cascade constraints;

drop table DETALLE_RECEPCION cascade constraints;

drop table DIRECCION cascade constraints;

drop table EMPLEADO cascade constraints;

drop table EXISTENCIAS_SUCURSAL cascade constraints;

drop table FACTURA_PROVEEDOR cascade constraints;

drop table FORMA_PAGO cascade constraints;

drop table MOV_BANCO cascade constraints;

drop table MUNICIPIO_CIUDAD_ cascade constraints;

drop table ORDEN_COMPRA cascade constraints;

drop table PAGAR_CUENTA cascade constraints;

drop table PAIS cascade constraints;

drop table PERSONA cascade constraints;

drop table PRODUCTO cascade constraints;

drop table PROVEEDOR cascade constraints;

drop table PUESTO cascade constraints;

drop table PUESTO_EMPLEADO cascade constraints;

drop table RECEPCION cascade constraints;

drop table ROL cascade constraints;

drop table ROL_EMPLEADO cascade constraints;

drop table SERVICIO cascade constraints;

drop table SUCURSAL cascade constraints;

drop table TIPO_CUENTA cascade constraints;

drop table TIPO_PROVEEDOR cascade constraints;

drop table TIPO_SUCURSAL cascade constraints;

drop table ZONA_SECTOR_ cascade constraints;

/*==============================================================*/
/* Table: BANCO                                                 */
/*==============================================================*/
create table BANCO (
   ID_BANCO             NUMBER(15)            not null,
   NOMBRE_BANCO         VARCHAR(20),
   constraint PK_BANCO primary key (ID_BANCO)
);

/*==============================================================*/
/* Table: BITACORA                                              */
/*==============================================================*/
create table BITACORA (
   CORRELATIVO          number(15)            not null,
   NOMBRE_TABLA         VARCHAR2(30),
   USUARIO              VARCHAR2(30),
   FECHA                DATE,
   VALOR_ANTIGUO        VARCHAR2(4000),
   VALOR_NUEVO          VARCHAR2(4000),
   ATRIBUTO             VARCHAR2(30),
   ATRIBUTO_LLAVE       VARCHAR2(100),
   ATRIBUTO_ORACLE      VARCHAR2(200),
   TIPO                 VARCHAR2(200),
   constraint PK_BITACORA primary key (CORRELATIVO)
);

/*==============================================================*/
/* Table: CONTACTO                                              */
/*==============================================================*/
create table CONTACTO (
   ID_CONTACTO          NUMBER(15)            not null,
   ID_PROVEEDOR         NUMBER(15),
   ID_PERSONA           NUMBER(15),
   constraint PK_CONTACTO primary key (ID_CONTACTO)
);

/*==============================================================*/
/* Table: CUENTA_BANCO                                          */
/*==============================================================*/
create table CUENTA_BANCO (
   ID_CUENTA_BANCO      NUMBER(15)            not null,
   ID_TIPO_CUENTA       NUMBER(15),
   ID_BANCO             NUMBER(15),
   NO_CUENTA            NUMBER(15),
   SALDO                DECIMAL(15, 2),
   constraint PK_CUENTA_BANCO primary key (ID_CUENTA_BANCO)
);

/*==============================================================*/
/* Table: CUENTA_PAGAR                                          */
/*==============================================================*/
create table CUENTA_PAGAR (
   ID_CUENTA_PAGAR      NUMBER(10)            not null,
   ID_FACTURA_PROVEEDOR NUMBER(10),
   constraint PK_CUENTA_PAGAR primary key (ID_CUENTA_PAGAR)
);

/*==============================================================*/
/* Table: DEPARTAMENTO_ESTADO_                                  */
/*==============================================================*/
create table DEPARTAMENTO_ESTADO_ (
   ID_DEPARTAMENTO      NUMBER(15)            not null,
   ID_PAIS              NUMBER(15),
   NOMBRE_DEPARTAMENTO  VARCHAR2(20),
   constraint PK_DEPARTAMENTO_ESTADO_ primary key (ID_DEPARTAMENTO)
);

/*==============================================================*/
/* Table: DETALLE_COMPRA                                        */
/*==============================================================*/
create table DETALLE_COMPRA (
   ID_DETALLE_COMPRA    NUMBER(15)            not null,
   ID_ORDEN_COMPRA      NUMBER(15),
   ID_PRODUCTO          NUMBER(15),
   CANTIDAD             NUMBER(15),
   PRECIO               decimal(15,2),
   constraint PK_DETALLE_COMPRA primary key (ID_DETALLE_COMPRA)
);

/*==============================================================*/
/* Table: DETALLE_RECEPCION                                     */
/*==============================================================*/
create table DETALLE_RECEPCION (
   ID_DETALLE_RECEPCION NUMBER(15)            not null,
   ID_RECEPCION         NUMBER(15),
   ID_DETALLE_COMPRA    NUMBER(15),
   ID_SUCURSAL          NUMBER(15),
   PRECIO               decimal(15,2),
   CANTIDAD             NUMBER(15),
   constraint PK_DETALLE_RECEPCION primary key (ID_DETALLE_RECEPCION)
);

/*==============================================================*/
/* Table: DIRECCION                                             */
/*==============================================================*/
create table DIRECCION (
   ID_DIRECCION         NUMBER(15)            not null,
   ID_ZONA              NUMBER(15),
   DIRECCION            VARCHAR2(100),
   constraint PK_DIRECCION primary key (ID_DIRECCION)
);

/*==============================================================*/
/* Table: EMPLEADO                                              */
/*==============================================================*/
create table EMPLEADO (
   ID_EMPLEADO          NUMBER(15)            not null,
   ID_PERSONA           NUMBER(15),
   STATUS               VARCHAR2(20),
   constraint PK_EMPLEADO primary key (ID_EMPLEADO)
);

/*==============================================================*/
/* Table: EXISTENCIAS_SUCURSAL                                  */
/*==============================================================*/
create table EXISTENCIAS_SUCURSAL (
   ID_EXISTENCIAS_SUCURSAL NUMBER(15)            not null,
   ID_PRODUCTO          NUMBER(15),
   ID_SUCURSAL          NUMBER(15),
   EXISTENCIAS          NUMBER(15),
   constraint PK_EXISTENCIAS_SUCURSAL primary key (ID_EXISTENCIAS_SUCURSAL)
);

/*==============================================================*/
/* Table: FACTURA_PROVEEDOR                                     */
/*==============================================================*/
create table FACTURA_PROVEEDOR (
   ID_FACTURA_PROVEEDOR NUMBER(15)            not null,
   ID_SERVICIO          NUMBER(15),
   ID_ORDEN_COMPRA      NUMBER(15),
   NUMERO_FACTURA       NUMBER(15),
   FECHA                DATE,
   MONTO                decimal(15,2),
   constraint PK_FACTURA_PROVEEDOR primary key (ID_FACTURA_PROVEEDOR)
);

/*==============================================================*/
/* Table: FORMA_PAGO                                            */
/*==============================================================*/
create table FORMA_PAGO (
   ID_FORMA_PAGO        NUMBER(15)            not null,
   NOMBRE_FORMA_PAGO    VARCHAR2(20),
   constraint PK_FORMA_PAGO primary key (ID_FORMA_PAGO)
);

/*==============================================================*/
/* Table: MOV_BANCO                                             */
/*==============================================================*/
create table MOV_BANCO (
   ID_MOV_BANCO         NUMBER(15)            not null,
   ID_PAGAR_CUENTA      NUMBER(15),
   SALDO_ANTERIOR       DECIMAL(15, 2),
   SALDO_NUEVO          DECIMAL(15, 2),
   constraint PK_MOV_BANCO primary key (ID_MOV_BANCO)
);

/*==============================================================*/
/* Table: MUNICIPIO_CIUDAD_                                     */
/*==============================================================*/
create table MUNICIPIO_CIUDAD_ (
   ID_MUNICIPIO         NUMBER(15)            not null,
   ID_DEPARTAMENTO      NUMBER(15),
   NOMBRE_MUNICIPIO     VARCHAR2(20),
   constraint PK_MUNICIPIO_CIUDAD_ primary key (ID_MUNICIPIO)
);

/*==============================================================*/
/* Table: ORDEN_COMPRA                                          */
/*==============================================================*/
create table ORDEN_COMPRA (
   ID_ORDEN_COMPRA      NUMBER(15)            not null,
   ID_PROVEEDOR         NUMBER(15),
   ID_PUESTO_EMPLEADO   NUMBER(15),
   FECHA                DATE,
   STATUS_APROBACION    char,
   STATUS_RECEPCION     char,
   constraint PK_ORDEN_COMPRA primary key (ID_ORDEN_COMPRA)
);

/*==============================================================*/
/* Table: PAGAR_CUENTA                                          */
/*==============================================================*/
create table PAGAR_CUENTA (
   ID_PAGAR_CUENTA      NUMBER(15)            not null,
   ID_FORMA_PAGO        NUMBER(15),
   ID_CUENTA_PAGAR      NUMBER(15),
   ID_CUENTA_BANCO      NUMBER(15),
   MONTO                decimal(15,2),
   NUMERO_DOCUMENTO     NUMBER(15),
   FECHA                DATE,
   constraint PK_PAGAR_CUENTA primary key (ID_PAGAR_CUENTA)
);

/*==============================================================*/
/* Table: PAIS                                                  */
/*==============================================================*/
create table PAIS (
   ID_PAIS              NUMBER(15)            not null,
   NOMBRE_PAIS          VARCHAR2(20),
   constraint PK_PAIS primary key (ID_PAIS)
);

/*==============================================================*/
/* Table: PERSONA                                               */
/*==============================================================*/
create table PERSONA (
   ID_PERSONA           NUMBER(15)            not null,
   ID_DIRECCION         NUMBER(15),
   NOMBRE_PERSONA       VARCHAR2(20),
   APELLIDO_PERSONA     VARCHAR2(20),
   GENERO               CHAR,
   CORREO_PERSONA       VARCHAR2(40),
   DPI_PERSONA          NUMBER(15),
   NIT_PERSONA          VARCHAR2(20),
   TELEFONO             VARCHAR2(20),
   constraint PK_PERSONA primary key (ID_PERSONA)
);

/*==============================================================*/
/* Table: PRODUCTO                                              */
/*==============================================================*/
create table PRODUCTO (
   ID_PRODUCTO          NUMBER(15)            not null,
   NOMBRE_PRODUCTO      VARCHAR2(20),
   constraint PK_PRODUCTO primary key (ID_PRODUCTO)
);

/*==============================================================*/
/* Table: PROVEEDOR                                             */
/*==============================================================*/
create table PROVEEDOR (
   ID_PROVEEDOR         NUMBER(15)            not null,
   ID_TIPO_PROVEEDOR    NUMBER(15),
   ID_DIRECCION         NUMBER(15),
   NOMBRE_PROVEEDOR     VARCHAR2(20),
   NIT_PROVEEDOR        VARCHAR(20),
   constraint PK_PROVEEDOR primary key (ID_PROVEEDOR)
);

/*==============================================================*/
/* Table: PUESTO                                                */
/*==============================================================*/
create table PUESTO (
   ID_PUESTO            NUMBER(10)            not null,
   NOMBRE_PUESTO        VARCHAR(40),
   constraint PK_PUESTO primary key (ID_PUESTO)
);

/*==============================================================*/
/* Table: PUESTO_EMPLEADO                                       */
/*==============================================================*/
create table PUESTO_EMPLEADO (
   ID_PUESTO_EMPLEADO   NUMBER(15)            not null,
   ID_PUESTO            NUMBER(15),
   ID_EMPLEADO          NUMBER(15),
   FECHA_INICIO         DATE,
   FECHA_FIN            DATE,
   constraint PK_PUESTO_EMPLEADO primary key (ID_PUESTO_EMPLEADO)
);

/*==============================================================*/
/* Table: RECEPCION                                             */
/*==============================================================*/
create table RECEPCION (
   ID_RECEPCION         NUMBER(15)            not null,
   ID_PUESTO_EMPLEADO   NUMBER(15),
   NUMERO_ENVIO         VARCHAR2(20),
   FECHA                DATE,
   constraint PK_RECEPCION primary key (ID_RECEPCION)
);

/*==============================================================*/
/* Table: ROL                                                   */
/*==============================================================*/
create table ROL (
   ID_ROL               NUMBER(15)            not null,
   NOMBRE_ROL           varchar2(20),
   constraint PK_ROL primary key (ID_ROL)
);

/*==============================================================*/
/* Table: ROL_EMPLEADO                                          */
/*==============================================================*/
create table ROL_EMPLEADO (
   ID_ROL_EMPLEADO      number(15)            not null,
   ID_PUESTO_EMPLEADO   NUMBER(15),
   ID_ROL               NUMBER(15),
   constraint PK_ROL_EMPLEADO primary key (ID_ROL_EMPLEADO)
);

/*==============================================================*/
/* Table: SERVICIO                                              */
/*==============================================================*/
create table SERVICIO (
   ID_SERVICIO          NUMBER(15)            not null,
   ID_PROVEEDOR         NUMBER(15),
   ID_PUESTO_EMPLEADO   NUMBER(15),
   NOMBRE_SERVICIO      VARCHAR2(20),
   PRECIO               DEC(15, 2),
   constraint PK_SERVICIO primary key (ID_SERVICIO)
);

/*==============================================================*/
/* Table: SUCURSAL                                              */
/*==============================================================*/
create table SUCURSAL (
   ID_SUCURSAL          NUMBER(15)            not null,
   ID_DIRECCION         NUMBER(15),
   ID_TIPO_SUCURSAL     number(15),
   NOMBRE_SUCURSAL      VARCHAR2(20),
   constraint PK_SUCURSAL primary key (ID_SUCURSAL)
);

/*==============================================================*/
/* Table: TIPO_CUENTA                                           */
/*==============================================================*/
create table TIPO_CUENTA (
   ID_TIPO_CUENTA       NUMBER(15)            not null,
   TIPO_CUENTA          VARCHAR(20),
   constraint PK_TIPO_CUENTA primary key (ID_TIPO_CUENTA)
);

/*==============================================================*/
/* Table: TIPO_PROVEEDOR                                        */
/*==============================================================*/
create table TIPO_PROVEEDOR (
   ID_TIPO_PROVEEDOR    NUMBER(15)            not null,
   NOMBRE_TIPO_PROVEEDOR VARCHAR2(20),
   constraint PK_TIPO_PROVEEDOR primary key (ID_TIPO_PROVEEDOR)
);

/*==============================================================*/
/* Table: TIPO_SUCURSAL                                         */
/*==============================================================*/
create table TIPO_SUCURSAL (
   ID_TIPO_SUCURSAL     number(15)            not null,
   NOMBRE_TIPO_SUCURSAL varchar2(20),
   constraint PK_TIPO_SUCURSAL primary key (ID_TIPO_SUCURSAL)
);

/*==============================================================*/
/* Table: ZONA_SECTOR_                                          */
/*==============================================================*/
create table ZONA_SECTOR_ (
   ID_ZONA              NUMBER(15)            not null,
   ID_MUNICIPIO         NUMBER(15),
   NOMBRE_ZONA          VARCHAR2(20),
   constraint PK_ZONA_SECTOR_ primary key (ID_ZONA)
);

alter table CONTACTO
   add constraint FK_CONTACTO_REFERENCE_PROVEEDO foreign key (ID_PROVEEDOR)
      references PROVEEDOR (ID_PROVEEDOR);

alter table CONTACTO
   add constraint FK_CONTACTO_REFERENCE_PERSONA foreign key (ID_PERSONA)
      references PERSONA (ID_PERSONA);

alter table CUENTA_BANCO
   add constraint FK_CUENTA_B_REFERENCE_TIPO_CUE foreign key (ID_TIPO_CUENTA)
      references TIPO_CUENTA (ID_TIPO_CUENTA);

alter table CUENTA_BANCO
   add constraint FK_CUENTA_B_REFERENCE_BANCO foreign key (ID_BANCO)
      references BANCO (ID_BANCO);

alter table CUENTA_PAGAR
   add constraint FK_CUENTA_P_REFERENCE_FACTURA_ foreign key (ID_FACTURA_PROVEEDOR)
      references FACTURA_PROVEEDOR (ID_FACTURA_PROVEEDOR);

alter table DEPARTAMENTO_ESTADO_
   add constraint FK_DEPARTAM_REFERENCE_PAIS foreign key (ID_PAIS)
      references PAIS (ID_PAIS);

alter table DETALLE_COMPRA
   add constraint FK_DETALLE__REFERENCE_ORDEN_CO foreign key (ID_ORDEN_COMPRA)
      references ORDEN_COMPRA (ID_ORDEN_COMPRA);

alter table DETALLE_COMPRA
   add constraint FK_DETALLE__REFERENCE_PRODUCTO foreign key (ID_PRODUCTO)
      references PRODUCTO (ID_PRODUCTO);

alter table DETALLE_RECEPCION
   add constraint FK_DETALLE__REFERENCE_RECEPCIO foreign key (ID_RECEPCION)
      references RECEPCION (ID_RECEPCION);

alter table DETALLE_RECEPCION
   add constraint FK_DETALLE__REFERENCE_DETALLE_ foreign key (ID_DETALLE_COMPRA)
      references DETALLE_COMPRA (ID_DETALLE_COMPRA);

alter table DETALLE_RECEPCION
   add constraint FK_DETALLE__REFERENCE_SUCURSAL foreign key (ID_SUCURSAL)
      references SUCURSAL (ID_SUCURSAL);

alter table DIRECCION
   add constraint FK_DIRECCIO_REFERENCE_ZONA_SEC foreign key (ID_ZONA)
      references ZONA_SECTOR_ (ID_ZONA);

alter table EMPLEADO
   add constraint FK_EMPLEADO_REFERENCE_PERSONA foreign key (ID_PERSONA)
      references PERSONA (ID_PERSONA);

alter table EXISTENCIAS_SUCURSAL
   add constraint FK_EXISTENC_REFERENCE_PRODUCTO foreign key (ID_PRODUCTO)
      references PRODUCTO (ID_PRODUCTO);

alter table EXISTENCIAS_SUCURSAL
   add constraint FK_EXISTENC_REFERENCE_SUCURSAL foreign key (ID_SUCURSAL)
      references SUCURSAL (ID_SUCURSAL);

alter table FACTURA_PROVEEDOR
   add constraint FK_FACTURA__REFERENCE_SERVICIO foreign key (ID_SERVICIO)
      references SERVICIO (ID_SERVICIO);

alter table FACTURA_PROVEEDOR
   add constraint FK_FACTURA__REFERENCE_ORDEN_CO foreign key (ID_ORDEN_COMPRA)
      references ORDEN_COMPRA (ID_ORDEN_COMPRA);

alter table MOV_BANCO
   add constraint FK_MOV_BANC_REFERENCE_PAGAR_CU foreign key (ID_PAGAR_CUENTA)
      references PAGAR_CUENTA (ID_PAGAR_CUENTA);

alter table MUNICIPIO_CIUDAD_
   add constraint FK_MUNICIPI_REFERENCE_DEPARTAM foreign key (ID_DEPARTAMENTO)
      references DEPARTAMENTO_ESTADO_ (ID_DEPARTAMENTO);

alter table ORDEN_COMPRA
   add constraint FK_ORDEN_CO_REFERENCE_PROVEEDO foreign key (ID_PROVEEDOR)
      references PROVEEDOR (ID_PROVEEDOR);

alter table ORDEN_COMPRA
   add constraint FK_ORDEN_CO_REFERENCE_PUESTO_E foreign key (ID_PUESTO_EMPLEADO)
      references PUESTO_EMPLEADO (ID_PUESTO_EMPLEADO);

alter table PAGAR_CUENTA
   add constraint FK_PAGAR_CU_REFERENCE_CUENTA_P foreign key (ID_CUENTA_PAGAR)
      references CUENTA_PAGAR (ID_CUENTA_PAGAR);

alter table PAGAR_CUENTA
   add constraint FK_PAGAR_CU_REFERENCE_CUENTA_B foreign key (ID_CUENTA_BANCO)
      references CUENTA_BANCO (ID_CUENTA_BANCO);

alter table PAGAR_CUENTA
   add constraint FK_PAGAR_CU_REFERENCE_FORMA_PA foreign key (ID_FORMA_PAGO)
      references FORMA_PAGO (ID_FORMA_PAGO);

alter table PERSONA
   add constraint FK_PERSONA_REFERENCE_DIRECCIO foreign key (ID_DIRECCION)
      references DIRECCION (ID_DIRECCION);

alter table PROVEEDOR
   add constraint FK_PROVEEDO_REFERENCE_TIPO_PRO foreign key (ID_TIPO_PROVEEDOR)
      references TIPO_PROVEEDOR (ID_TIPO_PROVEEDOR);

alter table PROVEEDOR
   add constraint FK_PROVEEDO_REFERENCE_DIRECCIO foreign key (ID_DIRECCION)
      references DIRECCION (ID_DIRECCION);

alter table PUESTO_EMPLEADO
   add constraint FK_PUESTO_E_REFERENCE_PUESTO foreign key (ID_PUESTO)
      references PUESTO (ID_PUESTO);

alter table PUESTO_EMPLEADO
   add constraint FK_PUESTO_E_REFERENCE_EMPLEADO foreign key (ID_EMPLEADO)
      references EMPLEADO (ID_EMPLEADO);

alter table RECEPCION
   add constraint FK_RECEPCIO_REFERENCE_PUESTO_E foreign key (ID_PUESTO_EMPLEADO)
      references PUESTO_EMPLEADO (ID_PUESTO_EMPLEADO);

alter table ROL_EMPLEADO
   add constraint FK_ROL_EMPL_REFERENCE_PUESTO_E foreign key (ID_PUESTO_EMPLEADO)
      references PUESTO_EMPLEADO (ID_PUESTO_EMPLEADO);

alter table ROL_EMPLEADO
   add constraint FK_ROL_EMPL_REFERENCE_ROL foreign key (ID_ROL)
      references ROL (ID_ROL);

alter table SERVICIO
   add constraint FK_SERVICIO_REFERENCE_PUESTO_E foreign key (ID_PUESTO_EMPLEADO)
      references PUESTO_EMPLEADO (ID_PUESTO_EMPLEADO);

alter table SERVICIO
   add constraint FK_SERVICIO_REFERENCE_PROVEEDO foreign key (ID_PROVEEDOR)
      references PROVEEDOR (ID_PROVEEDOR);

alter table SUCURSAL
   add constraint FK_SUCURSAL_REFERENCE_TIPO_SUC foreign key (ID_TIPO_SUCURSAL)
      references TIPO_SUCURSAL (ID_TIPO_SUCURSAL);

alter table SUCURSAL
   add constraint FK_SUCURSAL_REFERENCE_DIRECCIO foreign key (ID_DIRECCION)
      references DIRECCION (ID_DIRECCION);

alter table ZONA_SECTOR_
   add constraint FK_ZONA_SEC_REFERENCE_MUNICIPI foreign key (ID_MUNICIPIO)
      references MUNICIPIO_CIUDAD_ (ID_MUNICIPIO);

