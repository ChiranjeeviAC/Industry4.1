using Industry4._1.DTOs;
using Industry4._1.Model;

namespace Industry4._1.Interfaces
{
    public interface IProductionService
    {
        public Boolean ProductinAlreadypresent(string JobId);
        public Boolean checkMachine(int MachineId);
        public Boolean checkShift(int ShiftId);
        public Boolean checkUser(int UserId);
        public ProductionEntry AddProduction(ProductionCreateDto dto);
        public List<ProductionResponseDto> Get();

        public List<ProductionEntry> GetByShift(int shiftId);
        public ProductionEntry GetByProductId(int PrudID);
        public ProductionEntry DeleteProduction(string jobId);
        public int TotalOKCount();
        public int TotalNCCount();
        public TotalOKCountFromMachineResponse TotalOKCountFromMachine(int machineId);

        public TotalOKCountFromMachinedateResponse TotalOKCountFromMachinedate(int machineId, DateTime from, DateTime to);
        public List<machinesummaryResponse> machinesummary();
    }
}
