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
    public class ProductionController : ControllerBase
    {
        public IProductionService _productionservice;
        public ProductionController(IProductionService productionservice)
        {
            _productionservice = productionservice;
        }

        [HttpPost]
        public IActionResult AddProduction(ProductionCreateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var ProdEntryAlredy = _productionservice.ProductinAlreadypresent(dto.JobId);

            if (ProdEntryAlredy == false)
            {
                return BadRequest(new
                {
                    Status = false,
                    Message = "Production entry aleardy present",

                }
                    );
            }

            var machine = _productionservice.checkMachine(dto.MachineId);
            if (machine == true)
                return BadRequest("Invalid Machine");


            var shift = _productionservice.checkMachine(dto.ShiftId);
            if (shift == null)
                return BadRequest("Invalid Shift");


            var user = _productionservice.checkUser(dto.UserId);
            if (user == null)
                return BadRequest("Invalid User");

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

            return Ok(new
            {
                Status = true,
                Message = "Production entry added successfully",
                Data = production
            });
        }


        [HttpGet]
        public IActionResult Get()
        {
            var result = _productionservice.Get();
            return Ok(new
            {
                Status = true,
                Message = $"Number of Production entry are {result.Count}",
                Data = result
            });
        }


        [HttpGet("Shift/{ShiftId}")]
        public IActionResult GetByShift(int shiftId)
        {
            var result = _productionservice.GetByShift(shiftId);

            if (result == null)
            {
                return BadRequest(new
                {
                    Status = false,
                    Message = $"No Production entry at Shift fount of ShiftId: {shiftId}"
                });
            }

            return Ok(new
            {
                Status = true,
                Message = $" Production entry at Shift of ShiftId: {shiftId}",
                Data = result
            });
        }

        [HttpGet("GetByProductId/{PrudID}")]
        public IActionResult GetByProductId(int PrudID)
        {
            var result = _productionservice.GetByProductId(PrudID);

            if (result == null)
            {
                return BadRequest(new
                {
                    Status = false,
                    Message = $"No Production entry at Shift fount of ShiftId: {PrudID}"
                });
            }

            return Ok(new
            {
                Status = true,
                Message = $" Production entry at Shift of ShiftId: {PrudID}",
                Data = result
            });
        }

        [HttpDelete("ByJobId")]
        public IActionResult DeleteProduction(string jobId)
        {
            var res = _productionservice.DeleteProduction(jobId);
            if (res == null)
            {
                return NotFound(new
                {
                    Status = false,
                    Message = $"JobID not found for JobID: {jobId}"
                });
            }
            return Ok(new
            {
                Status = true,
                Message = $"Production Entry deleted of JobID: {jobId}",
                Data = res
            });
        }


        [HttpGet("TotalOKCount")]
        public IActionResult TotalOKCount()
        {
            var totalOk = _productionservice.TotalOKCount();
            return Ok(new
            {
                TotalOkCount = totalOk
            });
        }

        [HttpGet("TotalNcCount")]
        public IActionResult TotalNcCount()
        {
            var totalNc = _productionservice.TotalNCCount();
            return Ok(new
            {
                TotalOkCount = totalNc
            });
        }


        [HttpGet("TotalOKCountFromMachine")]
        public IActionResult TotalOKCountFromMachine(int machineId)
        {
            var totalOk = _productionservice.TotalOKCountFromMachine(machineId);

            return Ok(new
            {
                Status = true,
                message = "Total Ok & Nc Counts of Machine fetched Secussfully",
                data = totalOk
            });
        }

        [HttpGet("TotalOkNcCountFromMachineFromTodate")]
        public IActionResult TotalOKCountFromMachinedate(int machineId, DateTime from, DateTime to)
        {
            var production = _productionservice.TotalOKCountFromMachinedate(machineId, from, to);

            return Ok(new
            {
                Status = true,
                message = "Total Ok & Nc Counts of Machine specific Date to  specific Date fetched Secussfully",
                data = production
            });
        }

        [HttpGet("machine-summary")]
        public IActionResult machinesummary()
        {
            var result = _productionservice.machinesummary();

            if (result.Count == 0)
            {
                return NoContent();
            }

            return Ok(new
            {
                Status = true,
                Message = "Details of Production According to Machine",
                Data = result
            });
        }

    }
}
