using CrudTask.Data;
using CrudTask.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace CrudTask.Controllers
{
    public class TareaController : Controller
    {
        private readonly ApplicationDbContext contexto;

        public TareaController(ApplicationDbContext contexto)
        {
            this.contexto = contexto;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Listar()
        {
            IEnumerable<Tarea> listaTarea = contexto.Tarea;

           // IEnumerable<Tarea> listaTarea = contexto.Tarea.OrderByDescending(t => t.Id).ToList();

            return View(listaTarea);
        }
        public IActionResult Crear()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Crear(Tarea t)
        {
            if (ModelState.IsValid)
            {
                contexto.Tarea.Add(t);
                contexto.SaveChanges();
                ModelState.Clear();
            
            }

            TempData["SuccessMessage"] = "La tarea se ha creado con éxito.";


            return View();
        }

        public IActionResult Editar(int? id)
        {
            Tarea c = contexto.Tarea.Find(id); //peticion http get - aqui buscamos el id

            if (c == null)
                return NotFound(); // sino lo encuentra arroja un mensaje de invalido
            return View(c); // y si lo encuentra lo muestra desde la vista
        }

        [HttpPost]
        public IActionResult Editar(Tarea c)
        {
            if (ModelState.IsValid) //comprobamos que el modelo sea valido
            {
                contexto.Tarea.Update(c);
                contexto.SaveChanges();
              
                //return RedirectToAction("Listar");
            }
            return View();
        }

        public IActionResult Borrar(int? id)
        {
            Tarea c = contexto.Tarea.Find(id); //peticion http get - aqui buscamos el id

            if (c == null)
            {
                return NotFound();
            }
            else
            {
                contexto.Tarea.Remove(c);
                contexto.SaveChanges();
                return RedirectToAction("Listar");
            }

        }


        public IActionResult Completar(int? id)
        {
            var tarea = contexto.Tarea.Find(id);

            if (tarea == null)
            {
                return NotFound(); //http 404
            }

            tarea.Status = !tarea.Status;
            contexto.Entry(tarea).State = EntityState.Modified;
            contexto.SaveChanges();

            return RedirectToAction("Listar");

        }

        public ActionResult Regresar()
        {
            return RedirectToAction("Listar");
        }
    }
}
