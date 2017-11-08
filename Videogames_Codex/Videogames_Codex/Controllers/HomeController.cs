using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Videogames_Codex.Models;

namespace Videogames_Codex.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            List<Videogames> videogames = Videogames.SelectAll();
            return View(videogames);
        }

        public ActionResult Ver(int id)
        {
            Videogames videogame = Videogames.Get(id);
            if (videogame != null)
            {
                return View(videogame);
            }
            else
            {
                return Redirect("~/");
            }
        }

        public ActionResult Crear()
        {
            Videogames videogame = new Videogames();
            return View("~/Views/Home/Formulario.cshtml", videogame);
        }

        public ActionResult Modificar(int id)
        {
            Videogames videogame = Videogames.Get(id);
            if (videogame == null)
            {
                return Redirect("~/");
            }
            return View("~/Views/Home/Formulario.cshtml", videogame);
        }

        public ActionResult Guardar(Videogames videogame)
        {
            videogame.Save();
            return Redirect("~/");
        }

        public ActionResult Borrar(int id = 0)
        {
            Videogames videogame = Videogames.Get(id);
            if (videogame != null)
            {
                videogame.Delete();
            }
            return Redirect("~/");
        }

    }
}