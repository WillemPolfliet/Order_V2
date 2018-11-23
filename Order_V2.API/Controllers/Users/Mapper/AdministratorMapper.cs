using Order_V2.API.Controllers.Users.DTO.AdministratorDTOs;
using Order_V2.API.Controllers.Users.Mapper.Interfaces;
using Order_V2.Domain.Users.Administrators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order_V2.API.Controllers.Users.Mapper
{
    public class AdministratorMapper : IAdministratorMapper
    {
        private readonly IWorkplaceMapper _workplaceMapper;

        public AdministratorMapper(IWorkplaceMapper workplaceMapper)
        {
            _workplaceMapper = workplaceMapper;
        }

        public List<AdministratorDTO_Return> AdministratorListToDTOReturnList(List<Administrator> adminList)
        {
            List<AdministratorDTO_Return> returnlist = new List<AdministratorDTO_Return>();
            foreach (var item in adminList)
            {
                returnlist.Add(AdministratorToDTOReturn(item));
            }
            return returnlist;
        }

        public AdministratorDTO_Return AdministratorToDTOReturn(Administrator admin)
        {
            return new AdministratorDTO_Return()
            {
                DateEdited = admin.DateEdited,
                Discriminator = admin.Discriminator,
                FirstName = admin.FirstName,
                LastName = admin.LastName,
                Login_Email = admin.Login_Email,
                RegistrationDate = admin.RegistrationDate,
                User_ID = admin.User_ID,
                ListOfPhones = admin.ListOfPhones.Select(x => x.PhoneNumberValue).ToList(),
                WorkplaceDTO = _workplaceMapper.WorkplaceToDTO(admin.Workplace)
            };
        }

        public Administrator_InternalDTO DTOToInternalDTO(AdministratorDTO_Create item)
        {
            throw new NotImplementedException();
        }
    }
}
