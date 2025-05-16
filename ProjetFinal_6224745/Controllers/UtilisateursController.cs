using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ProjetFinal_6224745.Data;
using ProjetFinal_6224745.Models;
using ProjetFinal_6224745.ViewModels;
using System.Security.Claims;

namespace ProjetFinal_6224745.Controllers
{
    public class UtilisateursController : Controller
    {
        readonly BdGymnastiqueContext _context;
        public UtilisateursController(BdGymnastiqueContext context)
        {
            _context = context;
        }
        public IActionResult Inscription()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Inscription(InscriptionViewModel ivm)
        {
            // Le pseudo est déjà pris ?
            bool existeDeja = await _context.Utilisateurs.AnyAsync(x => x.Pseudonyme == ivm.Pseudonyme);
            if (existeDeja)
            {
                ModelState.AddModelError("Pseudo", "Ce pseudonyme est déjà pris.");
                return View(ivm);
            }

            // On INSERT l'utilisateur avec une procédure stockée qui va s'occuper de
            // hacher le mot de passe, chiffrer la couleur ...
            string query = "EXEC Utilisateurs.USP_CreerUtilisateur @Pseudo, @MotDePasse, @Email";
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter{ParameterName = "@Pseudo", Value = ivm.Pseudonyme},
                new SqlParameter{ParameterName = "@MotDePasse", Value = ivm.MotDePasse},
                new SqlParameter{ParameterName = "@Email", Value = ivm.Email}
            };
            try
            {
                await _context.Database.ExecuteSqlRawAsync(query, parameters.ToArray());
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Une erreur est survenue. Veuillez réessayez.");
                return View(ivm);
            }
            return RedirectToAction("Connexion", "Utilisateurs");
        }

        [HttpPost]
        public async Task<IActionResult> Connexion(ConnexionViewModel cvm)
        {
            // Procédure stockée qui compare le mot de passe fourni à celui dans la BD
            // Retourne juste l'utilisateur si le mot de passe est valide
            string query = "EXEC Utilisateurs.USP_AuthUtilisateur @Pseudonyme, @MotDePasse";
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter{ParameterName = "@Pseudonyme", Value = cvm.Pseudonyme},
                new SqlParameter{ParameterName = "@MotDePasse", Value = cvm.MotDePasse}
            };
            Utilisateur? utilisateur = (await _context.Utilisateurs.FromSqlRaw(query, parameters.ToArray()).ToListAsync()).FirstOrDefault();
            if (utilisateur == null)
            {
                ModelState.AddModelError("", "Nom d'utilisateur ou mot de passe invalide");
                return View(cvm);
            }

            // Construction du cookie d'authentification 
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, utilisateur.UtilisateurId.ToString()),
                new Claim(ClaimTypes.Name, utilisateur.Pseudonyme)
            };

            ClaimsIdentity identite = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            ClaimsPrincipal principal = new ClaimsPrincipal(identite);

            // Cette ligne fournit le cookie à l'utilisateur
            await HttpContext.SignInAsync(principal);

            return RedirectToAction("Index", "Agres");
        }

        public IActionResult Connexion()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Deconnexion()
        {
            // Cette ligne mange le cookie 🍪 Slurp
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Agres");
        }
    }
}
