using Microsoft.AspNetCore.Mvc;
using ProyectoAdo.Models;
using System.Diagnostics;

using CapaDatos.Repositorio;
using CapaDatos.Entidades;

namespace ProyectoAdo.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmpleadoRepositorio _repositorio;

        public HomeController(IEmpleadoRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<IActionResult> MostrarEmpleados()
        {

            List<Empleado> listaEmpleado = await _repositorio.ObtenerEmpleado();

            return View(listaEmpleado);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}