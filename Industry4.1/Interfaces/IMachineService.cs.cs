using Industry4._1.DTOs;
using Industry4._1.Model;
using Microsoft.AspNetCore.Mvc;

namespace Industry4._1.Interfaces
{
    public interface IMachineService
    {
        public List<Machine> GetAllMachines();
        public Machine GetMachineById(int id);

        public Machine CreateMachine(MachineDTO machinedto);

        public Machine DeleteMachine(int  id);

        public Machine UpdateMachine(UpdateMachineDto dto);

        public List<MachineCodeDto> GetAllMachinesCode();

        public List<string> GetAllMachinesCodeonly();
        public List<MachineNameeDto> GetAllMachinesName();
        public Usre AddUser(CreateUserDto dto);
        public List<Login> Login(LoginAndMachine dto);
        public Machine LoginMachine(LoginAndMachine dto);
    }

}
