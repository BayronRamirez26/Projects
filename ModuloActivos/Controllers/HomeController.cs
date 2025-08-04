using IntranetFM;
using IntranetFM.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Text.Json;

namespace ModuloActivos.Controllers
{
    public class HomeController : Controller
    {


        public IActionResult checkAutenticationStatus(string controller, string action, HttpContext phttpContext)
        {
            var client = new HttpClient();

            IntranetFM.Class.Usuarioacceso macceso = new IntranetFM.Class.Usuarioacceso();

            string musuario = phttpContext.Session.GetString("muser");
            IntranetFM.Modelos.Usuario muser = null;
            if (musuario != null)
            {
                muser = JsonSerializer.Deserialize<IntranetFM.Modelos.Usuario>(musuario);
            }

            if (muser != null)
            {
                var muserMenu = phttpContext.Session.GetString("userMenu");
                //Utilitarios.WriteLog(new ApplicationLog { _user = muser._login, _action = "Entra en Inventario/Home/checkAutenticationStatus y musermenu tiene "+muserMenu });
                if (string.IsNullOrEmpty(muserMenu))
                {
                    int APPID = int.Parse(IntranetFM.Utilitarios.BuscarConfigLine("APP_ID"));

                    List<IntranetFM.Modelos.MenuItem> mlista = macceso.Listarmenu(muser, new IntranetFM.Modelos.Aplicacion { _rowid = APPID });

                    phttpContext.Session.SetString("userMenu", JsonSerializer.Serialize(mlista));

                }
                Utilitarios.WriteLog(new ApplicationLog { _user = muser._login, _action = "Entro en /Home/checkAutenticationStatus y redirecciona a "+controller+"/"+action + " y pasa checked" });
                return RedirectToAction(action, controller, new { pchecked = "checked" });
            }
            else
            {
                try
                {
                    /*
                    if (Request == null) {
                        return RedirectToAction("Index","Home");
                    }
                    */
                    string mauthenticatinoaddress = IntranetFM.Utilitarios.BuscarConfigLine("LGNURL");

                    string returnUrl = Url.Action("donext", "Home", null, Request.Scheme);
                    string authUrl = mauthenticatinoaddress + $"?returnUrl={Uri.EscapeDataString(returnUrl)}";

                    return Redirect(authUrl);
                }
                catch (System.NullReferenceException Exception)
                {
                    return RedirectToAction("Index", "Home");
                    //throw;
                }

            }
        }

        public IActionResult doindex()
        {
            
            var muserMenu = HttpContext.Session.GetString("userMenu");
            string musuario = HttpContext.Session.GetString("muser");
            //IntranetFM.Modelos.Usuario muser = JsonSerializer.Deserialize<IntranetFM.Modelos.Usuario>(musuario);

            //Utilitarios.WriteLog(new ApplicationLog { _user = muser._login, _action = "Entra en Activos/Home/doIndex ",_ipaddress=IntranetFM.Utilitarios.GetIPAddress(HttpContext) });

            if (!string.IsNullOrEmpty(muserMenu))
            {
                ViewBag.UserMenu = JsonSerializer.Deserialize<List<IntranetFM.Modelos.MenuItem>>(muserMenu);
                return View ("Index");
            }
            else
            {
                
                if (!string.IsNullOrEmpty(musuario))
                {
                    Utilitarios.WriteLog(new ApplicationLog { _user = "usuario autenticado", _action = "Entra en Activos/Home/doIndex y tampoco encuentra definido el usuario" });
                }

                return RedirectToAction("Index");
            }
        }

        public IActionResult Index()
        {
            PdfSharp.Fonts.GlobalFontSettings.FontResolver = new IntranetFM.FileFontResolver();

            //CreatePdfWithMultipleRowsAndColumns();


            /** Estas lineas son para que no pida la autentiación. **/
            string mdefuser = IntranetFM.Utilitarios.BuscarConfigLine("DEFUSR");
            if ( int.Parse("0"+mdefuser) > 0)
            {
                IntranetFM.Modelos.Usuario muser = new IntranetFM.Modelos.Usuario { _setid = int.Parse(mdefuser) };

                if (muser._rowid > 0)
                {
                    IntranetFM.Utilitarios.WriteLog(new ApplicationLog { _user = muser._login, _action = "Se autentica con usuario default", _ipaddress = IntranetFM.Utilitarios.GetIPAddress(HttpContext) });
                    HttpContext.Session.SetString("muser", JsonSerializer.Serialize(muser));
                }
            }

            return checkAutenticationStatus("Home", "doindex", HttpContext);
        }

        [HttpGet("/Home/donext/{ptoken}")]
        public IActionResult donext([FromRoute] string ptoken)
        {
            IntranetFM.Class.Tokens mcltoken = new IntranetFM.Class.Tokens();
            IntranetFM.Modelos.Usuario muser = mcltoken.getUserofToken(ptoken);
            HttpContext.Session.SetString("muser", JsonSerializer.Serialize(muser));

            Utilitarios.WriteLog(new ApplicationLog { _user = muser._login, _action = "Entra en Activos recibiendo el token de autenticación",_ipaddress= IntranetFM.Utilitarios.GetIPAddress(HttpContext) });

            return checkAutenticationStatus("Home", "doindex", HttpContext);
        }

        [HttpGet]
        public IActionResult RedirectHome()
        {
            string musuario = HttpContext.Session.GetString("muser");
            string murl = "";
            if (!string.IsNullOrEmpty(musuario))
            {
                HttpContext.Session.Remove("muser");
                HttpContext.Session.Remove("userMenu");

                IntranetFM.Modelos.Usuario muser = JsonSerializer.Deserialize<IntranetFM.Modelos.Usuario>(musuario);
                IntranetFM.Class.Tokens mcltonken = new IntranetFM.Class.Tokens();
                string mtoken = mcltonken.getTokenforUser(muser);
                if (!string.IsNullOrEmpty(mtoken))
                {
                    IntranetFM.Class.Aplicaciones mclapp = new IntranetFM.Class.Aplicaciones();
                    IntranetFM.Modelos.Aplicacion mapp = mclapp.Query(new IntranetFM.Modelos.Aplicacion { _rowid = 0, _home = "1" }).FirstOrDefault();
                    if (mapp != null)
                    {
                        murl = mapp._url + "/" + mtoken;
                    }
                }
            }

            //ViewBag.Home = "http://wwww.ucr.ac.cr";
            //return View( model: murl);
            return Redirect(murl);
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("muser");
            HttpContext.Session.Remove("userMenu");

            return RedirectToAction("Index");
        }

    }
}
