using System;
using CentroEventos.Aplicacion.Entidades;

namespace CentroEventos.Aplicacion.Interfaces;

public interface IRepositorioUsuario
{
    void Agregar(Usuario usuario);
    void Modificar(Usuario usuario);
    Usuario? BuscarPorId(int id);
    Usuario? BuscarPorEmail(string email);
    List<Usuario> Listar();
    void Eliminar(int id);
    int CantidadUsuarios();  
}
