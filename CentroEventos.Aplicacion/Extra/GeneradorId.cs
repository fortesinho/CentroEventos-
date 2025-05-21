using System;

namespace CentroEventos.Aplicacion.Extra;

public static class GeneradorId
{
public static int Obtener(string dirUltId){
      int ultimoId = 0;
        if(File.Exists(dirUltId)){
            using var sr = new StreamReader(dirUltId);
            string? linea = sr.ReadLine();
            if (!string.IsNullOrWhiteSpace(linea))
               ultimoId = int.Parse(linea);
            }
        int nuevoId = ultimoId + 1;
        using var sw = new StreamWriter(dirUltId, false);
        sw.WriteLine(nuevoId);
    return nuevoId;
        }

}
