using Ecommerce.Data;
using Ecommerce.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Controllers
{
    /// <summary>
    /// Handles the store catalog inventory management, including listing, adding, editing, and deleting products.
    /// </summary>
    public class ProductController : Controller
    {
        /// <summary>
        /// The active database context used for communicating with the underlying SQL database storage.
        /// </summary>
        private readonly ProductDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductController"/> class and injects the database dependency.
        /// </summary>
        /// <param name="context">The application's active database context instance.</param>
        public ProductController(ProductDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// GET: /Product/Index
        /// Queries the database for all available products and renders the catalog inventory list dashboard.
        /// </summary>
        /// <returns>A view displaying an enumerable list of all products in the database catalog.</returns>
        public async Task<IActionResult> Index()
        {
            List<Product> allProducts = await _context.Products.ToListAsync();
            return View(allProducts);
        }

        /// <summary>
        /// GET: /Product/Create
        /// Displays a blank administrative form page used for adding a brand new product item to the catalog.
        /// </summary>
        /// <returns>A blank form view for inputting product details.</returns>
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// POST: /Product/Create
        /// Validates, tracks, and asynchronously commits a new product submission to the SQL database rows.
        /// </summary>
        /// <param name="p">The product entity populated from the matching HTML input elements.</param>
        /// <returns>A redirect to the inventory catalog index upon validation success, or the form view with errors.</returns>
        [HttpPost]
        public async Task<IActionResult> Create(Product p)
        {
            if (ModelState.IsValid)
            {
                _context.Products.Add(p);
                await _context.SaveChangesAsync();

                TempData["Message"] = $"{p.Title} was created successfully";

                return RedirectToAction(nameof(Index));
            }
            return View(p);
        }

        /// <summary>
        /// GET: /Product/Edit/{id}
        /// Locates an existing catalog item by its primary key identifier and surfaces its properties inside an edit form.
        /// </summary>
        /// <param name="id">The unique database row primary key integer of the target product.</param>
        /// <returns>The populated product record configuration entry form view, or a HTTP 404 warning block.</returns>
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            Product? product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        /// <summary>
        /// POST: /Product/Edit
        /// Submits updated product model modifications and applies them asynchronously to the matching persistent database record.
        /// </summary>
        /// <param name="product">The edited product data object containing historical row identification parameters.</param>
        /// <returns>A redirect link back to the catalog dashboard page layout, or the form with validation tracking highlights.</returns>
        [HttpPost]
        public async Task<IActionResult> Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Update(product);
                await _context.SaveChangesAsync();

                TempData["Message"] = $"{product.Title} was updated successfully";
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        /// <summary>
        /// GET: /Product/Delete/{id}
        /// Loads a critical data double-check page asking the administrator to explicitly confirm target database element removal.
        /// </summary>
        /// <param name="id">The explicit product row identification tracking integer value block constraint parameters.</param>
        /// <returns>The confirmation form view displaying the item summary data blocks, or an HTTP status warning layout.</returns>
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            Product? product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        /// <summary>
        /// POST: /Product/Delete
        /// Permanently drops an active record entity completely from the physical SQL server data structural layers.
        /// </summary>
        /// <param name="id">The validated product row primary key integer identifier used to coordinate the removal operation.</param>
        /// <returns>A redirect command leading straight back to the inventory grid alongside a feedback notification banner.</returns>
        [ActionName(nameof(Delete))]
        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            Product? product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return RedirectToAction(nameof(Index));
            }

            _context.Remove(product);
            await _context.SaveChangesAsync();

            TempData["Message"] = $"{product.Title} was successfully deleted";

            return RedirectToAction(nameof(Index));
        }
    }
}
