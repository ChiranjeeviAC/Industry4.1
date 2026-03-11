using Industry4._1.DTOs;
using Industry4._1.Interfaces;
using Industry4._1.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Industry4._1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShiftController : ControllerBase
    {
        public IShiftService _shiftservice;
        public ShiftController(IShiftService shiftservice)
        {
            _shiftservice = shiftservice;
        }


        [HttpPost("AddShift")]
        public IActionResult AddShift(ShiftCreateDto dto)
        {


            var shift = _shiftservice.AddShift(dto);

            return Ok(              
                new
                {
                    Status = true,
                    Message = "Shift created successfully",
                    Data = shift
                });
        }

        [HttpGet("{id}")]
        public IActionResult GetShiftById(int id)
        {
            var shift = _shiftservice.GetShiftById(id);

            if (shift == null)
                return NotFound(new
                {
                    Status = false,
                    Message = "Shift not found",

                });

            return Ok(new
            {
                Status = true,
                Message = $"Shift at id: {id}",
                Data = shift
            });
        }

        [HttpGet("GetAllShift")]
        public IActionResult GetAllShift()
        {
            var shifts = _shiftservice.GetAllShift();

            if (shifts == null)
                return NotFound(new
                {
                    Status = false,
                    Message = "No Shift Present",

                });

            return Ok(new
            {
                Status = true,
                Message = $"Total number of Shifts are: {shifts.Count}",
                Data = shifts
            });
        }



    }
}
