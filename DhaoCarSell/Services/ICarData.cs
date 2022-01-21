using CarSellApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace DhaoCarSell.Services
{
    public interface ICarData
    {
        IActionResult Create();
        IActionResult Delete(int id);
        IActionResult Edit(int id);
    }
}
