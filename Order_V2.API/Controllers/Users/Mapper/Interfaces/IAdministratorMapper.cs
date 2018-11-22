using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Order_V2.API.Controllers.Users.DTO.AdministratorDTOs;
using Order_V2.Domain.Users;
using Order_V2.Domain.Users.Administrators;

namespace Order_V2.API.Controllers.Users.Mapper.Interfaces
{
    public interface IAdministratorMapper
    {
        AdministratorDTO_Return AdministratorToDTOReturn(Administrator item);
        List<AdministratorDTO_Return> AdministratorListToDTOReturnList(List<Administrator> adminList);
    }
}
