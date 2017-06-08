using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiCarrental.Controllers
{
    public class CombustiblesController : ApiController
    {
        // GET: api/Combustibles
        public RespuestaApi Get()
        {
            RespuestaApi resultado = new RespuestaApi();
            List<TipoCombustible> listaCombustible = new List<TipoCombustible>();
            try
            {
                Db.Conectar();

                if (Db.EstaLaConexionAbierta())
                {
                    listaCombustible = Db.GetCombustibles();
                }
                resultado.error = "";
                Db.Desconectar();
            }
            catch
            {
                resultado.error = "Se produjo un error";
            }

            resultado.totalElementos = listaCombustible.Count;
            resultado.dataCombustibles = listaCombustible;
            return resultado;
        }

        // GET: api/Combustibles/5
        public RespuestaApi Get(long id)
        {
            RespuestaApi resultado = new RespuestaApi();
            List<TipoCombustible> listaCombustible = new List<TipoCombustible>();
            try
            {
                Db.Conectar();

                if (Db.EstaLaConexionAbierta())
                {
                    listaCombustible = Db.GetCombustiblesPorId(id);
                }
                resultado.error = "";
                Db.Desconectar();
            }
            catch
            {
                resultado.error = "Se produjo un error";
            }

            resultado.totalElementos = listaCombustible.Count;
            resultado.dataCombustibles = listaCombustible;
            return resultado;
        }

        // POST: api/Combustibles
        [HttpPost]
        public IHttpActionResult Post([FromBody] TipoCombustible combustible)
        {
            RespuestaApi respuesta = new RespuestaApi();
            respuesta.error = "";
            int filasAfectadas = 0;
            try
            {
                Db.Conectar();

                if (Db.EstaLaConexionAbierta())
                {
                    filasAfectadas = Db.AgregarTipoCombustible(combustible);
                }

                respuesta.totalElementos = filasAfectadas;

                Db.Desconectar();
            }
            catch (Exception ex)
            {
                //En caso de error
                respuesta.totalElementos = 0;
                respuesta.error = "Error al agregar la marca";
            }

            return Ok(respuesta);
        }

        // PUT: api/Combustibles/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Combustibles/5
        public void Delete(int id)
        {
        }
    }
}
