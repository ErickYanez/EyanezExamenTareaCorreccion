using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class LibroController : Controller
    {
        // GET: Libro
        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Result result = BL.Libro.GetAllEF();
            ML.Libro libro = new ML.Libro();

            if (result.Correct)
            {
                libro.Libros = result.Objects;
            }
            else
            {
                ViewBag.Message = "Ocurrio un error al realizar la consulta";
            }
            return View(libro);
        }


        [HttpGet]
        public ActionResult Form(int? IdLibro)
        {
            ML.Libro libro = new ML.Libro();
            ML.Result resultEditoriales = BL.Editorial.GetAll();
            ML.Result resultAutores = BL.Autor.GetAll();
            ML.Result resultGeneros = BL.Genero.GetAll();

            libro.Autor = new ML.Autor();
            libro.Editorial = new ML.Editorial();
            libro.Genero = new ML.Genero();

            if (IdLibro == null)
            {

                libro.Autor.Autores = resultAutores.Objects;
                libro.Editorial.Editoriales = resultEditoriales.Objects;
                libro.Genero.Generos = resultGeneros.Objects;

                return View(libro);
            }
            else
            {
                ML.Result result = BL.Libro.GetByIdEF(IdLibro.Value);
                if (result.Correct)
                {
                    libro = (ML.Libro)result.Object;
                    libro.Autor.Autores = resultAutores.Objects;
                    libro.Editorial.Editoriales = resultEditoriales.Objects;
                    libro.Genero.Generos = resultGeneros.Objects;
                    return View(libro);
                }
                else
                {
                    ViewBag.Message = "Ocurrio un error al buscar el libro";
                }
                return View(libro);
            }
        }

        [HttpPost]
        public ActionResult Form(ML.Libro libro)
        {
            if (libro.IdLibro == 0)
            {
                ML.Result result = BL.Libro.AddEF(libro);
                if (result.Correct)
                {
                    ViewBag.Message = result.Message;
                }
                else
                {
                    ViewBag.Message = "Error: " + result.Message;
                }
            }
            else
            {
                //UPDATE
                if (libro != null)
                {
                    ML.Result result = BL.Libro.UpdateEF(libro);
                    if (result.Correct)
                    {
                        ViewBag.Message = result.Message;
                    }
                    else
                    {
                        ViewBag.Message = "Error: " + result.Message;
                    }
                }
            }
            return PartialView("Modal");          
        }

        public ActionResult Delete(int? IdLibro)
        {
            ML.Libro libro = new ML.Libro();
            if (libro != null)
            {

                ML.Result result = BL.Libro.DeleteEF(IdLibro.Value);
                if (result.Correct)
                {
                    ViewBag.Message = result.Message;
                }
                else
                {
                    ViewBag.Message = "Error: " + result.Message;
                }
            }
            else
            {
                return Redirect("/Libro/GetAll");
            }
            return PartialView("Modal");
        }
    }
}