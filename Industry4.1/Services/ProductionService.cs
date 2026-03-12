using Industry4._1.Data;
using Industry4._1.DTOs;
using Industry4._1.Model;
using Microsoft.AspNetCore.Mvc;

namespace Industry4._1.Services
{
    public class ProductionService
    {
        private readonly AppDBContext _context;

        public ProductionService(AppDBContext context)
        {
            _context = context;
        }


        public Boolean ProductinAlreadypresent(string JobId)
        {
            var ProdEntryAlredy = _context.ProductionEntries.Where(i => i.JobId == JobId).FirstOrDefault();

            return (ProdEntryAlredy != null);
        }
        public Boolean checkMachine(int MachineId)
        {
            var machine = _context.Machines.FirstOrDefault(m => m.Id == MachineId);
            return (machine == null);
        }

        public Boolean checkShift(int ShiftId)
        {
            var machine = _context.Shifts.FirstOrDefault(m => m.Id == ShiftId);
            return (machine == null);
        }

        public Boolean checkUser(int UserId)
        {
            var machine = _context.AppUsers.FirstOrDefault(m => m.Id == UserId);
            return (machine == null);
        }


        public ProductionEntry AddProduction(ProductionCreateDto dto)
        {
            var production = new ProductionEntry
            {
                MachineId = dto.MachineId,
                JobId = dto.JobId,
                ShiftId = dto.ShiftId,
                UserId = dto.UserId,
                OkParts = dto.OkParts,
                NcParts = dto.NcParts,
                EntryTime = DateTime.Now
            };

            _context.ProductionEntries.Add(production);
            _context.SaveChanges();

            return production;
        }


        
        public List<ProductionResponseDto> Get()
        {
            var result = (
                from p in _context.ProductionEntries
                join m in _context.Machines on p.MachineId equals m.Id
                join u in _context.AppUsers on p.UserId equals u.Id
                join s in _context.Shifts on p.ShiftId equals s.Id
                select new ProductionResponseDto
                {
                   Id= p.Id,
                    MachineName = m.MachineName,
                    ShiftName = s.ShiftName,
                    EmployeeId = u.EmployeeId,
                    OkParts=p.OkParts,
                    NcParts = p.NcParts,
                    EntryTime = p.EntryTime,
                    JobId= p.JobId
                }
                ).ToList();
            return result;
        }


        
        public List<ProductionEntry> GetByShift(int shiftId) { 
        
            var result = _context.ProductionEntries.Where(i => i.ShiftId == shiftId).ToList();

            if (result.Count == 0) {

                return null;
            }

            return result;
        }

        
        public ProductionEntry GetByProductId(int PrudID)
        {
            var result = _context.ProductionEntries.Where(i => i.Id == PrudID).FirstOrDefault();

            if (result == null)
            {
                return null;
            }

            return result;
        }

        
        public ProductionEntry DeleteProduction(string jobId)
        {
            var res = _context.ProductionEntries.Where(i => i.JobId == jobId).FirstOrDefault();
            if (res == null)
            {
                return null;
            }
            return res;
        }

        
        public int TotalOKCount()
        {
            var totalOk = _context.ProductionEntries.Sum(p => p.OkParts);
            return totalOk;
        }

        public int TotalNCCount()
        {
            var totalNc = _context.ProductionEntries.Sum(p => p.NcParts);
            return totalNc;
        }

        
        public TotalOKCountFromMachineResponse TotalOKCountFromMachine(int machineId)
        {
            var totalOk = _context.ProductionEntries.Where(p => p.MachineId == machineId).ToList();
            var totalokM = totalOk.Sum(p => p.OkParts);
            var totalncM = totalOk.Sum(p => p.NcParts);
            return (new TotalOKCountFromMachineResponse
            {
                machineId = machineId,
                TotalOkParts = totalokM,
                TotalNcParts = totalncM,
                TotalProduction = totalokM + totalncM
            });
        }

        
        public TotalOKCountFromMachinedateResponse TotalOKCountFromMachinedate(int machineId, DateTime from, DateTime to)
        {
            var production = _context.ProductionEntries
        .Where(p => p.MachineId == machineId
        && p.EntryTime >= from
        && p.EntryTime <= to)
        .ToList();

            var totalokM = production.Sum(p => p.OkParts);
            var totalncM = production.Sum(p => p.NcParts);
            return (new TotalOKCountFromMachinedateResponse
            {
                machineId = machineId,
                fromDate = from,
                toDate = to,
                TotalOkParts = totalokM,
                TotalNcParts = totalncM,
                TotalProduction = totalokM + totalncM
            });
        }

        [HttpGet("machine-summary")]
        public List<machinesummaryResponse> machinesummary()
        {
            var result = (
        from p in _context.ProductionEntries
        join m in _context.Machines on p.MachineId equals m.Id
        group p by new
        {
            m.MachineCode,
            m.MachineName
        }
        into g
        select new machinesummaryResponse
        {
            MachineCode = g.Key.MachineCode,
            MachineName = g.Key.MachineName,
            TotalOKParts = g.Sum(x => x.OkParts),
            TotalNCParts = g.Sum(x => x.NcParts),
            TotalParts = g.Sum(x => x.OkParts + x.NcParts)
        }).ToList();

            if (result.Count == 0)
            {
                return null;
            }

            return result;
        }
         
    
    }
}
