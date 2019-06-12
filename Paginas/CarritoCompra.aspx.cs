using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;

public partial class Paginas_CarritoCompra : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //obtener identificación del usuario actual registrado y mostrar los artículos en el carrito
        string userId = User.Identity.GetUserId();
        GetComprasEnCarrito(userId);
    }

    private void GetComprasEnCarrito(string userId)
    {
        CarritoModel model = new CarritoModel();
        double subTotal = 0;

        //generar HTML para cada elemento en la lista de compras
        List<Carrito> ListaCompra = model.GetOrdersInCart(userId);
        CreateShopTable(ListaCompra, out subTotal);

        //agregar totales a la página web
        double igv = subTotal * 0.18;
        double Total = subTotal + igv + 1;

        //mostrar valores en la página
        litSubtotal.Text = "S/. " + subTotal;
        litIGV.Text = "S/. " + igv;
        litTotal.Text = "S/. " + Total;
    }

    private void CreateShopTable(List<Carrito> listaCompra, out double subTotal)
    {
        subTotal = new Double();
        ProductoModel model = new ProductoModel();

        foreach(Carrito carrito in listaCompra)
        {
            Producto producto = model.GetProducto(carrito.ProductoId);

            //crear el botón de imagen
            ImageButton btnImage = new ImageButton
            {
                ImageUrl = string.Format("~/Imagenes/Productos/{0}", producto.Image),
                PostBackUrl = string.Format("~/Paginas/Producto.aspx?id={0}", producto.Id)
            };

            //crear el enlace de eliminar
            LinkButton lnkEliminar = new LinkButton
            {
                PostBackUrl = string.Format("~/Paginas/CarritoCompra.aspx?productoId={0}", carrito.Id),
                Text = "Eliminar Item",
                ID = "del" + carrito.Id
            };

            //agregar evento onclick
            lnkEliminar.Click += Eliminar_Item;

            //crear la lista desplegable 'cantidad'
            //generar lista con los numeros del 1 al 20
            int[] cantidad = Enumerable.Range(1, 20).ToArray();

            DropDownList ddlCantidad = new DropDownList
            {
                DataSource = cantidad,
                AppendDataBoundItems = true,
                AutoPostBack = true,
                ID = carrito.Id.ToString()
            };

            ddlCantidad.DataBind();
            ddlCantidad.SelectedValue = carrito.Cantidad.ToString();
            ddlCantidad.SelectedIndexChanged += ddlCantidad_SelectedIndexChanged;

            //crear tabla HTML con 2 filas
            Table tabla = new Table { CssClass = "carritoTabla" };
            TableRow a = new TableRow();
            TableRow b = new TableRow();

            //crear 6 celdas para la fila a
            TableCell a1 = new TableCell { RowSpan = 2, Width = 50};
            TableCell a2 = new TableCell { Text = string.Format("<h4>{0}</h4><br/>{1}<br/>En Stock",
                producto.Nombre, "Item N°: " + producto.Id),
                HorizontalAlign = HorizontalAlign.Left, Width=350};
            TableCell a3 = new TableCell { Text = "Precio Unidad<hr/>"};
            TableCell a4 = new TableCell { Text = "Cantidad<hr/>" };
            TableCell a5 = new TableCell { Text = "Total Item<hr/>" };
            TableCell a6 = new TableCell { };

            //crear 6 celdas para la fila b
            TableCell b1 = new TableCell { };
            TableCell b2 = new TableCell { Text = "S/. " + producto.Precio};
            TableCell b3 = new TableCell { };
            TableCell b4 = new TableCell { Text = "S/. " + carrito.Cantidad * producto.Precio};
            TableCell b5 = new TableCell { };
            TableCell b6 = new TableCell { };

            //establecer controles especiales
            a1.Controls.Add(btnImage);
            a6.Controls.Add(lnkEliminar);
            b3.Controls.Add(ddlCantidad);

            //agregar celdas a las filas
            a.Cells.Add(a1);
            a.Cells.Add(a2);
            a.Cells.Add(a3);
            a.Cells.Add(a4);
            a.Cells.Add(a5);
            a.Cells.Add(a6);

            b.Cells.Add(b1);
            b.Cells.Add(b2);
            b.Cells.Add(b3);
            b.Cells.Add(b4);
            b.Cells.Add(b5);
            b.Cells.Add(b6);

            //agregar filas a tabla
            tabla.Rows.Add(a);
            tabla.Rows.Add(b);

            //agregar tabla al pnlCarritoCompra
            pnlCarritoCompra.Controls.Add(tabla);

            //agregar la cantidad total del artículo en el carrito al subtotal
            subTotal += Convert.ToDouble(carrito.Cantidad * producto.Precio);

            //add current user´s shopping cart to user specific session value
            Session[User.Identity.GetUserId()] = listaCompra;

        }
    }

    private void ddlCantidad_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList selectedList = (DropDownList)sender;
        int cantidad = Convert.ToInt32(selectedList.SelectedValue);
        int carritoId = Convert.ToInt32(selectedList.ID);

        CarritoModel model = new CarritoModel();
        model.ActualizarCantidad(carritoId, cantidad);

        Response.Redirect("~/Paginas/CarritoCompra.aspx");
    }

    private void Eliminar_Item(object sender, EventArgs e)
    {
        LinkButton selectedLink = (LinkButton)sender;
        string link = selectedLink.ID.Replace("del", "");
        int carritoId = Convert.ToInt32(link);

        CarritoModel model = new CarritoModel();
        model.EliminarCarrito(carritoId);

        Response.Redirect("~/Paginas/CarritoCompra.aspx");
    }
}