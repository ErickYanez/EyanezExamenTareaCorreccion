using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Seleccione la opcion a utilizar");
            Console.WriteLine("1. Ver Libros \n2. Ver libro por id \n3. Agregar Libro \n4. Editar Libro \n5. Eliminar Libro ");
            int opcion = int.Parse(Console.ReadLine());
            switch (opcion)
            {
                case 1:
                    Console.WriteLine();
                    Libro.GetAll();
                    break;
                case 2:
                    Console.WriteLine();
                    Libro.GetById();
                    break;
                case 3:
                    Console.WriteLine();
                    Libro.Add();
                    break;
                case 4:
                    Console.WriteLine();
                    Libro.Update();
                    break;
                case 5:
                    Console.WriteLine();
                    Libro.Delete();
                    break;

            }
            Console.ReadKey();
        }
    }
}
