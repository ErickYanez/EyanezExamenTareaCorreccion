using ML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Genero
    {
        public static Result GetAll()
        {
            Result result = new Result();
            try
            {
                using (DL_EF.EYañezExamenEntities context = new DL_EF.EYañezExamenEntities())
                {
                    var execute = context.GeneroGetAll().ToList();

                    if (execute.Count > 0)
                    {
                        result.Objects = new List<object>();

                        foreach (var item in execute)
                        {
                            ML.Genero genero = new ML.Genero();

                            genero.IdGenero = item.IdGenero;
                            genero.Nombre = item.Nombre;

                            result.Objects.Add(genero);
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
