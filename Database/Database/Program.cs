using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Conectando a la base de datos");
            Db.Conectar();

            if (Db.EstaLaConexionAbierta())
            {
                //List<MarcasNCoches> lista = Db.DameListaMarcasNCoches();
                //lista.ForEach(elemento => 
                //{
                //    Console.WriteLine(
                //            " Marca: " + elemento.marca
                //            +
                //            " Nº de coches: " + elemento.nCoches
                //            );
                //});

                //List<Coche> listaCoches = Db.DameListaCochesConProcedimientoAlmacenado();
                //listaCoches.ForEach(coche =>
                //{
                //    Console.WriteLine(
                //        @"Matrícula: " + coche.matricula +
                //        " Marca: " + coche.marca.denominacion +
                //        " Combustible: " + coche.tipoCombustible.denominacion
                //        );
                //});

                //List<Coche> listaCoches = Db.GET_COCHE_POR_MARCA_MATRICULA_PLAZAS();
                //listaCoches.ForEach(coche =>
                //{
                //    Console.WriteLine(
                //        @"Matrícula: " + coche.matricula +
                //        " Marca: " + coche.marca.denominacion +
                //        " NPlazas: " + coche.nPlazas
                //        );
                //});


                List<Coche> listaCoches = Db.GET_COCHE_POR_MARCA_MATRICULA_PLAZAS_2("toyota", 4);
                listaCoches.ForEach(coche =>
                {
                    Console.WriteLine(
                        @"Matrícula: " + coche.matricula +
                        " Marca: " + coche.marca.denominacion +
                        " NPlazas: " + coche.nPlazas
                        );
                });
            }
            Db.Desconectar();
            Console.ReadKey();
        }
    }
}