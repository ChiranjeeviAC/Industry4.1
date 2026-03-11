using Industry4._1.Data;
using Industry4._1.DTOs;
using Industry4._1.Interfaces;
using Industry4._1.Model;
using Microsoft.AspNetCore.Mvc;

namespace Industry4._1.Services
{
    public class ShiftService: IShiftService
    {
        private readonly AppDBContext _context;

        public ShiftService(AppDBContext context)
        {
            _context = context;
        }

        
        public Shift AddShift(ShiftCreateDto dto)
        {
            var shift = new Shift
            {
                ShiftName = dto.ShiftName,
                StartTime = dto.StartTime,
                EndTime = dto.EndTime
            };

            _context.Shifts.Add(shift);
            _context.SaveChanges();

            return shift;
        }

       
        public Shift GetShiftById(int id)
        {
            var shift = _context.Shifts
                .Where(s => s.Id == id)
                .Select(s => new Shift
                {
                   Id= s.Id,
                    ShiftName= s.ShiftName,
                    StartTime=  s.StartTime,
                    EndTime = s.EndTime
                })
                .FirstOrDefault();

            if (shift == null)
                return null;

            return shift;
        }



        public List<Shift> GetAllShift()
        {
            var shifts = _context.Shifts
                .Select(s => new Shift
                {
                    Id=s.Id,
                    ShiftName=s.ShiftName,
                    StartTime=s.StartTime,
                    EndTime= s.EndTime
                })
                .ToList();

            if (shifts == null)
                return null;

            return shifts;
        }

    }
}
