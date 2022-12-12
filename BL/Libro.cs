using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Libro
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.Connection()))
                {
                    var query = "LibroGetAll";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;

                        context.Open();

                        DataTable tablelibro = new DataTable();
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                        adapter.Fill(tablelibro);

                        if (tablelibro.Rows.Count > 0)
                        {
                            result.Objects = new List<object>();
                            foreach (DataRow row in tablelibro.Rows)
                            {
                                ML.Libro libro = new ML.Libro();
                                libro.Autor = new ML.Autor();
                                libro.Editorial = new ML.Editorial();
                                libro.Genero = new ML.Genero();

                                libro.IdLibro = int.Parse(row[0].ToString());
                                libro.Nombre = row[1].ToString();
                                libro.Autor.IdAutor = int.Parse(row[2].ToString());
                                libro.Autor.NombreAutor = row[3].ToString();
                                libro.NumeroPaginas = int.Parse(row[4].ToString());
                                libro.FechaPublicacion = row[5].ToString();
                                libro.Editorial.IdEditorial = int.Parse(row[6].ToString());
                                libro.Editorial.NombreEditorial = row[7].ToString();
                                libro.Edicion = row[8].ToString();
                                libro.Genero.IdGenero = int.Parse(row[9].ToString());
                                libro.Genero.NombreGenero = row[10].ToString();

                                result.Objects.Add(libro);
                            }
                        }
                    }
                }
                result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Error al mostrar la lista de libros" + ex;
            }
            return result;
        }

        public static ML.Result GetById(int idLibro)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.Connection()))
                {
                    var query = "LibroGetById";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;

                        context.Open();

                        SqlParameter[] collection = new SqlParameter[1];

                        collection[0] = new SqlParameter("IdLibro", SqlDbType.Int);
                        collection[0].Value = idLibro;

                        cmd.Parameters.AddRange(collection);

                        DataTable tablelibro = new DataTable();
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                        adapter.Fill(tablelibro);

                        if (tablelibro.Rows.Count > 0)
                        {
                            DataRow row = tablelibro.Rows[0];
                            ML.Libro libro = new ML.Libro();
                            libro.Autor = new ML.Autor();
                            libro.Editorial = new ML.Editorial();
                            libro.Genero = new ML.Genero();

                            libro.IdLibro = int.Parse(row[0].ToString());
                            libro.Nombre = row[1].ToString();
                            libro.Autor.IdAutor = int.Parse(row[2].ToString());
                            libro.Autor.NombreAutor = row[3].ToString();
                            libro.NumeroPaginas = int.Parse(row[4].ToString());
                            libro.FechaPublicacion = row[5].ToString();
                            libro.Editorial.IdEditorial = int.Parse(row[6].ToString());
                            libro.Editorial.NombreEditorial = row[7].ToString();
                            libro.Edicion = row[8].ToString();
                            libro.Genero.IdGenero = int.Parse(row[9].ToString());
                            libro.Genero.NombreGenero = row[10].ToString();

                            result.Object = libro;
                        }
                    }
                }
                result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Error al mostrar el libro" + ex;
            }
            return result;
        }

        public static ML.Result Add(ML.Libro libro)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.Connection()))
                {
                    var query = "LibroAdd";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;

                        context.Open();

                        SqlParameter[] collection = new SqlParameter[7];

                        collection[0] = new SqlParameter("Nombre", SqlDbType.VarChar);
                        collection[0].Value = libro.Nombre;
                        collection[1] = new SqlParameter("IdAutor", SqlDbType.Int);
                        collection[1].Value = libro.Autor.IdAutor;
                        collection[2] = new SqlParameter("NumeroPaginas", SqlDbType.Int);
                        collection[2].Value = libro.NumeroPaginas;
                        collection[3] = new SqlParameter("FechaPublicacion", SqlDbType.Date);
                        collection[3].Value = libro.FechaPublicacion;
                        collection[4] = new SqlParameter("IdEditorial", SqlDbType.Int);
                        collection[4].Value = libro.Editorial.IdEditorial;
                        collection[5] = new SqlParameter("Edicion", SqlDbType.VarChar);
                        collection[5].Value = libro.Edicion;
                        collection[6] = new SqlParameter("IdGenero", SqlDbType.Int);
                        collection[6].Value = libro.Genero.IdGenero;

                        cmd.Parameters.AddRange(collection);

                        int rowAffected = cmd.ExecuteNonQuery();

                        if (rowAffected > 0)
                        {
                            result.Message = "Se inserto el libro correctamente";
                        }
                    }
                }
                result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Error al insertar el libro" + ex;
            }
            return result;
        }

        public static ML.Result Update(ML.Libro libro)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.Connection()))
                {
                    var query = "LibroUpdate";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;

                        context.Open();

                        SqlParameter[] collection = new SqlParameter[8];

                        collection[0] = new SqlParameter("IdLibro", SqlDbType.Int);
                        collection[0].Value = libro.IdLibro;
                        collection[1] = new SqlParameter("Nombre", SqlDbType.VarChar);
                        collection[1].Value = libro.Nombre;
                        collection[2] = new SqlParameter("IdAutor", SqlDbType.Int);
                        collection[2].Value = libro.Autor.IdAutor;
                        collection[3] = new SqlParameter("NumeroPaginas", SqlDbType.Int);
                        collection[3].Value = libro.NumeroPaginas;
                        collection[4] = new SqlParameter("FechaPublicacion", SqlDbType.Date);
                        collection[4].Value = libro.FechaPublicacion;
                        collection[5] = new SqlParameter("IdEditorial", SqlDbType.Int);
                        collection[5].Value = libro.Editorial.IdEditorial;
                        collection[6] = new SqlParameter("Edicion", SqlDbType.VarChar);
                        collection[6].Value = libro.Edicion;
                        collection[7] = new SqlParameter("IdGenero", SqlDbType.Int);
                        collection[7].Value = libro.Genero.IdGenero;

                        cmd.Parameters.AddRange(collection);

                        int rowAffected = cmd.ExecuteNonQuery();

                        if (rowAffected > 0)
                        {
                            result.Message = "Se actualizo el libro correctamente";
                        }
                    }
                }
                result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Error al actualizar el libro" + ex;
            }
            return result;
        }

        public static ML.Result Delete(int? idLibro)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.Connection()))
                {
                    var query = "LibroDelete";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;

                        context.Open();

                        SqlParameter[] collection = new SqlParameter[1];

                        collection[0] = new SqlParameter("IdLibro", SqlDbType.Int);
                        collection[0].Value = idLibro;

                        cmd.Parameters.AddRange(collection);

                        int rowAffected = cmd.ExecuteNonQuery();

                        if (rowAffected > 0)
                        {
                            result.Message = "Se elimino el libro correctamente";
                        }
                    }
                }
                result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Error al eliminar el libro" + ex;
            }
            return result;
        }

        public static ML.Result GetAllEF()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.EYañezExamenEntities context = new DL_EF.EYañezExamenEntities())
                {

                    var execute = context.LibroGetAll().ToList();

                    if (execute.Count > 0)
                    {
                        result.Objects = new List<object>();

                        foreach (var item in execute)
                        {

                            ML.Libro libro = new ML.Libro();
                            libro.Autor = new ML.Autor();
                            libro.Editorial = new ML.Editorial();
                            libro.Genero = new ML.Genero();

                            libro.IdLibro = item.IdLibro;
                            libro.Nombre = item.Nombre;
                            libro.Autor.IdAutor = (int)item.IdAutor;
                            libro.NumeroPaginas = (int)item.NumeroPaginas;
                            libro.FechaPublicacion = item.FechaPublicacion.ToString();
                            libro.Editorial.IdEditorial = (int)item.IdEditorial;
                            libro.Edicion = item.Edicion;
                            libro.Genero.IdGenero = (int)item.IdGenero;

                            libro.Autor.Nombre = item.NombreAutor;
                            libro.Editorial.Nombre = item.NombreEditorial;
                            libro.Genero.Nombre = item.NombreGenero;

                            result.Objects.Add(libro);
                        }
                    }
                }
                result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Error al mostrar la lista de libros" + ex;
            }
            return result;
        }

        public static ML.Result GetByIdEF(int IdLibro)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.EYañezExamenEntities context = new DL_EF.EYañezExamenEntities())
                {
                    var execute = context.LibroGetById(IdLibro).SingleOrDefault();

                    if (execute != null)
                    {
                        ML.Libro libro = new ML.Libro();
                        libro.Autor = new ML.Autor();
                        libro.Editorial = new ML.Editorial();
                        libro.Genero = new ML.Genero();

                        libro.IdLibro = execute.IdLibro;
                        libro.Nombre = execute.Nombre;
                        libro.Autor.IdAutor = (int)execute.IdAutor;
                        libro.NumeroPaginas = (int)execute.NumeroPaginas;
                        libro.FechaPublicacion = execute.FechaPublicacion.ToString();
                        libro.Editorial.IdEditorial = (int)execute.IdEditorial;
                        libro.Edicion = execute.Edicion;
                        libro.Genero.IdGenero = (int)execute.IdGenero;

                        libro.Autor.Nombre = execute.NombreAutor;
                        libro.Editorial.Nombre = execute.NombreEditorial;
                        libro.Genero.Nombre = execute.NombreGenero;

                        result.Object = libro;

                    }                 
                }
                result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Error al mostrar el libro" + ex;
            }
            return result;
        }

        public static ML.Result AddEF(ML.Libro libro)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.EYañezExamenEntities context = new DL_EF.EYañezExamenEntities())
                {

                    int execute = context.LibroAdd(
                        libro.Nombre,
                        libro.Autor.IdAutor,
                        libro.NumeroPaginas,
                        DateTime.Parse(libro.FechaPublicacion.ToString()),
                        libro.Editorial.IdEditorial,
                        libro.Edicion,
                        libro.Genero.IdGenero);


                    if (execute > 0)
                    {
                        result.Message = "Se inserto el libro correctamente";
                    }
                    result.Correct = true;
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Error al insertar el libro" + ex;
            }
            return result;
        }

        public static ML.Result UpdateEF(ML.Libro libro)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.EYañezExamenEntities context = new DL_EF.EYañezExamenEntities())
                {
                    int execute = context.LibroUpdate(
                     libro.IdLibro,
                     libro.Nombre,
                     libro.Autor.IdAutor,
                     libro.NumeroPaginas,
                     DateTime.Parse(libro.FechaPublicacion.ToString()),
                     libro.Editorial.IdEditorial,
                     libro.Edicion,
                     libro.Genero.IdGenero);


                    if (execute > 0)
                    {
                        result.Message = "Se actualizo el libro correctamente";
                    }
                    result.Correct = true;
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Error al actualizar el libro" + ex;
            }
            return result;
        }


        public static ML.Result DeleteEF(int IdLibro)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.EYañezExamenEntities context = new DL_EF.EYañezExamenEntities())
                {
                    int execute = context.LibroDelete(IdLibro);


                    if (execute > 0)
                    {
                        result.Message = "Se elimino el libro correctamente";
                    }
                    result.Correct = true;
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Error al eliminar el libro" + ex;
            }
            return result;
        }
    }
}
