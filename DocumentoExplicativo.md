# CentroEventos-

En la primer depuracion del proyecto se deberian de dar de alta las personas que estan declaradas en el programa, eventos y reservas.
Contienen:

	-5 personas
	-2 eventos
	-2 reservas

Tiene que devolver exactamente esto:
---------------Comienzo del programa --------------- 
 Persona VIP dada de alta correctamente:
 Id: 1, Dni: 00000001, Nombre: Profe, Apellido: Sores, Email: profes.net@gmail.com, Telefono: 221-000-0001
 Persona 1 dada de alta correctamente:
 Id: 2, Dni: 11111111, Nombre: Juan, Apellido: Perez, Email: juanperez@gmail.com, Telefono: 221-111-1111
 Persona 2 dada de alta correctamente:
 Id: 3, Dni: 22222222, Nombre: Emanuel, Apellido: Perez, Email: emanuelperez@gmail.com, Telefono: 221-222-2222
 Persona 3 dada de alta correctamente:
 Id: 3, Dni: 22222222, Nombre: Emanuel, Apellido: Perez, Email: emanuelperez@gmail.com, Telefono: 221-222-2222
 Persona 4 dada de alta correctamente:
 Id: 3, Dni: 22222222, Nombre: Emanuel, Apellido: Perez, Email: emanuelperez@gmail.com, Telefono: 221-222-2222
 Evento dado de alta correctamente:
 Id: 1, Nombre: Torneo de Fútbol, Descripcion: Cancha 1, FechaHoraInicio: 15/6/2025 18:30:00, DuracionHoras: 2, CupoMaximo: 20, ResponsableId: 1
 Evento dado de alta correctamente:
 Id: 2, Nombre: Torneo de Basquet, Descripcion: Cancha Principal, FechaHoraInicio: 6/6/2025 21:45:00, DuracionHoras: 2,5, CupoMaximo: 30, ResponsableId: 2
 Reserva realizada con éxito:Id: 1, Id persona: 1, Id evento deportivo: 1, Fecha de alta de la reserva: 22/5/2025 07:50:47, Estado asistencia: Pendiente   
 Reserva realizada con éxito:Id: 2, Id persona: 4, Id evento deportivo: 2, Fecha de alta de la reserva: 22/5/2025 07:50:47, Estado asistencia: Pendiente   

 Error al modificar la persona: No se encontró la entidad Persona con ID 10.

 Error al eliminar persona Id=20: No se encontró la entidad Persona con ID 20.

 No se encontró el evento: No se encontró la entidad Evento con ID 20.

 Error inesperado: No se encontró la entidad Evento con ID 10.

 No se encontró la reserva: No se encontró la entidad Reserva con ID 5.

 No se encontró la reserva: No se encontró la entidad Reserva con ID 10.

=== Listado de Personas ===
 Id: 1, Dni: 00000001, Nombre: Profe, Apellido: Sores, Email: profes.net@gmail.com, Telefono: 221-000-0001
 Id: 2, Dni: 11111111, Nombre: Juan, Apellido: Perez, Email: juanperez@gmail.com, Telefono: 221-111-1111
 Id: 3, Dni: 22222222, Nombre: Emanuel, Apellido: Perez, Email: emanuelperez@gmail.com, Telefono: 221-222-2222
 Id: 4, Dni: 33333333, Nombre: Lautaro, Apellido: Martinez, Email: lautaro@hotmail.com, Telefono: 221-333-3333
 Id: 5, Dni: 44444444, Nombre: Maria, Apellido: Gomez, Email: maria@gmail.com, Telefono: 221-444-5555

=== Listado de Eventos Deportivos ===
Id: 1, Nombre: Torneo de Fútbol, Descripcion: Cancha 1, FechaHoraInicio: 15/6/2025 18:30:00, DuracionHoras: 2, CupoMaximo: 20, ResponsableId: 1
Id: 2, Nombre: Torneo de Basquet, Descripcion: Cancha Principal, FechaHoraInicio: 6/6/2025 21:45:00, DuracionHoras: 2,5, CupoMaximo: 30, ResponsableId: 2

=== Listado de Reservas ===
Id: 1, Id persona: 1, Id evento deportivo: 1, Fecha de alta de la reserva: 22/5/2025 07:50:47, Estado asistencia: Pendiente
Id: 2, Id persona: 4, Id evento deportivo: 2, Fecha de alta de la reserva: 22/5/2025 07:50:47, Estado asistencia: Pendiente

----------Fin del programa----------

Luego de haber depurado y haber dado de alta las entidades que utilizaremos podemos probar lo siguiente en la proxima depuracion:

*PersonaModificacionUseCase
	-No se va a poder modificar la persona porque esta puesto un id que no existe(para que esto funcione cambiar el id por uno existente en la proxima vez que se depure el programa.. por ejemplo usar el id 1, 2, 3...5)
	Ahi se podra apreciar el caso de uso de PersonaModificacionUseCase
	
*PersonaBajaUseCase
	-No se va a poder eliminar la persona porque esta puesto un id que no existe(para que esto suceda antes de depurar por 2da vez el programa cambiar el id por uno que exista para ver su funcion)

*EventoDeportivoModificacionUseCase
	-No se va a poder modificar el evento porque esta puesto un id que no existe(para que esto suceda antes de depurar por 2da vez el programa cambiar el id por uno que exista para ver su funcion)

*EventoDeportivoBajaUseCase
	-No se va a poder eliminar el evento porque esta puesto un id que no existe(para que esto funcione cambiar el id por uno existente en la proxima vez que se depure el programa)

*ReservaBajaUseCase 
	-No se va a poder eliminar la reserva porque esta puesto un id que no existe(para que esto funcione cambiar el id por uno existente en la proxima vez que se depure el programa)

*ReservaModificacionUseCase
	-No se va a poder modificar la reserva porque esta puesto un id que no existe(para que esto suceda antes de depurar por 2da vez el programa cambiar el id por uno que exista para ver su funcion)

Al aplicar los casos de usos veremos como se modifican los datos que estamos usando.


// problemas
	cuando agregamos eventos al escribir los archivos y poner el StreamWriter (_archivoEventos,true) nos guarda los datos y agrega el evento correctamente, el problema es que cuando depuramos devuelta, sigue agregando esos mismos eventos, y si ponemos el StreamWriter en false solo guarda el ultimo evento
