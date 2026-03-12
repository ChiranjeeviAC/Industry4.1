namespace Industry4._1.DTOs
{
    public class ProductionCreateDto
    {
        public int MachineId { get; set; }

        public string JobId { get; set; }
        public int ShiftId { get; set; }


        public int UserId { get; set; }


        public int OkParts { get; set; }


        public int NcParts { get; set; }
    }
    public class ProductionResponseDto
    {
        public int Id {  get; set; }
                    public string MachineName {  get; set; }

                  public string ShiftName {  get; set; }
                    public string EmployeeId {  get; set; }
                    public int OkParts { get; set; }
                    public int NcParts { get; set; }
        public string JobId { get; set; }
        public DateTime EntryTime { get; set; }

    }

    public class TotalOKCountFromMachineResponse
    {
        public int machineId { get; set; }
        public int TotalOkParts {  get; set; }
        public int TotalNcParts {  get; set; }
        public int TotalProduction {  get; set; }
    }

    public class TotalOKCountFromMachinedateResponse
    {
        public int machineId { get; set; }
        public int TotalOkParts { get; set; }
        public int TotalNcParts { get; set; }
        public int TotalProduction { get; set; }
        public DateTime fromDate { get; set; }
        public DateTime toDate { get; set; }

    }

    public class machinesummaryResponse
    {
        public string MachineCode { get; set; }
        public string MachineName { get; set; }
        public int TotalOKParts { get; set; }
        public int TotalNCParts { get; set; }
        public int TotalParts { get; set; }

    }

}
