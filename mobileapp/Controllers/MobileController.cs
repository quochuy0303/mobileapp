using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using mobileapp.Models;

namespace mobileapp.Controllers
{
    public class MobileController : Controller
    {
        private readonly IMobileRepository _mobileRepository;
        private readonly ICategoryRepository _categoryRepository;

        public MobileController(IMobileRepository monileRepository,
      ICategoryRepository categoryRepository)
        {
            _mobileRepository = monileRepository;
            _categoryRepository = categoryRepository;
        }
        public async Task<IActionResult> Index()
        {
            var mobiles = await _mobileRepository.GetAllAsync();
            return View(mobiles);
        }

               
        
 // Hiển thị form thêm sản phẩm mới
 public async Task<IActionResult> AddAsync()
        {
            var categories = await _categoryRepository.GetAllAsync();
            ViewBag.Categories = new SelectList(categories, "Id", "Name");
            return View();
        }
        // Xử lý thêm sản phẩm mới
        [HttpPost]
        public async Task<IActionResult> Add(Mobile mobile)
        {
            if (ModelState.IsValid)
            {
                await _mobileRepository.AddAsync(mobile);
                return RedirectToAction(nameof(Index));
            }
            // Nếu ModelState không hợp lệ, hiển thị form với dữ liệu đã nhập
            var categories = await _categoryRepository.GetAllAsync();
            ViewBag.Categories = new SelectList(categories, "Id", "Name");
            return View(mobile);
        }
        // Hiển thị thông tin chi tiết sản phẩm
        public async Task<IActionResult> Display(int id)
        {
            var product = await _mobileRepository.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }
        // Hiển thị form cập nhật sản phẩm
        public async Task<IActionResult> Update(int id)
        {
            var product = await _mobileRepository.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            var categories = await _categoryRepository.GetAllAsync();
            ViewBag.Categories = new SelectList(categories, "Id", "Name",
            product.IdCategory);
            return View(product);          
       }
        // Xử lý cập nhật sản phẩm
        [HttpPost]
        public async Task<IActionResult> Update(int id, Mobile mobile)
        {
            if (id != mobile.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                await _mobileRepository.UpdateAsync(mobile);
                return RedirectToAction(nameof(Index));
            }
            return View(mobile);
        }
        // Hiển thị form xác nhận xóa sản phẩm
        public async Task<IActionResult> Delete(int id)
        {
            var mobile = await _mobileRepository.GetByIdAsync(id);
            if (mobile == null)
            {
                return NotFound();
            }
            return View(mobile);
        }
        // Xử lý xóa sản phẩm
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _mobileRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
