using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;

public partial class Paginas_Success : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //solo para verificar la compra
        List<Carrito> carritos = (List<Carrito>)Session[User.Identity.GetUserId()];

        CarritoModel model = new CarritoModel();
        model.MarcarOrdenesComoPagadas(carritos);

        Session[User.Identity.GetUserId()] = null;
    }
}