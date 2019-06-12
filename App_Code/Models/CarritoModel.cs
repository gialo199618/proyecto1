using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de CarritoModel
/// </summary>
public class CarritoModel
{
    public string InsertarCarrito(Carrito carrito)
    {
        try
        {
            AjedrezDBEntities db = new AjedrezDBEntities();
            db.Carritoes.Add(carrito);
            db.SaveChanges();

            return "La orden fue insertada exitosamente";
        }
        catch (Exception e)
        {
            return "Error:" + e;
        }
    }
    public string ActualizarCarrito(int id, Carrito carrito)
    {
        try
        {
            AjedrezDBEntities db = new AjedrezDBEntities();

            //recuperar objeto desde la bd
            Carrito p = db.Carritoes.Find(id);

            p.FechaCompra = carrito.FechaCompra;
            p.ClienteId = carrito.ClienteId;
            p.Cantidad = carrito.Cantidad;
            p.IsInCart = carrito.IsInCart;
            p.ProductoId = carrito.ProductoId;


            db.SaveChanges();
            return "fue actualizado exitosamente";
        }
        catch (Exception e)
        {
            return "Error:" + e;
        }
    }
    public string EliminarCarrito(int id)
    {
        try
        {
            AjedrezDBEntities db = new AjedrezDBEntities();
            Carrito carrito = db.Carritoes.Find(id);

            db.Carritoes.Attach(carrito);
            db.Carritoes.Remove(carrito);
            db.SaveChanges();

            return "fue eliminado exitosamente";

        }
        catch (Exception e)
        {
            return "Error:" + e;
        }
    }

    public List<Carrito> GetOrdersInCart(string userId)
    {
        AjedrezDBEntities db = new AjedrezDBEntities();
        List<Carrito> ordenes = (from x in db.Carritoes
                                 where x.ClienteId == userId
                                 && x.IsInCart
                                 orderby x.FechaCompra
                                 select x).ToList();
        return ordenes;
    }

    public int GetTotalPedidos(string userId)
    {
        try
        {
            AjedrezDBEntities db = new AjedrezDBEntities();
            int total = (from x in db.Carritoes
                         where x.ClienteId == userId
                         && x.IsInCart
                         select x.Cantidad).Sum();
            return total;
        }
        catch
        {
            return 0;
        }
    }

    public void ActualizarCantidad(int id, int cantidad)
    {
        AjedrezDBEntities db = new AjedrezDBEntities();
        Carrito carrito = db.Carritoes.Find(id);
        carrito.Cantidad = cantidad;

        db.SaveChanges();
    }

    public void MarcarOrdenesComoPagadas(List<Carrito> carritos)
    {
        AjedrezDBEntities db = new AjedrezDBEntities();

        if(carritos != null)
        {
            foreach(Carrito carrito in carritos) 
            {
                Carrito oldCarrito = db.Carritoes.Find(carrito.Id);
                oldCarrito.FechaCompra = DateTime.Now;
                oldCarrito.IsInCart = false;
            }
            db.SaveChanges();
        }
    }   
}