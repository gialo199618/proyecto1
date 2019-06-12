using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de UsuarioInfoModel
/// </summary>
public class UsuarioInfoModel
{
    public InformacionUsuario GetInformacionUsuario(string guId)
    {
        AjedrezDBEntities db = new AjedrezDBEntities();
        InformacionUsuario info = (from x in db.InformacionUsuarios
                                   where x.GUId == guId
                                   select x).FirstOrDefault();
        return info;
    }

    public void InsertarInformacionUsuario(InformacionUsuario info)
    {
        AjedrezDBEntities db = new AjedrezDBEntities();
        db.InformacionUsuarios.Add(info);
        db.SaveChanges();
    }
}