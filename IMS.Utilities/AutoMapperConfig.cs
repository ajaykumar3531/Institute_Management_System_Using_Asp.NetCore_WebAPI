using AutoMapper;
using IMS.DataAccessLayer.IMSDatabase;
using IMS.Models.IMS_Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Utilities
{
    public class AutoMapperConfig: Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Batch,BatchDto>().ReverseMap();
           
        }
    }
}
