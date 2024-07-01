CREATE PROCEDURE USP_BUSQUEDA_INVENTARIO
@fechaInicio datetime =null,
@fechafin datetime= null,
@tipoMovimiento varchar(50) =null,
@numeroDocumento varchar(50) = null
AS
BEGIN
	
	set @tipoMovimiento =CASE WHEN @tipoMovimiento ='' THEN NULL ELSE @tipoMovimiento END
	set @numeroDocumento =CASE WHEN @numeroDocumento ='' THEN NULL ELSE @numeroDocumento END


	SELECT *
	FROM MOV_INVENTARIO
	WHERE
	(@fechaInicio IS NULL OR CONVERT(DATE, [FECHA_TRANSACCION],103)>=@fechaInicio)
	AND (@fechafin is null or CONVERT(DATE, [FECHA_TRANSACCION],103) <=@fechafin)
	AND (@tipoMovimiento is null or [TIPO_MOVIMIENTO] = @tipoMovimiento)
	AND (@numeroDocumento is null or  [NRO_DOCUMENTO]= @numeroDocumento)

END
GO

CREATE  PROCEDURE USP_REGISTRAR_MOVIMIENTOS
    @codCia VARCHAR(50),
    @companiaVenta VARCHAR(50),
    @almacenVenta VARCHAR(50),
    @tipoMovimiento VARCHAR(50),
    @tipoDocumento VARCHAR(50),
    @nroDocumento VARCHAR(50),
    @codItem VARCHAR(50),
    @proveedor VARCHAR(50),
    @almacenDestino VARCHAR(50),
    @cantidad VARCHAR(50)
AS
BEGIN
    INSERT INTO MOV_INVENTARIO (COD_CIA, COMPANIA_VENTA_3, ALMACEN_VENTA, TIPO_MOVIMIENTO, TIPO_DOCUMENTO, NRO_DOCUMENTO, COD_ITEM_2, PROVEEDOR, ALMACEN_DESTINO, CANTIDAD, FECHA_TRANSACCION)
    VALUES (@codCia, @companiaVenta, @almacenVenta, @tipoMovimiento, @tipoDocumento, @nroDocumento, @codItem, @proveedor, @almacenDestino, @cantidad, CONVERT(DATE,GETDATE(),103))
END
GO




