using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Paginas_Administracion_Administracion : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void grdProductos_RowEditing(object sender, GridViewEditEventArgs e)
    {
        //obtener fila seleccionada
        GridViewRow row = grdProductos.Rows[e.NewEditIndex];

        //obtener ID del producto seleccionado
        int rowId = Convert.ToInt32(row.Cells[1].Text);

        //redirigir al usuario para administrar los productos junto con el Id de fila seleccionado
        Response.Redirect("~/Paginas/Administracion/AdministracionProducto.aspx?id=" + rowId);
    }

    protected void grdNoticia_RowEditing(object sender, GridViewEditEventArgs e)
    {
        //obtener fila seleccionada
        GridViewRow row = grdNoticia.Rows[e.NewEditIndex];

        //obtener ID del producto seleccionado
        int rowId = Convert.ToInt32(row.Cells[1].Text);

        //redirigir al usuario para administrar los productos junto con el Id de fila seleccionado
        Response.Redirect("~/Paginas/Administracion/AdministracionNoticia.aspx?id=" + rowId);
    }
}