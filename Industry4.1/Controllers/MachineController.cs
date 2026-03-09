using Industry4._1.Data;
using Industry4._1.DTOs;
using Industry4._1.Interfaces;
using Industry4._1.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Industry4._1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MachineController : ControllerBase
    {
         public IMachineService _machineservice; 
        public MachineController(IMachineService machineservice)
        {
            _machineservice = machineservice;
        }

        [HttpPost]
        public IActionResult Create(MachineDTO dto )
        {
            var var = _machineservice.CreateMachine(dto);
            return Ok(new
            {
                Status = true,
                Message = "Machine created Succesfully",
                Data = var
            });
        }


        [HttpGet]
        public IActionResult Get() { 
        var res = _machineservice.GetAllMachines();
            return Ok(new
            {
                Status = true,
                Message = "Machines data fetch seccusfully ",
                data = res
            });
        }

        [HttpGet("GetCode")]
        public IActionResult GetCode()
        {
            var res = _machineservice.GetAllMachinesCode();
            return Ok(new
            {
                Status = true,
                Message = "Machines code fetch seccusfully ",
                data = res
            });
        }
        [HttpGet("GetMName")]
        public IActionResult GetMName()
        {
            var res = _machineservice.GetAllMachinesName();
            return Ok(new
            {
                Status = true,
                Message = "Machines Name fetch seccusfully ",
                data = res
            }); ;
        }

        [HttpGet("GetCodeonly")]
        public IActionResult GetCodeonly()
        {
            var res = _machineservice.GetAllMachinesCodeonly();
            return Ok(res);
        }

        [HttpGet("GetById/{id}")]
        public IActionResult GetById(int id)
        {
            var res = _machineservice.GetMachineById(id);

            if (res == null)
            {
                return NotFound(new
                {
                    succes = true,
                    Message = "Machine Not found"
                });
            }

            return Ok(new
            {
                succes = true,
                Message = "Machine feached Succesfully",
                data = res
            });
        }

        [HttpDelete]
        public IActionResult DeleteMachine(int id)
        {
            var res = _machineservice.DeleteMachine( id);

            if (res == null)
            {
                return BadRequest(new
                {
                    Status = false,
                    Message = "No Machine Found"
                    
                });
            }

            return Ok(new
            {
                Status = true,
                Message = "Machine Delated Seccsuflly",
                data = res
            });


        }


        [HttpPatch]
        public IActionResult UpdateMachine(UpdateMachineDto dto)
        {
            var res = _machineservice.UpdateMachine(dto);

            if (res == null)
            {
                return BadRequest(new
                {
                    Status = false,
                    Message = "No Machine Found"

                });
            }

            return Ok(new
            {
                Status = true,
                Message = "Machine Updated Seccsuflly",
                data = res
            });
        }

    }
}
