using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System.Data;
using System.Security.Claims;

namespace TentativaFinal.Controllers
{
    public class Principal : Controller
    {
        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return Json(new { Msq = " Usuário Logado" });
            }
          return View();
          //  return RedirectToAction("Index", "Contatos");
        }
        [HttpPost]
        public async Task<IActionResult> Logar(string username, string senha)
        {
            //MySqlConnection mySqlConnector = new MySqlConnection("server=localhost;database=bdcontatos;uid=root;password=root");
            //await mySqlConnector.OpenAsync();
            //MySqlCommand mySqlCommand = mySqlConnector.CreateCommand();
            //mySqlCommand.CommandText = $"SELECT * FROM login WHERE nome='{username}'AND senha = '{senha}'";

            //MySqlDataReader lerDados = mySqlCommand.ExecuteReader();
           
            //if(await lerDados.ReadAsync())
            //{
            //    int usuarioId = lerDados.GetInt32(0);
            //    string nome = lerDados.GetString(1);
            //    int nivel = lerDados.GetInt32(3);
            //    List<Claim> direitosAcesso = new List<Claim>
            //    {
            //        new Claim(ClaimTypes.NameIdentifier, usuarioId.ToString()),
            //        new Claim(ClaimTypes.Name, nome),
                    
            //    };
            //    var identity = new ClaimsIdentity(direitosAcesso, "Identity.Login");
            //    var userPrinpal = new ClaimsPrincipal(new[] { identity });

            //    await HttpContext.SignInAsync(userPrinpal,
            //        new AuthenticationProperties
            //    {
            //        IsPersistent = false,
            //        ExpiresUtc = DateTime.Now.AddMinutes(5)
            //    });
            //    if (nivel == 1)
            //    {
            //        return RedirectToAction("Index", "Contatos");
            //    }
            //    else
            //    {
            //        return RedirectToAction("Index", "Lista");
            //    }
            //    //return Json(new { Msg = "Usuário Logado com sucesso !" });
              
            //}
            
            if(username=="Ednilson"& senha == "1234")
            {
                return RedirectToAction("Index", "Contatos");
            }
            else
            {
                return RedirectToAction("Index", "Lista");
            }
            return Json(new {Msg ="Usuário não encontrado !"});
        }
        public IActionResult PrincipalPagina()
        {
            return View();
        }
        
        public IActionResult Login()
        {
            return RedirectToAction("Areas/Identity/Pages/Account/Login");
            //return View();
        }
        public async Task<IActionResult> Logout()
        {
            if (User.Identity.IsAuthenticated)
            {
                await HttpContext.SignOutAsync();
            }
            return RedirectToAction("Index", "Principal");
        }
    }
}
