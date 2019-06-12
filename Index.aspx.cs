using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LlenarPagina();
    }

    private void LlenarPagina()
    {
        //obtener una lista de todos los productos en la BD
        ProductoModel productoModel = new ProductoModel();
        List<Producto> productos = productoModel.GetAllProductos();

        //asegurarse de que los productos existen en la base de datos
        if(productos != null)
        {
            //cree un nuevo panel con un botón de imagen y dos etiquetas para cada producto
            foreach(Producto producto in productos)
            {
                Panel productoPanel = new Panel();
                ImageButton imageButton = new ImageButton();
                Label lblNombre = new Label();
                Label lblPrecio = new Label();

                //establecer propiedades de controles secundarios
                imageButton.ImageUrl = "~/Imagenes/Productos/" + producto.Image;
                imageButton.CssClass = "productoImagen";
                imageButton.PostBackUrl = "~/Paginas/Producto.aspx?id=" + producto.Id;

                lblNombre.Text = producto.Nombre;
                lblNombre.CssClass = "productoNombre";

                lblPrecio.Text = "S/. " + producto.Precio;
                lblPrecio.CssClass = "productoPrecio";

                //agregar controles secundarios al panel
                productoPanel.Controls.Add(imageButton);
                productoPanel.Controls.Add(new Literal {Text = "<br />"});
                productoPanel.Controls.Add(lblNombre);
                productoPanel.Controls.Add(new Literal { Text = "<br />" });
                productoPanel.Controls.Add(lblPrecio);

                //agregar panel dinámico al panel principal estático
                pnlProductos.Controls.Add(productoPanel);
            }
        }
        else
        {
            //no se encontraron productos
            pnlProductos.Controls.Add(new Literal { Text = "no se encontraron productos"});
        }
    }
}