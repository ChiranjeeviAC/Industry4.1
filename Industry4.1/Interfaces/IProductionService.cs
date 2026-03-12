using Industry4._1.DTOs;
using Industry4._1.Model;

namespace Industry4._1.Interfaces
{
    public interface IProductionService
    {
        public Boolean ProductinAlreadypresent(string JobId);
        public Boolean checkMachine(string MachineCode);
        public Boolean checkShift(string ShiftName);
        public Boolean checkUser(string EmployeeId);
        public ProductionEntry AddProduction(ProductionCreateDto dto);
        public List<ProductionResponseDto> Get();
        public List<ProductionEntry> GetByShift(string shiftName);

        
        public ProductionEntry GetByProductId(int PrudID);
        public ProductionEntry DeleteProduction(string jobId);
        public int TotalOKCount();
        public int TotalNCCount();
        public TotalOKCountFromMachineResponse TotalOKCountFromMachine(string machineCode);

        public TotalOKCountFromMachinedateResponse TotalOKCountFromMachinedate(string machineCode, DateTime from, DateTime to);
        public List<machinesummaryResponse> machinesummary();
        public List<operatorperformanceDto> operatorperformance();
        public ProductionEntry UpdateProduction(UpdateProductionDto dto);
        public List<resultResponseDto> ShiftReport(string shiftName);
        public dailyResponseDto daily(DateTime date);
        public TopMachineResponseDto TopMachine();
        public ProductionbyMachineUserPerCycleResponseDto ProductionbyMachineUserPerCycle(GetMachineandUserProduction dto);
        public List<MachineUser1ResponseDto> MachineUser1(MachineUser dto);
        public MachineUser2ResponseDto MachineUser2(MachineUser dto);
    }
}
