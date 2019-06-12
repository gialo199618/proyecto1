using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Collections;

public partial class Paginas_Administracion_AdministracionNoticia : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GetImagenes();

            //comprueba si la url contiene un parámetro id
            if (!String.IsNullOrWhiteSpace(Request.QueryString["id"]))
            {
                int id = Convert.ToInt32(Request.QueryString["id"]);
                LlenarPagina(id);
            }
        }
    }

    protected void btnEnviar_Click(object sender, EventArgs e)
    {
        NoticiaModel noticiaModel = new NoticiaModel();
        Noticia noticia = createNoticia();

        //comprueba si la url contiene un parámetro id
        if (!String.IsNullOrWhiteSpace(Request.QueryString["id"]))
        {
            //si Id existe se actualiza la fila existente
            int id = Convert.ToInt32(Request.QueryString["id"]);
            lblResultado.Text = noticiaModel.ActualizarNoticia(id, noticia);
        }
        else
        {
            //si Id no existe se crea una nueva fila
            lblResultado.Text = noticiaModel.InsertarNoticia(noticia);
        }
    }

    private void LlenarPagina(int id)
    {
        //obtener producto seleccionado de la bd
        NoticiaModel noticiaModel = new NoticiaModel();
        Noticia noticia = noticiaModel.GetNoticia(id);

        //llenar cuadro de textos
        txtTitulo.Text = noticia.Titulo;
        txtDescripcion.Text = noticia.Descripcion;
        

        

        //establecer el valor de la lista desplegable
        ddlImagen.SelectedValue = noticia.Imagen;
        
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

   
    private Noticia createNoticia()
    {
        Noticia noticia = new Noticia();

        
        noticia.Titulo = txtTitulo.Text;
        noticia.Descripcion = txtDescripcion.Text;
        noticia.FechaPublicacion = DateTime.Parse(cFecha.SelectedDate.ToShortDateString().ToString());
        noticia.Imagen = ddlImagen.SelectedValue;

        return noticia;
    }

    
}