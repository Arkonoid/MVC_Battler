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

    public class Enemy
    {
        public string EnemyName { get; set; }
        public int EnemyHP { get; set; }
        public int EnemyStrength { get; set; }

        public Enemy()
        {
            
        }
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

        Enemy enemy = new Enemy();
        Random rd = new Random();
        enemy.EnemyHP = rd.Next(10, 31);
        enemy.EnemyStrength = rd.Next(10, 31);

        Enemy charEnemy = new Enemy();
        var charEnemyList = _db.Characters.ToList();

        if (charEnemyList.Count > 0)
        {
            var chosenEnemy = charEnemyList[rd.Next(0, charEnemyList.Count)];
            charEnemy.EnemyName = chosenEnemy.Name;
            charEnemy.EnemyHP = chosenEnemy.HP;
            charEnemy.EnemyStrength = chosenEnemy.Strength;
        }

        var coinToss = rd.Next(0, 2);
        if (coinToss == 0)
        {
            ViewBag.Enemy = enemy;
        }
        else
        {
            ViewBag.Enemy = charEnemy;
        }
        

        var selection = _db.Characters.Find(id);
        return View(selection);
    }
}