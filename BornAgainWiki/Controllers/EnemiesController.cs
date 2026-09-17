using Microsoft.AspNetCore.Mvc;
using BornAgainWiki.Models.Enemies;
using Ronin.Model.Definitions;
using BornAgainWiki.Providers;
using Ronin.Model.Enums;
using Ronin.Model;

namespace BornAgainWiki.Controllers;

public class EnemiesController : Controller {
    private readonly ObjectLibraryProvider _objectLibraryProvider;

    public EnemiesController(ObjectLibraryProvider objectLibraryProvider) {
        _objectLibraryProvider = objectLibraryProvider;
    }

    public async Task<IActionResult> Index() {
        return await EnemyViewAsync();
    }

    [Route("bosses")]
    public async Task<IActionResult> Bosses() 
    {
        return await EnemyViewAsync(x => x.Where(x => x.Archetype == EnemyArchetype.Encounter || x.Archetype == EnemyArchetype.EncounterMinion));
    }

    [Route("camp_leaders")]
    public async Task<IActionResult> Camp_Leaders() {
        return await EnemyViewAsync(x => x.Where(x => x.Archetype == EnemyArchetype.CampLeader));
    }

    [Route("minions")]
    public async Task<IActionResult> Minions() {
        return await EnemyViewAsync(x => x.Where(x => x.Archetype == EnemyArchetype.Minion));
    }

    protected async Task<IActionResult> EnemyViewAsync(Func<IEnumerable<EnemyDefinition>, IEnumerable<EnemyDefinition>>? filter = null) {
        var library = await _objectLibraryProvider.GetLibraryAsync();
        if (library == null) {
            // TODO error
            return RedirectToAction("Error", "Home");
        }

        IEnumerable<EnemyDefinition> enemies = library.All().OfType<EnemyDefinition>()
            .Where(x => x.Flags.HasNone(ObjectFlags.Hide));
        if (filter != null) enemies = filter(enemies);
        var model = new EnemiesViewModel(enemies);
        return View(model);
    }
}