using Microsoft.AspNetCore.Mvc;
using webgk.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Authorization;
[Authorize]
public class DonHangController : Controller
{
    private readonly ApplicationDbContext _context;

    public DonHangController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: DonHangs
    public async Task<IActionResult> Index()
    {
        var donHangs = await _context.DonHangs.ToListAsync();

        ViewBag.TotalOrders = donHangs.Count();
        ViewBag.TodaySales = donHangs.Count(dh => dh.NgayBan.Date == DateTime.Today);
        ViewBag.TodayRevenue = donHangs.Where(dh => dh.NgayBan.Date == DateTime.Today).Sum(dh => dh.TongTien);
        ViewBag.TotalRevenue = donHangs.Sum(dh => dh.TongTien);

        return View(donHangs);
    }

    // GET: DonHangs/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var donHang = await _context.DonHangs.FirstOrDefaultAsync(m => m.MaDon == id);

        if (donHang == null)
        {
            return NotFound();
        }

        return View(donHang);
    }

    // GET: DonHangs/Create
    [HttpGet]
    public IActionResult Create()
    {
        LoadViewBagData();
        return View();
    }

    // POST: DonHangs/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("MaKhach, ID, Quantity, TongTien, TrangThaiDH, NgayBan")] DonHang donHang)
    {
        if (ModelState.IsValid)
        {
            try
            {
                // Tính toán tổng tiền
                var sanPham = await _context.SanPhams.FirstOrDefaultAsync(sp => sp.ID == donHang.ID);
                if (sanPham != null)
                {
                    donHang.TotalPrice = sanPham.GiaBan * donHang.Quantity;
                }
                // Cập nhật số lượng sản phẩm
                sanPham.Soluong -= donHang.Quantity;
                _context.SanPhams.Update(sanPham);
                // Thêm đơn hàng vào cơ sở dữ liệu
                _context.DonHangs.Add(donHang);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Đã xảy ra lỗi khi lưu đơn hàng: {ex.Message}");
            }
        }

        LoadViewBagData();
        return View(donHang);
    }

    // Tải dữ liệu cho ViewBag (danh sách sản phẩm, khách hàng, v.v.)
    private void LoadViewBagData()
    {
        ViewBag.SanPhams = _context.SanPhams.ToList();
        ViewBag.KhachHangs = _context.KhachHangs.ToList();
    }
}
