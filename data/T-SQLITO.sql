USE [GD2C2018]
GO
--PROC ALTA USUARIOS PARA EMPRESAS YA IMPORTADAS DEL MASTER
IF EXISTS (SELECT * FROM sys.procedures WHERE name = 'pr_altaUsuario_empresa')
BEGIN
	DROP PROCEDURE [pr_altaUsuario_empresa]
END
GO
CREATE PROCEDURE [dbo].[pr_altaUsuario_empresa] (@empresaID INT, @empresaRazonSocial nvarchar(255))
AS
BEGIN
BEGIN TRY
	DECLARE @username NVARCHAR(255), @password VARBINARY(255)
	DECLARE @identity numeric(18,0)
	SET @identity = (select count(*) from SQLITO.Usuarios)
	--Asigno US and PW
BEGIN TRANSACTION
	SELECT @username = LOWER(SUBSTRING(@empresaRazonSocial,1,5)) + LOWER(SUBSTRING(@empresaRazonSocial,7,6)) + SUBSTRING(@empresaRazonSocial,17,2),@password = HASHBYTES('SHA2_256',CRYPT_GEN_RANDOM(8)) 
	
	INSERT INTO SQLITO.Usuarios (username, password, contraseniaActivada) VALUES (@username, @password, 0)
	INSERT INTO SQLITO.Roles_Usuarios (rol_id, usuario_id)VALUES (1,SCOPE_IDENTITY()) 

COMMIT TRANSACTION
	--Retorno el Id del usuario
	RETURN (select COUNT(*) FROM SQLITO.Usuarios)
END TRY
BEGIN CATCH
rollback transaction
DBCC CHECKIDENT ('SQLITO.Usuarios', RESEED,@identity);
THROW 50000, 'FALLO CREACION USUARIO', 1
END CATCH
END
GO

--PROC PARA ALTA EMPRESAS 
IF EXISTS (SELECT * FROM sys.procedures WHERE name = 'pr_Alta_Empresa')
BEGIN
	DROP PROCEDURE pr_Alta_Empresa
END
GO
CREATE proc [dbo].[pr_Alta_Empresa](@razonsocial nvarchar(255), 
    @cuit nvarchar(255),
    @mail nvarchar(50),
    @direccion nvarchar(255),
    @telefono nvarchar(30))
as
begin
DECLARE @fecha_creacion datetime
DECLARE @usuario_id int
DECLARE @id_Empresa int
DECLARE @identity numeric(18,0)
SET @identity = (select count(*) from SQLITO.Empresas)

--Razon Social Repetida
IF EXISTS (select 1 from SQLITO.Empresas where razonsocial = @razonsocial)
THROW 50000, 'RAZON SOCIAL YA EXISTENTE', 1

--Cuit Repetido
IF Exists(select 1 from SQLITO.Empresas where cuit = @cuit)
THROW 50000, 'CUIT YA EXISTENTE', 1

--Cuit Repetido
IF Exists(select 1 from SQLITO.Empresas where mail = @mail)
THROW 50000, 'MAIL YA EXISTENTE', 1
 
SET @fecha_creacion = GETDATE()
SET @id_Empresa =  (select COUNT(*) + 1 FROM SQLITO.Empresas)

begin try
begin transaction
EXEC @usuario_id = pr_altaUsuario_empresa @id_Empresa, @razonsocial
insert into [GD2C2018].[SQLITO].[Empresas](razonsocial,fecha_creacion,cuit,mail,direccion,telefono,usuario_id) values (@razonsocial,@fecha_creacion,@cuit,@mail,@direccion,@telefono,@usuario_id)
commit transaction

end try

begin catch
DECLARE @Cambios numeric(18,0)
SET @Cambios = (select count(*) from SQLITO.Grados)
--Se detectan cambios
IF(@identity != @Cambios)
BEGIN
ROLLBACK TRANSACTION
SET @id_Empresa = @id_Empresa - 1
DBCC CHECKIDENT ('SQLITO.Usuarios', RESEED,@id_Empresa) WITH NO_INFOMSGS;
DBCC CHECKIDENT ('SQLITO.Empresas', RESEED,@identity) WITH NO_INFOMSGS;
END;
THROW
end catch

END

GO

--PROC PARA MODIFICAR EMPRESAS 
IF EXISTS (SELECT * FROM sys.procedures WHERE name = 'pr_Modificar_Empresa')
BEGIN
	DROP PROCEDURE pr_Modificar_Empresa
