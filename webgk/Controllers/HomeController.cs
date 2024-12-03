using Microsoft.AspNetCore.Mvc;
using webgk.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Authorization;
[Authorize]
public class HomeController : Controller
{
    private readonly ApplicationDbContext _context;

    public HomeController(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var donHangs = await _context.DonHangs.ToListAsync();

        // Tổng số đơn hàng
        var totalOrders = donHangs.Count;

        // Bán hàng hôm nay
        var todaySales = donHangs.Count(dh => dh.NgayBan.Date == DateTime.Today);

        // Doanh thu hôm nay
        var todayRevenue = donHangs.Where(dh => dh.NgayBan.Date == DateTime.Today)
                                   .Sum(dh => dh.TongTien);

        // Tổng doanh thu
        var totalRevenue = donHangs.Sum(dh => dh.TongTien);

        ViewBag.TotalOrders = totalOrders;
        ViewBag.TodaySales = todaySales;
        ViewBag.TodayRevenue = todayRevenue;
        ViewBag.TotalRevenue = totalRevenue;

        // Lấy dữ liệu cho biểu đồ đường
        var lineChartData = donHangs
            .GroupBy(d => d.NgayBan.Month)
            .Select(g => new {
                Thang = g.Key,
                DoanhSo = g.Sum(d => d.TongTien)
            })
            .OrderBy(d => d.Thang)
            .ToList();

        ViewBag.LineChartData = lineChartData;

        return View(donHangs);
    }
}
