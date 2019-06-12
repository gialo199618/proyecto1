using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;

public partial class Paginas_Producto : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LlenarPagina();
    }

    protected void btnEnviar_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(Request.QueryString["id"]))
        {
            string clienteId = Context.User.Identity.GetUserId();

            if (clienteId != null)
            {
                int id = Convert.ToInt32(Request.QueryString["id"]);
                int cantidad = Convert.ToInt32(ddlCantidad.SelectedValue);

                Carrito carrito = new Carrito
                {
                    Cantidad = cantidad,
                    ClienteId = clienteId,
                    FechaCompra = DateTime.Now,
                    IsInCart = true,
                    ProductoId = id
                };

                CarritoModel model = new CarritoModel();
                lblResultado.Text = model.InsertarCarrito(carrito);
            }
            else
            {
                lblResultado.Text = "por favor inicie sesión para ordenar los artículos"; 
            }
        }
    }

    private void LlenarPagina()
    {
        //Obtener datos del producto seleccionado
        if(!String.IsNullOrWhiteSpace(Request.QueryString["id"]))
        {
            int id = Convert.ToInt32(Request.QueryString["id"]);
            ProductoModel productoModel = new ProductoModel();
            Producto producto = productoModel.GetProducto(id);

            //llenar página con datos
            lblPrecio.Text = "Precio por unidad: <br/>S/." + producto.Precio;
            lblTitulo.Text = producto.Nombre;
            lblDescripcion.Text = producto.Descripcion;
            lblNrItem.Text = id.ToString();
            imgProducto.ImageUrl = "~/Imagenes/Productos/" + producto.Image;

            //LLENAR LA LISTA DE SALIDA DE CANTIDAD DEL 1 - 20
            int[] cantidad = Enumerable.Range(1, 20).ToArray();
            ddlCantidad.DataSource = cantidad;
            ddlCantidad.AppendDataBoundItems = true;
            ddlCantidad.DataBind();
        }
    }

    
}