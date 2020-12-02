using PAV2apiweb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GestionDeDatos;

namespace PAV2apiweb.Controllers
{
    public class ArticulosFamiliasController : ApiController
    {
            //puedo poner restricciones segun que dato me llega, voy evaluando rutas

            // GET: api/ArticulosFamilias
            public IHttpActionResult Get()
        {
            using (PymesEntities db = new PymesEntities())
            {
                return Ok(db.ArticulosFamilias.ToList());
            }

            //List<ArticulosFamilia> list = new List<ArticulosFamilia>();
            //list.Add(new ArticulosFamilia()
            //{
            //    Id = 1,
            //    Nombre = "Gerardo"
            //});
            //list.Add(new ArticulosFamilia()
            //{
            //    Id = 2,
            //    Nombre = "Gerardo sali"
            //});
            //list.Add(new ArticulosFamilia()
            //{
            //    Id = 3,
            //    Nombre = "Gerardo salinas"
            //});
            //return Ok(list);
        }

        [Route("api/ArticulosFamilias/Top/{top}")] //WebAPI 2

        public IHttpActionResult GetTop(int top, string nombre = "") //si prefijo es get la webAPI ya sabe que es peticion get
        {
            List<ArticulosFamilia> list = new List<ArticulosFamilia>();
            list.Add(new ArticulosFamilia()
            {
                Id = 1,
                Nombre = "Gerardo"
            });
            list.Add(new ArticulosFamilia()
            {
                Id = 2,
                Nombre = "Gerardo sali"
            });
            list.Add(new ArticulosFamilia()
            {
                Id = 3,
                Nombre = "Gerardo salinas"
            });
            if(string.IsNullOrEmpty(nombre))
            {
                return Ok(list.Take(top));
            }

            else
            {
                if(list.Where(a => a.Nombre.StartsWith(nombre)).Count() > 0)
                {
                    return Ok(list.Where(a => a.Nombre.StartsWith(nombre)).Take(top));
                }
                else
                {
                    return NotFound(); //Error 404  
                }
                

            }


        }

        // GET: api/ArticulosFamilias/5
        public  IHttpActionResult Get(int id)
        {
            using (PymesEntities db = new PymesEntities()) 
            {

                return Ok(db.ArticulosFamilias.Where(p => p.IdArticuloFamilia == id).FirstOrDefault());

            }
        }


        //PUEDO PONER OTRO NOMBRE A LA FUNCION QUE NO SEA POST PERO DEBO AGREGAR ETIQUETA 
        // [HttpPost]


        // POST: api/ArticulosFamilias
        public void Post([FromBody] ArticulosFamilias articulosFamilia)
        {
            using (PymesEntities db = new PymesEntities())
            {
                db.ArticulosFamilias.Add(articulosFamilia);
                db.SaveChanges();
            }
            //efectuar operacion de insercion en la BD


        }

        [HttpPut]
        // PUT: api/ArticulosFamilias/5
        public IHttpActionResult Actualizar(int id, [FromBody]ArticulosFamilia articulosFamilia)
        {
            using (PymesEntities db = new PymesEntities())
            {
                db.Entry(articulosFamilia).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            return Ok(articulosFamilia);
        }

        // DELETE: api/ArticulosFamilias/5
        public void Delete(int id)
        {
            using (PymesEntities db = new PymesEntities())
            {
                ArticulosFamilias articulosFamilia = db.ArticulosFamilias.Find(id);
                db.Entry(articulosFamilia).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }
            //borrar desde la bd
        }
    }
}
