using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Paginas_Cuenta_Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnIniciar_Click(object sender, EventArgs e)
    {
        UserStore<IdentityUser> userStore = new UserStore<IdentityUser>();

        userStore.Context.Database.Connection.ConnectionString =
         System.Configuration.ConfigurationManager.ConnectionStrings["AjedrezDBConnectionString"].ConnectionString;

        UserManager<IdentityUser> manager = new UserManager<IdentityUser>(userStore);

        var user = manager.Find(txtUsuario.Text, txtContraseña.Text);

        if(user != null)
        {
            //llamar a la funcionalidad OWIN
            var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
            var userIdentity = manager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);

            //iniciar sesión usuario
            authenticationManager.SignIn(new AuthenticationProperties
            {
                IsPersistent = false
            }, userIdentity);

            //redirigir al usuario a la página de inicio
            Response.Redirect("~/Index.aspx");
        }
        else
        {
            litStatus.Text = "usuario o contraseña invalido";
        }
    }
}