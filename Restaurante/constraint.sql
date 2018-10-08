--
--PRIMARIAS
 ALTER TABLE UTILIZA ADD
  CONSTRAINT UTILIZA_01
  PRIMARY KEY (nombrep, nombrei);
 --
ALTER TABLE PLATO ADD
  CONSTRAINT PLATO_01
  PRIMARY KEY (nombrep);
 
-- Foreign Key 
-- 
ALTER TABLE PLATO ADD 
 CONSTRAINT PLATO_01
 FOREIGN KEY (nombrec) 
 REFERENCES CATEGORIA(nombrec);


 ALTER TABLE PLATO ADD 
 CONSTRAINT PLATO_02
 FOREIGN KEY (nombrep) 
 REFERENCES UTILIZA(nombrep);

 ALTER TABLE INGRED ADD 
 CONSTRAINT INGRED_01
 FOREIGN KEY (nombrei) 
 REFERENCES UTILIZA(nombrei);
 
 --TABLAS
 
 CREATE TABLE [dbo].[CATEGORIA](
	[nombrec] [varchar](100) NOT NULL,
	[descrip] [varchar](2000) NULL,
	[encarg] [varchar](100) NULL,
 CONSTRAINT [PK_CATEGORIA] PRIMARY KEY CLUSTERED 
(
	[nombrec] ASC
);

CREATE TABLE [dbo].[INGRED](
	[nombrei] [varchar](100) NOT NULL,
	[unidades] [decimal](18, 0) NULL,
	[almacen] [decimal](18, 0) NULL,
	[nombrep] [varchar](100) NULL,
 CONSTRAINT [PK_INGRED] PRIMARY KEY CLUSTERED 
(
	[nombrei] ASC
);

CREATE TABLE [dbo].[PLATO](
	[nombrep] [varchar](100) NOT NULL,
	[descrip] [varchar](2000) NULL,
	[nivel] [int] NULL,
	[foto] [nvarchar](max) NULL,
	[precio] [decimal](18, 0) NULL,
	[nombrec] [varchar](100) NULL,
	[nombrei] [varchar](100) NULL
);
CREATE TABLE [dbo].[UTILIZA](
	[nombrep] [varchar](100) NOT NULL,
	[nombrei] [varchar](100) NOT NULL,
	[cantidad] [int] NULL
);