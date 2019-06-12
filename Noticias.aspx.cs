using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Noticias : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LlenarPagina();
    }

    private void LlenarPagina()
    {
        //obtener una lista de todos los productos en la BD
        NoticiaModel noticiaModel = new NoticiaModel();
        List<Noticia> noticias = noticiaModel.GetAllNoticias();

        //asegurarse de que los productos existen en la base de datos
        if (noticias != null)
        {
            //cree un nuevo panel con un botón de imagen y dos etiquetas para cada producto
            foreach (Noticia noticia in noticias)
            {
                Panel productoPanel = new Panel();
                ImageButton imageButton = new ImageButton();
                Label lblTitulo = new Label();
                

                //establecer propiedades de controles secundarios
                imageButton.ImageUrl = "~/Imagenes/Productos/" + noticia.Imagen;
                imageButton.CssClass = "productoImagen";


                lblTitulo.Text = noticia.Titulo;
                lblTitulo.CssClass = "productoNombre";

                

                //agregar controles secundarios al panel
                productoPanel.Controls.Add(imageButton);
                productoPanel.Controls.Add(new Literal { Text = "<br />" });
                productoPanel.Controls.Add(lblTitulo);
                productoPanel.Controls.Add(new Literal { Text = "<br />" });
                

                //agregar panel dinámico al panel principal estático
                pnlNoticias.Controls.Add(productoPanel);
            }
        }
        else
        {
            //no se encontraron productos
            pnlNoticias.Controls.Add(new Literal { Text = "no se encontraron noticias" });
        }
    }
}