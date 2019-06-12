using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

public partial class Paginas_Cuenta_Registro : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        UserStore<IdentityUser> userStore = new UserStore<IdentityUser>();

        userStore.Context.Database.Connection.ConnectionString =
         System.Configuration.ConfigurationManager.ConnectionStrings["AjedrezDBConnectionString"].ConnectionString;

        UserManager<IdentityUser> manager = new UserManager<IdentityUser>(userStore);

        //Crea un nuevo usuario y trata de almacenar en la BD
        IdentityUser user = new IdentityUser();
        user.UserName = txtUsuario.Text;

        if(txtContraseña.Text == txtConfirma.Text)
        {
            try
            {
                //crear objeto usuario
                //se creará la base de datos / expandir automáticamente
                IdentityResult result = manager.Create(user, txtContraseña.Text);

                if (result.Succeeded)
                {
                    InformacionUsuario info = new InformacionUsuario
                    {
                        Nombre = txtNombres.Text,
                        ApePaterno = txtApePaterno.Text,
                        ApeMaterno = txtApeMaterno.Text,
                        Direccion = txtDireccion.Text,
                        CodigoPostal = Convert.ToInt32(txtCodigoPostal.Text),
                        GUId = user.Id
                    };

                    UsuarioInfoModel model = new UsuarioInfoModel();
                    model.InsertarInformacionUsuario(info);

                    //almacenar usuario en BD
                    var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;

                    //configurado para iniciar sesión nuevo usuario por cookie
                    var userIdentity = manager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);

                    //inicia sesion el nuevo usuario y redirigirlo a la página de inicio
                    authenticationManager.SignIn(new AuthenticationProperties(), userIdentity);
                    Response.Redirect("~/Index.aspx");
                }
            }
            catch (Exception ex)
            {
                litStatus.Text = ex.ToString();
            }
        }
        else
        {
            litStatus.Text = "No coinciden";
        }
    }
}