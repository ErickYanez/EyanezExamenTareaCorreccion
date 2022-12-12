using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    internal class Libro
    {
        public static void GetAll()
        {
            ML.Result result = BL.Libro.GetAll();
            if (result.Correct)
            {
                foreach (ML.Libro libro in result.Objects)
                {
                    Console.WriteLine("IdLibro: " + libro.IdLibro);
                    Console.WriteLine("Nombre: " + libro.Nombre);
                    Console.WriteLine("Autor: " + libro.Autor.NombreAutor);
                    Console.WriteLine("Numero Paginas: " + libro.NumeroPaginas);
                    Console.WriteLine("Fecha publicacion: " + libro.FechaPublicacion);
                    Console.WriteLine("Editorial: " + libro.Editorial.NombreEditorial);
                    Console.WriteLine("Edicion: " + libro.Edicion);
                    Console.WriteLine("Genero: " + libro.Genero.NombreGenero);
                    Console.WriteLine("****************************************");
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }
        public static void GetById()
        {
            ML.Libro libro = new ML.Libro();
            Console.WriteLine("Ingrese el id del libro a mostrar");
            libro.IdLibro = int.Parse(Console.ReadLine());
            ML.Result result = BL.Libro.GetById(libro.IdLibro);
            if (result.Correct)
            {
                libro = (ML.Libro)result.Object;

                Console.WriteLine("IdLibro: " + libro.IdLibro);
                Console.WriteLine("Nombre: " + libro.Nombre);
                Console.WriteLine("Autor: " + libro.Autor.NombreAutor);
                Console.WriteLine("Numero Paginas: " + libro.NumeroPaginas);
                Console.WriteLine("Fecha publicacion: " + libro.FechaPublicacion);
                Console.WriteLine("Editorial: " + libro.Editorial.NombreEditorial);
                Console.WriteLine("Edicion: " + libro.Edicion);
                Console.WriteLine("Genero: " + libro.Genero.NombreGenero);
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }
        public static void Add()
        {
            ML.Libro libro = new ML.Libro();
            libro.Autor = new ML.Autor();
            libro.Editorial = new ML.Editorial();
            libro.Genero = new ML.Genero();
            Console.WriteLine("Ingrese el nombre del libro");
            libro.Nombre = Console.ReadLine();
            Console.WriteLine("Ingrese el id del autor");
            libro.Autor.IdAutor = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese el numero de paginas");
            libro.NumeroPaginas = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese la fecha de publicacion (dd/mm/yyyy)");
            libro.FechaPublicacion = Console.ReadLine();
            Console.WriteLine("Ingrese el id de editorial");
            libro.Editorial.IdEditorial = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese la edicion");
            libro.Edicion = Console.ReadLine();
            Console.WriteLine("Ingrese el id de genero");
            libro.Genero.IdGenero = int.Parse(Console.ReadLine());
            ML.Result result = BL.Libro.Add(libro);
            if (result.Correct)
            {
                Console.WriteLine(result.Message);
            }
            else
            {
                Console.WriteLine(result.Message);
            }

        }
        public static void Update()
        {
            ML.Libro libro = new ML.Libro();
            libro.Autor = new ML.Autor();
            libro.Editorial = new ML.Editorial();
            libro.Genero = new ML.Genero();
            Console.WriteLine("Ingrese el id del libro a actualizar");
            libro.IdLibro = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese el nombre del libro");
            libro.Nombre = Console.ReadLine();
            Console.WriteLine("Ingrese el id del autor");
            libro.Autor.IdAutor = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese el numero de paginas");
            libro.NumeroPaginas = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese la fecha de publicacion (dd/mm/yyyy)");
            libro.FechaPublicacion = Console.ReadLine();
            Console.WriteLine("Ingrese el id de editorial");
            libro.Editorial.IdEditorial = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese la edicion");
            libro.Edicion = Console.ReadLine();
            Console.WriteLine("Ingrese el id de genero");
            libro.Genero.IdGenero = int.Parse(Console.ReadLine());
            ML.Result result = BL.Libro.Update(libro);
            if (result.Correct)
            {
                Console.WriteLine(result.Message);
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }
        public static void Delete()
        {
            ML.Libro libro = new ML.Libro();
            Console.WriteLine("Ingrese el id del libro a eliminar");
            libro.IdLibro = int.Parse(Console.ReadLine());
            ML.Result result = BL.Libro.Delete(libro.IdLibro);
            if (result.Correct)
            {
                Console.WriteLine(result.Message);
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }
    }
}
