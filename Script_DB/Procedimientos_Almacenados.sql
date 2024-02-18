/* -------- CREACIÓN DE PROCEDIMIENTO ALMACENADO -------- */

/* -------- AREA DE TRABAJO -------- */
--ALTER PROC SP_AREA_TRABAJO (
--	@pOpcion INT
--)
--AS

--DECLARE @pOpcion INT = 0;

BEGIN
	-- OBTENER TODO
	IF @pOpcion = 0 
	BEGIN 
		SELECT id, area_trabajo AS [AreaDeTrabajo] FROM tb_area_trabajo;
	END
END;

/* -------- PAÍS -------- */
--ALTER PROC SP_PAIS (
--	@pOpcion INT
--)
--AS

--DECLARE @pOpcion INT = 0;

BEGIN
	-- OBTENER TODO
	IF @pOpcion = 0 
	BEGIN 
		SELECT id, pais AS [NombrePais] FROM tb_pais;
	END
END;

/* -------- TIPO DOCUMENTO -------- */
--ALTER PROC SP_TIPO_DOCUMENTO (
--	@pOpcion INT
--)
--AS

--DECLARE @pOpcion INT = 0;

BEGIN
	-- OBTENER TODO
	IF @pOpcion = 0 
	BEGIN 
		SELECT id, tipo_documento AS [TipoDeDocumento] FROM tb_tipo_documento;
	END
END;

/* -------- EMPLEADO -------- */
--ALTER PROC SP_EMPLEADO (
--	@pOpcion INT,
--	@estado INT = -1,
--	@nombres VARCHAR(50) = '',
--	@apellidos VARCHAR(50) = '',
--	@codigoTelefono VARCHAR(10) = '',
--	@telefono VARCHAR(16) = '',
--	@correo VARCHAR(50) = '',
--	@fechaNacimiento DATE = NULL,
--	@sueldo DECIMAL(10,2) = 0,
--	@estadoCivil VARCHAR(10) = '',
--	@idAreaTrabajo INT = 0,
--	@idPaisNacimiento INT = 0,
--	@idTipoDocumento INT = 0,
--	@nroDocumento VARCHAR(16) = '',
--	@sexo CHAR(1) = '',
--	@idEmpleado INT = 0
--)
--AS

--DECLARE @pOpcion INT = 0;

BEGIN
	-- OBTENER TODO POR CRITERIOS
	IF @pOpcion = 0 
	BEGIN 
		SELECT  
			E.id,
			E.nombres,
			E.apellidos,
			E.codigo_telefono		AS [CodigoTelefono],
			E.telefono,
			E.correo,
			E.fecha_nacimiento		AS [FechaNacimiento],
			E.sueldo,
			E.estado_civil			AS [EstadoCivil],
			E.id_area_trabajo		AS [IdAreaTrabajo],
			T.area_trabajo			AS [AreaTrabajo],
			E.id_pais_nacimiento	AS [IdPaisNacimiento],
			P.pais					AS [PaisNacimiento],
			E.id_tipo_documento		AS [IdTipoDocumento],
			TD.tipo_documento		AS [TipoDocumento],
			E.nro_documento			AS [NroDocumento],
			E.sexo,
			E.estado
		FROM tb_empleado AS E
		INNER JOIN tb_area_trabajo		AS T	ON (T.id = E.id_area_trabajo)
		INNER JOIN tb_pais				AS P	ON (P.id = E.id_pais_nacimiento)
		INNER JOIN tb_tipo_documento	AS TD	ON (TD.id = E.id_tipo_documento)
		WHERE E.estado = IIF(@estado = -1, E.estado, @estado);
	END;

	-- INSERTAR
	IF @pOpcion = 1
	BEGIN 
		INSERT INTO tb_empleado 
		(nombres, apellidos, codigo_telefono, telefono, correo, fecha_nacimiento, sueldo, estado_civil, id_area_trabajo, id_pais_nacimiento, id_tipo_documento, nro_documento, sexo)
		VALUES 
		(@nombres, @apellidos, @codigoTelefono, @telefono, @correo, @fechaNacimiento, @sueldo, @estadoCivil, @idAreaTrabajo, @idPaisNacimiento, @idTipoDocumento, @nroDocumento, @sexo);

		SELECT SCOPE_IDENTITY();
	END;

	-- ACTUALIZAR
	IF @pOpcion = 2
	BEGIN 
		UPDATE tb_empleado 
		SET 
			nombres				= @nombres, 
			apellidos			= @apellidos,
			codigo_telefono		= @codigoTelefono,
			telefono			= @telefono,
			correo				= @correo,
			fecha_nacimiento	= @fechaNacimiento,
			sueldo				= @sueldo,
			estado_civil		= @estadoCivil,
			id_area_trabajo		= @idAreaTrabajo,
			id_pais_nacimiento	= @idPaisNacimiento,
			id_tipo_documento	= @idTipoDocumento,
			nro_documento		= @nroDocumento,
			sexo				= @sexo,
			fecha_actualizacion = GETDATE()
		WHERE id = @idEmpleado;

		SELECT @@ROWCOUNT;
	END;

	-- ELIMINAR
	IF @pOpcion = 3
	BEGIN 
		UPDATE tb_empleado SET estado = @estado
		WHERE id = @idEmpleado;

		SELECT @@ROWCOUNT;
	END;
END;