using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de ProductoModel
/// </summary>
public class ProductoModel
{
    public string InsertarProducto(Producto producto)
    {
        try
        {
            AjedrezDBEntities db = new AjedrezDBEntities();
            db.Productoes.Add(producto);
            db.SaveChanges();

            return producto.Nombre + "fue insertado exitosamente";
        }
        catch (Exception e)
        {
            return "Error:" + e;
        }
    }
    public string ActualizarProducto(int id, Producto producto)
    {
        try
        {
            AjedrezDBEntities db = new AjedrezDBEntities();

            //recuperar objeto desde la bd
            Producto p = db.Productoes.Find(id);

            p.Nombre = producto.Nombre;
            p.Precio = producto.Precio;
            p.TipoId = producto.TipoId;
            p.Descripcion = producto.Descripcion;
            p.Image = producto.Image;

            db.SaveChanges();
            return producto.Nombre + "fue actualizado exitosamente";
        }
        catch (Exception e)
        {
            return "Error:" + e;
        }
    }
    public string EliminarProducto(int id)
    {
        try
        {
            AjedrezDBEntities db = new AjedrezDBEntities();
            Producto producto = db.Productoes.Find(id);

            db.Productoes.Attach(producto);
            db.Productoes.Remove(producto);
            db.SaveChanges();

            return producto.Nombre + "fue eliminado exitosamente";

        }
        catch (Exception e)
        {
            return "Error:" + e;
        }
    }

    public Producto GetProducto(int id)
    {
        try
        {
            using (AjedrezDBEntities db = new AjedrezDBEntities())
            {
                Producto producto = db.Productoes.Find(id);
                return producto;
            }

        }
        catch(Exception)
        {
            return null;
        }
    }

    public List<Producto> GetAllProductos()
    {
        try
        {
            using (AjedrezDBEntities db = new AjedrezDBEntities())
            {
                List<Producto> productos = (from x in db.Productoes select x).ToList();
                return productos;
            }
        }
        catch(Exception)
        {
            return null;
        }
    }

    public List<Producto> GetProductoPorTipo(int tipoId)
    {
        try
        {
            using (AjedrezDBEntities db = new AjedrezDBEntities())
            {
                List<Producto> productos = (from x in db.Productoes where x.TipoId == tipoId select x).ToList();
                return productos;
            }
        }
        catch (Exception)
        {
            return null;
        }
    }
}