using ML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Autor
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.EYañezExamenEntities context = new DL_EF.EYañezExamenEntities())
                {
                    var execute = context.AutorGetAll().ToList();

                    if (execute.Count > 0)
                    {
                        result.Objects = new List<object>();

                        foreach (var item in execute)
                        {
                            ML.Autor autor = new ML.Autor();

                            autor.IdAutor = item.IdAutor;
                            autor.Nombre = item.Nombre;


                            result.Objects.Add(autor);
                        }
                       
                    }
                }
                result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Error al mostrar la lista de autores" + ex;
            }
            return result;
        }
    }
}
