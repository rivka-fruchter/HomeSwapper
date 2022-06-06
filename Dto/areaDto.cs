using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;
using AutoMapper;
namespace Dto
{
    //מחלקת אזור
    class areaDto
    {
        public areaDto()
        {

        }
        public int areaCode { get; set; }
        public string areaName { get; set; }
        //פונקציות המרה
        public static areaDto DalToDto(area a)
        {
            var config = new MapperConfiguration(cfg =>
                 cfg.CreateMap<area, areaDto>()
             );
            var mapper = new Mapper(config);
            return mapper.Map<areaDto>(a);

        }
        public area DtoToDal()
        {
            var config = new MapperConfiguration(cfg =>
                     cfg.CreateMap<areaDto, area>()
                 );
            var mapper = new Mapper(config);
            return mapper.Map<area>(this);
        }
    }
}
