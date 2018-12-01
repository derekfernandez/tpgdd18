--- BORRADO DE CONSTRAINTS ---

DECLARE @delete_var NVARCHAR(255) = ''
SELECT @delete_var = @delete_var + 'ALTER TABLE ' + QUOTENAME('SQLITO') + '.' + QUOTENAME(t.name) + ' DROP CONSTRAINT ' + 
	QUOTENAME(fk.name) + '; ' + CHAR(13)
FROM sys.tables t
JOIN sys.foreign_keys fk ON t.object_id = fk.parent_object_id
JOIN sys.schemas s ON t.schema_id = s.schema_id
WHERE s.name = 'SQLITO'
ORDER BY t.name
EXEC (@delete_var)
PRINT('Borrado de FKs finalizado')
 