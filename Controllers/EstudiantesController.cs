using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Actividad4LengProg3.Models;

namespace Actividad4LengProg3.Controllers
{
    public class EstudiantesController : Controller
    {
        // Lista estática para guardar los estudiantes en memoria
        private static List<EstudianteViewModel> estudiantes = new List<EstudianteViewModel>();

        // GET: Estudiantes/Index
        public IActionResult Index()
        {
            return View(new EstudianteViewModel());
        }

        // POST: Estudiantes/Registrar
        [HttpPost]
        public IActionResult Registrar(EstudianteViewModel estudiante)
        {
            if (!estudiante.EstaBecado)
            {
                estudiante.PorcentajeBeca = null;
            }

            if (ModelState.IsValid)
            {
                // Verifica si ya existe una matrícula igual
                if (estudiantes.Any(e => e.Matricula == estudiante.Matricula))
                {
                    ModelState.AddModelError("Matricula", "Ya existe un estudiante con esa matrícula.");
                    return View("Index", estudiante);
                }

                estudiantes.Add(estudiante);
                return RedirectToAction("Lista");
            }

            return View("Index", estudiante);
        }

        // GET: Estudiantes/Lista
        public IActionResult Lista()
        {
            return View(estudiantes);
        }

        // GET: Estudiantes/Editar/{matricula}
        public IActionResult Editar(string matricula)
        {
            var estudiante = estudiantes.FirstOrDefault(e => e.Matricula == matricula);
            if (estudiante == null)
                return NotFound();

            return View(estudiante);
        }

        // POST: Estudiantes/Editar
        [HttpPost]
        public IActionResult Editar(EstudianteViewModel estudiante)
        {
            if (!estudiante.EstaBecado)
            {
                estudiante.PorcentajeBeca = null;
            }

            if (ModelState.IsValid)
            {
                var existente = estudiantes.FirstOrDefault(e => e.Matricula == estudiante.Matricula);
                if (existente != null)
                {
                    // Actualizar datos
                    estudiantes.Remove(existente);
                    estudiantes.Add(estudiante);
                    return RedirectToAction("Lista");
                }
            }

            return View(estudiante);
        }

        // GET: Estudiantes/Eliminar/{matricula}
        public IActionResult Eliminar(string matricula)
        {
            var estudiante = estudiantes.FirstOrDefault(e => e.Matricula == matricula);
            if (estudiante != null)
            {
                estudiantes.Remove(estudiante);
            }
            return RedirectToAction("Lista");
        }
    }
}

