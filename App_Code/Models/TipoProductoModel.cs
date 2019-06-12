using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de TipoTipoProductoModel
/// </summary>
public class TipoProductoModel
{
    public string InsertarTipoProducto(TipoProducto tipoProducto)
    {
        try
        {
            AjedrezDBEntities db = new AjedrezDBEntities();
            db.TipoProductoes.Add(tipoProducto);
            db.SaveChanges();

            return tipoProducto.Nombre + "fue insertado exitosamente";
        }
        catch (Exception e)
        {
            return "Error:" + e;
        }
    }
    public string ActualizarTipoProducto(int id, TipoProducto tipoProducto)
    {
        try
        {
            AjedrezDBEntities db = new AjedrezDBEntities();

            //recuperar objeto desde la bd
            TipoProducto p = db.TipoProductoes.Find(id);

            p.Nombre = tipoProducto.Nombre;
            

            db.SaveChanges();
            return tipoProducto.Nombre + "fue actualizado exitosamente";
        }
        catch (Exception e)
        {
            return "Error:" + e;
        }
    }
    public string EliminarTipoProducto(int id)
    {
        try
        {
            AjedrezDBEntities db = new AjedrezDBEntities();
            TipoProducto tipoProducto = db.TipoProductoes.Find(id);

            db.TipoProductoes.Attach(tipoProducto);
            db.TipoProductoes.Remove(tipoProducto);
            db.SaveChanges();

            return tipoProducto.Nombre + "fue eliminado exitosamente";

        }
        catch (Exception e)
        {
            return "Error:" + e;
        }
    }
}