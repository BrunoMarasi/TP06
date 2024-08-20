using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TP06.Models;

namespace TP06.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult VerDeportes()
    {
        ViewBag.listaDeportes = BD.listarDeportes();
        return View();
    }

    public IActionResult VerPaises()
    {
        ViewBag.listaPaises = BD.listarPaises();
        return View();
    }
    public IActionResult VerDetalleDeporte(int idDeporte)
    {
        Deportes deporte = BD.verInfoDeporte(idDeporte);
        List<Deportistas> listaDeportistas = BD.listarDeportistas1(idDeporte);
        ViewBag.Deporte = deporte;
        ViewBag.listaDeportistas = listaDeportistas;
        return View();
    }

    public IActionResult VerDetallePais(int idPais)
    {
        Paises pais = BD.verInfoPais(idPais);
        List<Deportistas> listaDeportistas = BD.listarDeportistas2(idPais);
        ViewBag.Pais = pais;
        ViewBag.listaDeportistas = listaDeportistas;
        return View();
    }

    public IActionResult VerDetalleDeportista(int idDeportista)
    {
        Deportistas deportistas = BD.verInfoDeportistas(idDeportista);
        ViewBag.Deportistas = deportistas;
        return View();
    }

    public IActionResult Creditos(){
        return View();
    }


}
