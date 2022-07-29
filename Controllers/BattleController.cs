using Microsoft.AspNetCore.Mvc;
using MVC_Battler.Models;

namespace MVC_Battler.Controllers;

public class BattleController : Controller
{
    // GET
    public IActionResult BattleUpdate(Character player, Character enemy, int? playerHP, int? enemyHP, int? playerStrength, int? enemyStrength)
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

        ViewBag.Player = player;
        ViewBag.Enemy = enemy;
        ViewBag.PlayerHP = playerHP;
        ViewBag.EnemyHP = enemyHP;

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