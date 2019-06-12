using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de NoticiaModel
/// </summary>
public class NoticiaModel
{
    public string InsertarNoticia(Noticia noticia)
    {
        try
        {
            AjedrezDBEntities db = new AjedrezDBEntities();
            db.Noticias.Add(noticia);
            db.SaveChanges();

            return noticia.Titulo + " fue insertado exitosamente";
        }
        catch (Exception e)
        {
            return "Error:" + e;
        }
    }
    public string ActualizarNoticia(int id, Noticia noticia)
    {
        try
        {
            AjedrezDBEntities db = new AjedrezDBEntities();

            //recuperar objeto desde la bd
            Noticia n = db.Noticias.Find(id);

            n.Titulo = noticia.Titulo;
            n.Descripcion = noticia.Descripcion;
            n.FechaPublicacion = noticia.FechaPublicacion;
            n.Imagen = noticia.Imagen;

            db.SaveChanges();
            return noticia.Titulo + " fue actualizado exitosamente";
        }
        catch (Exception e)
        {
            return "Error:" + e;
        }
    }
    public string EliminarNoticia(int id)
    {
        try
        {
            AjedrezDBEntities db = new AjedrezDBEntities();
            Noticia noticia = db.Noticias.Find(id);

            db.Noticias.Attach(noticia);
            db.Noticias.Remove(noticia);
            db.SaveChanges();

            return noticia.Titulo + " fue eliminado exitosamente";

        }
        catch (Exception e)
        {
            return "Error:" + e;
        }
    }

    public Noticia GetNoticia(int id)
    {
        try
        {
            using (AjedrezDBEntities db = new AjedrezDBEntities())
            {
                Noticia noticia = db.Noticias.Find(id);
                return noticia;
            }

        }
        catch (Exception)
        {
            return null;
        }
    }

    public List<Noticia> GetAllNoticias()
    {
        try
        {
            using (AjedrezDBEntities db = new AjedrezDBEntities())
            {
                List<Noticia> noticias = (from x in db.Noticias select x).ToList();
                return noticias;
            }
        }
        catch (Exception)
        {
            return null;
        }
    }
}