END
GO
CREATE proc [dbo].[pr_Modificar_Empresa](@razonsocial nvarchar(255), 
    @cuit nvarchar(255),
    @mail nvarchar(50),
    @direccion nvarchar(255),
    @telefono nvarchar(30),
	@idEmpresa int)
as
begin
--Razon Social Repetida que no es la misma que la que se inserta
IF EXISTS (select 1 from SQLITO.Empresas where razonsocial = @razonsocial AND id_empresa != @idEmpresa)
THROW 50000, 'RAZON SOCIAL YA EXISTENTE', 1

--Cuit Repetido que no es el mismo que se inserta
IF Exists(select 1 from SQLITO.Empresas where cuit = @cuit AND id_empresa != @idEmpresa)
THROW 50000, 'CUIT YA EXISTENTE', 1

--Cuit Repetido
IF Exists(select 1 from SQLITO.Empresas where mail = @mail AND id_empresa != @idEmpresa)
THROW 50000, 'MAIL YA EXISTENTE', 1
 
begin try
begin transaction
update [GD2C2018].[SQLITO].[Empresas] set razonsocial = @razonsocial,cuit =@cuit,mail=@mail,direccion=@direccion,telefono=@telefono where id_empresa =@idEmpresa
commit transaction
end try

begin catch
IF @@ROWCOUNT != 0  
ROLLBACK TRANSACTION
THROW
end catch

END

--PROC PARA ELIMINAR EMPRESA -> DESHABILITA SU USUARIO -> HAY QUE AGREGAR EL NUEVO FLAG DE EMPRESA HABILITADA
GO
IF EXISTS (SELECT * FROM sys.procedures WHERE name = 'pr_Eliminar_empresa')
BEGIN
	DROP PROCEDURE pr_Eliminar_empresa
END
GO
create proc pr_Eliminar_empresa (@idEmpresa int)
as
begin
begin try
DECLARE @ID_USER INT
SET @ID_USER = (SELECT usuario_id FROM SQLITO.Empresas WHERE id_empresa = @idEmpresa)
begin transaction
UPDATE SQLITO.Usuarios SET habilitado = 0 WHERE id_usuario = @ID_USER
commit transaction
end try
begin catch
ROLLBACK TRAN
SELECT ERROR_MESSAGE()
end catch
end
GO

--PROC PARA CREAR UN GRADO
IF EXISTS (SELECT * FROM sys.procedures WHERE name = 'pr_Carga_Grado')
BEGIN
	DROP PROCEDURE pr_Carga_Grado
END
GO
create proc pr_Carga_Grado (@descripcion nvarchar(255),@comision numeric(6,2))
as
begin
begin try
DECLARE @identity numeric(18,0)
SET @identity = (select count(*) from SQLITO.Grados)

--Descripcion ya existente
IF EXISTS(select 1 from SQLITO.Grados WHERE descripcion = @descripcion)
THROW 50000, 'DESCRIPCION YA EXISTENTE', 1

begin transaction
INSERT INTO SQLITO.Grados(descripcion,comision) values(@descripcion,@comision)
commit transaction
end try
begin catch
DECLARE @Cambios numeric(18,0)
SET @Cambios = (select count(*) from SQLITO.Grados)
IF(@identity != @Cambios)
BEGIN
ROLLBACK TRAN
DBCC CHECKIDENT ('SQLITO.Grados', RESEED, @identity) WITH NO_INFOMSGS;
END;
THROW
end catch
end
GO
IF EXISTS (SELECT * FROM sys.procedures WHERE name = 'pr_Mod_Grado')
BEGIN
	DROP PROCEDURE pr_Mod_Grado
END
GO
CREATE proc pr_Mod_Grado(@descripcion nvarchar(255), 
    @comision numeric(6,2),
    @habilitado bit,
	@idGrado int)
as
begin

--Descripcion repetida y no existente
IF EXISTS (select 1 from SQLITO.Grados where descripcion = @descripcion and id_grado != @idGrado)
THROW 50000, 'DESCRIPCION YA REGISTRADA', 1

begin try
begin transaction
update [GD2C2018].[SQLITO].Grados set descripcion = @descripcion,comision =@comision,habilitado=@habilitado where id_grado = @idGrado
commit transaction
end try

begin catch
IF @@ROWCOUNT != 0  
ROLLBACK TRANSACTION
THROW
end catch

END

/*Si llegase a romper el identity usar:
GO
DBCC CHECKIDENT ('SQLITO.nomTabla', RESEED, ultimoValorTabla);
GO
*/ 