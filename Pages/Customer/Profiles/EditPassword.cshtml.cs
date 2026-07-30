using DALTWNC_QUIZ.Data;
using DALTWNC_QUIZ.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

// 👉 FIX lỗi namespace trùng Customer
using CustomerModel = DALTWNC_QUIZ.Models.Customer;

namespace DALTWNC_QUIZ.Pages.Customer.Profiles
{
    public class EditPasswordModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public EditPasswordModel(ApplicationDbContext context)
        {
            _context = context;
        }

        // 👉 dùng alias để tránh lỗi namespace
        public CustomerModel Customer { get; set; }

        public User UserAccount { get; set; }

        [BindProperty]
        public string CurrentPassword { get; set; }

        [BindProperty]
        public string NewPassword { get; set; }

        [BindProperty]
        public string ConfirmPassword { get; set; }

        public string ErrorMessage { get; set; }

        // =========================
        // LOAD PAGE
        // =========================
        public async Task<IActionResult> OnGetAsync(string username)
        {
            if (string.IsNullOrEmpty(username))
                return RedirectToPage("/Index");

            Customer = await _context.Customers
                .FirstOrDefaultAsync(c => c.Username == username);

            UserAccount = await _context.Users
                .FirstOrDefaultAsync(u => u.Username == username);

            if (Customer == null || UserAccount == null)
                return NotFound();

            return Page();
        }

        // =========================
        // ĐỔI MẬT KHẨU
        // =========================
        public async Task<IActionResult> OnPostAsync(string username)
        {
            if (string.IsNullOrEmpty(username))
                return RedirectToPage("/Index");

            Customer = await _context.Customers
                .FirstOrDefaultAsync(c => c.Username == username);

            UserAccount = await _context.Users
                .FirstOrDefaultAsync(u => u.Username == username);

            if (Customer == null || UserAccount == null)
                return NotFound();

            // ❌ Sai mật khẩu hiện tại
            if (!BCrypt.Net.BCrypt.Verify(CurrentPassword, UserAccount.Password))
            {
                ErrorMessage = "Mật khẩu hiện tại không đúng!";
                return Page();
            }

            // ❌ Không khớp mật khẩu mới
            if (NewPassword != ConfirmPassword)
            {
                ErrorMessage = "Xác nhận mật khẩu không khớp!";
                return Page();
            }

            // ✅ Hash password mới
            UserAccount.Password = BCrypt.Net.BCrypt.HashPassword(NewPassword);

            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = "Đổi mật khẩu thành công!";

            return RedirectToPage("/Customer/Profiles/Profile", new { username = username });
        }
    }
}