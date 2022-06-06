using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;
using AutoMapper;
namespace Dto
{
    //מחלקת פרמטרים למשפחה
    public class familyParmeterDto
    {
        public familyParmeterDto(){}
        public int code { get; set; }
        public Nullable<int> constCode { get; set; }
        public Nullable<int> parameterCode { get; set; }
        //פונקציות המרה
        public static familyParmeterDto DalToDto(familyParameters customer)
        {
            var config = new MapperConfiguration(cfg =>
                 cfg.CreateMap<familyParameters, familyParmeterDto>()
             );
            var mapper = new Mapper(config);
            return mapper.Map<familyParmeterDto>(customer);

        }
        public familyParameters DtoToDal()
        {
            var config = new MapperConfiguration(cfg =>
                     cfg.CreateMap<familyParmeterDto, familyParameters>()
                 );
            var mapper = new Mapper(config);
            return mapper.Map<familyParameters>(this);
        }
    }
}
