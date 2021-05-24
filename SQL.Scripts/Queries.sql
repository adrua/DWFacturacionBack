-- Obtener la lista de precios de todos los productos 
select ProductoLinea, ProductoDescripcion, ProductoPrecio 
from inv.productos
go
--Obtener la lista de productos cuya existencia en el inventario haya llegado al 
--mínimo permitido (5 unidades) 

select * 
from inv.productos
where ProductoSaldo <= ProductocantidadMinima
and ProductoControlSaldo = 1
go
-- Obtener una lista de clientes no mayores de 35 años que hayan realizado compras entre 
--el 1 de febrero de 2000 y el 25 de mayo de 2000 
select *
from cnt.Clientes as c
where  EXISTS (select * from cnt.Facturas as f where c.ClienteId = f.ClienteId and f.FacturaFecha between '2000-02-01' and '2000-05-25' ) 
and c.ClienteTipoID >= 1
and c.ClienteEdad <= 35 
--Obtener el valor total vendido por cada producto en el año 2000 
select ProductoLinea, ProductoDescripcion, 
			(select sum(fm.FacturaMovimientoTotal) 
				from cnt.FacturaMovimientos as fm ,
					cnt.Facturas as f
				where fm.ProductoLinea = p.ProductoLinea
					and fm.FacturaId = f.FacturaId
					and year(f.FacturaFecha) = 2000) as ventas
from inv.productos as p

--Obtener la última fecha de compra de un cliente y según su frecuencia de compra 
--estimar en qué fecha podría volver a comprar.
select c.ClienteId, c.ClienteRazonSocial, v.LastSale, DateAdd(Day, DateDiff(day, V.LastSale, v.FirstSale), v.LastSale) as NextSale
from cnt.Clientes as c, 
	 (select f.ClienteId, 
			min(f.FacturaFecha) as FirstSale,  
			max(f.FacturaFecha) as LastSale
		from cnt.Facturas as f
		group by f.ClienteId) as v
where c.ClienteId = v.ClienteId 