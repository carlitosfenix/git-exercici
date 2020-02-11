select e.nom as Empleado, c.nom As Cliente , f.id NumFactura,
 d.id as LinFac, up.id as UP,u.marca, model, p.nom
 from factures f
	join clients c  on  f.idCliente = c.id
	join empleats e on e.id = f.idEmpleat
	join detallfactura d on f.id = d.idFacture
	join ullereproveidor up on d.idUllereProveidor = up.id
	join ulleres u on u.id = up.idUlleres
	join proveidors p on up.idProveidor = p.id;