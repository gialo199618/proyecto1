using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Paginas_Administracion_AdministracionTipoProducto : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnEnviar_Click(object sender, EventArgs e)
    {
        TipoProductoModel model = new TipoProductoModel();
        TipoProducto pt = createTipoProducto();

        lblResultado.Text = model.InsertarTipoProducto(pt);
    }

    private TipoProducto createTipoProducto()
    {
        TipoProducto p = new TipoProducto();
        p.Nombre = txtNombre.Text;
        return p;
    }
}