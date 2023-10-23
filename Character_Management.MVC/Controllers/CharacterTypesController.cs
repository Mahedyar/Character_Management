using Character_Management.MVC.Contracts;
using Character_Management.MVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Character_Management.MVC.Controllers
{
    public class CharacterTypesController : Controller
    {
        private readonly ICharacterTypeService _characterTypeService;

        public CharacterTypesController(ICharacterTypeService characterTypeService)
        {
            _characterTypeService = characterTypeService;
        }
        // GET: CharacterType
        public async Task<ActionResult>  Index()
        {
            var characterTypes = await _characterTypeService.GetCharacterTypes();
            return View(characterTypes);
        }

        // GET: CharacterType/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CharacterType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CharacterType/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateCharacterTypeVM createCharacterType)
        {
            try
            {
                var response = await _characterTypeService.CreateCharacterType(createCharacterType);
                if (response.Success)
                {
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError("", response.ValidationErrors);
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
               
            }
            return View(createCharacterType);
        }

        // GET: CharacterType/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var characterType = await _characterTypeService.GetCharacterTypeDetails(id);
            return View(characterType);
        }

        // POST: CharacterType/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, CharacterTypeVM characterTypeVM)
        {
            try
            {
                var response = await _characterTypeService.UpdateCharacterType(id , characterTypeVM);
                if (response.Success)
                {
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError("", response.ValidationErrors);
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message); 
            }
			return View(characterTypeVM);
		}

        // GET: CharacterType/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CharacterType/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
