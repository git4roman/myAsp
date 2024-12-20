using Microsoft.AspNetCore.Mvc;
using MyAsp.Data;
using MyAsp.Models;
using Microsoft.EntityFrameworkCore;

namespace MyAsp.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class CategoryController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }

        // Get All Categories
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var categories = _db.Categories.ToList();
                return Ok(categories);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


        // Create a new Category
        [HttpPost]
        public IActionResult Add([FromBody] Category category)
        {
            try
            {
                if (category == null || !ModelState.IsValid)
                    return BadRequest("Invalid category data.");

                _db.Categories.Add(category);
                _db.SaveChanges();

                return CreatedAtAction(nameof(GetSingle), new { id = category.Id }, category);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // Get a single category by ID
        [HttpGet("{id}")]
        public IActionResult GetSingle(int id)
        {
            try
            {
                var category = _db.Categories.FirstOrDefault(c => c.Id == id);
                if (category == null) return NotFound(new { message = "Category not found" });
                return Ok(category);
            }
            catch (Exception ex)
            {
                // Return a 500 Internal Server Error with the exception message
                return StatusCode(500, new { message = "An error occurred while fetching the category", details = ex.Message });
            }
        }

        // Update a category
        [HttpPut("{id}")]
        public IActionResult Edit(int id, [FromBody] Category updatedCategory)
        {
            var category = _db.Categories.FirstOrDefault(c => c.Id == id);
            if (category == null) return NotFound(new { message = "Category not found" });

            category.Name = updatedCategory.Name;
            category.Description = updatedCategory.Description;

            _db.SaveChanges();
            return Ok(new { message = "Category updated successfully", category });
        }

        // Delete a Category
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var category = _db.Categories.FirstOrDefault(c => c.Id == id);
                if (category == null) return NotFound();

                _db.Categories.Remove(category);
                _db.SaveChanges();
                return NoContent(); // Successful deletion
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet]
        public IActionResult Search([FromQuery] string query)
        {
            try
            {
                if (string.IsNullOrEmpty(query))
                    return BadRequest("Search query cannot be empty.");

                // Search categories by Name or Description containing the query (case-insensitive)
                var categories = _db.Categories
                    .Where(c => c.Name.Contains(query) || c.Description.Contains(query))
                    .ToList();

                if (categories.Count == 0)
                    return NotFound(new { message = "No categories found matching the search criteria." });

                return Ok(categories);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

    }
}
