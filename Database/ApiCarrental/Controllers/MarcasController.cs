﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiCarrental.Controllers
{
    public class MarcasController : ApiController
    {
        // GET: api/Marcas
        public RespuestaApi Get()
        {
            RespuestaApi resultado = new RespuestaApi();
            List<Marca> listaMarcas = new List<Marca>();
            try
            {
                Db.Conectar();

                if (Db.EstaLaConexionAbierta())
                {
                    listaMarcas = Db.GetMarcas();
                }
                resultado.error = "";
                Db.Desconectar();
            }
            catch
            {
                resultado.error = "Se produjo un error";
            }

            resultado.totalElementos = listaMarcas.Count;
            resultado.dataMarcas = listaMarcas;
            return resultado;
        }

        // GET: api/Marcas/5
        public RespuestaApi Get(long id)
        {
            RespuestaApi resultado = new RespuestaApi();
            List<Marca> listaMarcas = new List<Marca>();
            try
            {
                Db.Conectar();

                if (Db.EstaLaConexionAbierta())
                {
                    listaMarcas = Db.GetMarcasPorId(id);
                }
                resultado.error = "";
                Db.Desconectar();
            }
            catch
            {
                resultado.error = "Se produjo un error";
            }

            resultado.totalElementos = listaMarcas.Count;
            resultado.dataMarcas = listaMarcas;
            return resultado;
        }

        // POST: api/Marcas
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Marcas/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Marcas/5
        public void Delete(int id)
        {
        }
    }
}
