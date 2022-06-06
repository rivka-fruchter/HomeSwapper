using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;
using AutoMapper;
namespace Dto
{
    //מחלקת משפחה
    public class familyDto
    {
        public familyDto(){}
        public int familyCode { get; set; }
        public string familyName { get; set; }
        public string phone { get; set; }
        public Nullable<int> apartmentCode { get; set; }
        public string email { get; set; }
        //פונקציות המרה
        public static familyDto DalToDto(Familiy f)
        {
            var config = new MapperConfiguration(cfg =>
                 cfg.CreateMap<Familiy, familyDto>()
             );
            var mapper = new Mapper(config);
            return mapper.Map<familyDto>(f);

        }
        public Familiy DtoToDal()
        {
            var config = new MapperConfiguration(cfg =>
                     cfg.CreateMap<familyDto, Familiy>()
                 );
            var mapper = new Mapper(config);
            return mapper.Map<Familiy>(this);
        }
    }
}
