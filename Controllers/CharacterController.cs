using Microsoft.AspNetCore.Mvc;
using MVC_Battler.Data;
using MVC_Battler.Models;

namespace MVC_Battler.Controllers;

public class CharacterController : Controller
{
    private readonly ApplicationDbContext _db;

    public CharacterController(ApplicationDbContext db)
    {
        _db = db;
    }
    
    public IActionResult Index()
    {
        IEnumerable<Character> objCharacterList = _db.Characters.ToList();
        return View(objCharacterList);
    }
    
    //GET
    public IActionResult Create()
    {
        return View();
    }
    
    //POST
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Character obj)
    {
        _db.Characters.Add(obj);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }
}