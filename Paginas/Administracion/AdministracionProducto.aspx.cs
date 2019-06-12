using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Collections;

public partial class Paginas_Administracion_AdministracionProducto : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GetImagenes();

            //comprueba si la url contiene un parámetro id
            if(!String.IsNullOrWhiteSpace(Request.QueryString["id"]))
            {
                int id = Convert.ToInt32(Request.QueryString["id"]);
                LlenarPagina(id);
            }
        }
    }

    protected void btnEnviar_Click(object sender, EventArgs e)
    {
        ProductoModel productoModel = new ProductoModel();
        Producto producto = createProducto();

        //comprueba si la url contiene un parámetro id
        if (!String.IsNullOrWhiteSpace(Request.QueryString["id"]))
        {
            //si Id existe se actualiza la fila existente
            int id = Convert.ToInt32(Request.QueryString["id"]);
            lblResultado.Text = productoModel.ActualizarProducto(id, producto);
        }
        else
        {
            //si Id no existe se crea una nueva fila
            lblResultado.Text = productoModel.InsertarProducto(producto);
        }    
    }

    private void LlenarPagina(int id)
    {
        //obtener producto seleccionado de la bd
        ProductoModel productoModel = new ProductoModel();
        Producto producto = productoModel.GetProducto(id);

        //llenar cuadro de textos
        txtDescripcion.Text = producto.Descripcion;
        txtNombre.Text = producto.Nombre;
        txtPrecio.Text = producto.Precio.ToString();

        //establecer el valor de la lista desplegable
        ddlImagen.SelectedValue = producto.Image;
        ddlTipo.SelectedValue = producto.TipoId.ToString();
    }

    private void GetImagenes()
    {
        try
        {
            //obtener todas las rutas de archivos
            string[] imagenes = Directory.GetFiles(Server.MapPath("~/Imagenes/Productos/"));

            //obtener todos los nombres de archivo y agregarlos a un arraylist
            ArrayList imagenList = new ArrayList();
            foreach (string imagen in imagenes)
            {
                string imagenNombre = imagen.Substring(imagen.LastIndexOf(@"\", StringComparison.Ordinal) + 1);
                imagenList.Add(imagenNombre);
            }

            //establecer el arraylist como fuente de datos de la vista desplegable y actualizar
            ddlImagen.DataSource = imagenList;
            ddlImagen.AppendDataBoundItems = true;
            ddlImagen.DataBind();

        }
        catch (Exception e)
        {
            lblResultado.Text = e.ToString();
        }
    }

    private Producto createProducto()
    {
        Producto producto = new Producto();

        producto.Nombre = txtNombre.Text;
        producto.Precio = Convert.ToInt32(txtPrecio.Text);
        producto.TipoId = Convert.ToInt32(ddlTipo.SelectedValue);
        producto.Descripcion = txtDescripcion.Text;
        producto.Image = ddlImagen.SelectedValue;

        return producto;
    }

   
}