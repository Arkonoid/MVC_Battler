using Microsoft.AspNetCore.Mvc;
using MVC_Battler.Models;

namespace MVC_Battler.Controllers;

public class BattleController : Controller
{

    // GET
    public IActionResult BattleUpdate(string playerName, string enemyName, int playerHP, int enemyHP, int playerStrength, int enemyStrength)
    {
        enemyHP -= playerStrength;

        if (enemyHP <= 0)
        {
            return RedirectToAction("Victory");
        }

        playerHP -= enemyStrength;

        if (playerHP <= 0)
        {
            return RedirectToAction("Defeat");
        }

        ViewBag.PlayerName = playerName;
        ViewBag.EnemyName = enemyName;
        ViewBag.PlayerHP = playerHP;
        ViewBag.EnemyHP = enemyHP;
        ViewBag.PlayerStrength = playerStrength;
        ViewBag.EnemyStrength = enemyStrength;
        
        return View();
    }

    public IActionResult Victory()
    {
        return View();
    }
    
    public IActionResult Defeat()
    {
        return View();
    }
}