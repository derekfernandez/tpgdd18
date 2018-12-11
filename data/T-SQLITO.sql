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
BEGIN TRANSACTION
	DECLARE @username NVARCHAR(255), @password VARBINARY(255)
	--Asigno US and PW
	SELECT @username = LOWER(SUBSTRING(@empresaRazonSocial,1,5)) + LOWER(SUBSTRING(@empresaRazonSocial,7,6)) + SUBSTRING(@empresaRazonSocial,17,2),@password = HASHBYTES('SHA2_256',CRYPT_GEN_RANDOM(8)) 
	
	INSERT INTO SQLITO.Usuarios (username, password, contraseniaActivada) VALUES (@username, @password, 0)
	INSERT INTO SQLITO.Roles_Usuarios (rol_id, usuario_id)VALUES (1,SCOPE_IDENTITY())

COMMIT TRANSACTION
	--Retorno el Id del usuario
	RETURN (select COUNT(*) FROM SQLITO.Usuarios)
END TRY
BEGIN CATCH
print ERROR_MESSAGE() 
rollback transaction 
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
begin try
begin transaction
DECLARE @fecha_creacion datetime
DECLARE @usuario_id int
DECLARE @id_Empresa int
--Falta vincularlo con prUsuarioEmpresa
IF EXISTS (select 1 from SQLITO.Empresas where razonsocial = @razonsocial) OR Exists(select 1 from SQLITO.Empresas where cuit = @cuit)
begin
PRINT 'Razon Social o CUIT no validos'
end
SET @fecha_creacion = GETDATE()
SET @id_Empresa =  (select COUNT(*) + 1 FROM SQLITO.Empresas) 
EXEC @usuario_id = pr_altaUsuario_empresa @id_Empresa, @razonsocial
insert into [GD2C2018].[SQLITO].[Empresas](razonsocial,fecha_creacion,cuit,mail,direccion,telefono,usuario_id) values (@razonsocial,@fecha_creacion,@cuit,@mail,@direccion,@telefono,@usuario_id)
commit transaction
end try
begin catch
print ERROR_MESSAGE()
rollback transaction 
end catch
end
GO
/*Si llegase a romper el identity usar:
GO
DBCC CHECKIDENT ('SQLITO.nomTabla', RESEED, ultimoValorTabla);
GO
*/ 
