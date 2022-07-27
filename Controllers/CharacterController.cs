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
        if (ModelState.IsValid)
        {
            _db.Characters.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        return View(obj);
    }
    
    //GET
    public IActionResult Edit(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }

        var characterFromDb = _db.Characters.Find(id);

        if (characterFromDb == null)
        {
            return NotFound();
        }

        return View(characterFromDb);
    }
    
    //POST
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(Character obj)
    {
        if (ModelState.IsValid)
        {
            _db.Characters.Update(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        return View(obj);
    }
    
    //GET
    public IActionResult Delete(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }

        var characterFromDb = _db.Characters.Find(id);

        if (characterFromDb == null)
        {
            return NotFound();
        }

        _db.Characters.Remove(characterFromDb);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }

    //GET
    public IActionResult Selection()
    {
        IEnumerable<Character> objCharacterList = _db.Characters.ToList();
        return View(objCharacterList);
    }
    
    //GET
    public IActionResult Battle(int? id)
    {
        var selection = _db.Characters.Find(id);
        return View(selection);
    }
}