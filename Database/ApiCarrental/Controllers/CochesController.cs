using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiCarrental
{
    public class CochesController : ApiController
    {
        // GET: api/Coches
        //public IEnumerable<Coche> Get()
        public RespuestaApi Get()
        {
            RespuestaApi resultado = new RespuestaApi();
            List<Coche> data = new List<Coche>();
            try
            { 
                Db.Conectar();

                if (Db.EstaLaConexionAbierta())
                {
                    //trae lista de coches
                    data = Db.DameListaCochesConProcedimientoAlmacenado();
                    resultado.error = "";
                    
                }

            }
            catch (Exception ex)
            {
                resultado.error = "Error";
            }

            resultado.totalElementos = data.Count;
            resultado.data = data;
            return resultado;
        }

        // GET: api/Coches/5
        public RespuestaApi Get(long id)
        {
            RespuestaApi resultado = new RespuestaApi();
            List<Coche> data = new List<Coche>();
            try
            {
                Db.Conectar();
                if (Db.EstaLaConexionAbierta())
                {
                    data = Db.DameListaCochesConProcedimientoAlmacenadoPorId(id);
                    resultado.error = "";
                }
                Db.Desconectar();
            }
            catch (Exception ex)
            {
                resultado.error = "Error";
            }
            resultado.totalElementos = data.Count;
            resultado.data = data;
            return resultado;

        }


        // POST: api/Coches
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Coches/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Coches/5
        public void Delete(int id)
        {
        }
    }
}
