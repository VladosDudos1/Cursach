using Core;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimeController : Controller
    {
        [HttpGet]
        public IEnumerable<ListType> GetListType()
        {
            return DataManager.GetListTypes();
        }

        [HttpPost("{idTitle}/{idList}")]
        public IActionResult AddTitleToList(int idTitle, int idList)
        {
            DataManager.AddTitleToList(DataManager.TitleById(idTitle), idList);
            return Content("ADDED");
        }

        [HttpPut("{idTitle}/{id}")]
        public IActionResult ChangeListType(int idTitle, int id)
        {
            DataManager.ChangeTitleListType(DataManager.TitleById(idTitle), id);
            return Content("Updated");
        }

        [HttpDelete("idTitle")]
        public IActionResult DeleteUserLists(int idTitle)
        {
            DataManager.DeleteTitleFromList(DataManager.TitleById(idTitle));
            return Content(idTitle.ToString());
        }
    }
}
