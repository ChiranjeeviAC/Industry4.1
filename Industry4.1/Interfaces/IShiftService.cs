using Industry4._1.DTOs;
using Industry4._1.Model;

namespace Industry4._1.Interfaces
{
    public interface IShiftService
    {
        public Shift AddShift(ShiftCreateDto dto);
        public Shift GetShiftById(int id);
        public List<Shift> GetAllShift();
    }
}
