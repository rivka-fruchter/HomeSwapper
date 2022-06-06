using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;
using AutoMapper;
namespace Dto
{
    //מחלקת פרמטרים בדירה
    public class parInApartDto
    {
        public parInApartDto(){}
        public int code { get; set; }
        public Nullable<int> codeApart { get; set; }
        public Nullable<int> codeParameter { get; set; }
        //פונקציות המרה
        public static parInApartDto DalToDto(parametersInApart p)
        {
            var config = new MapperConfiguration(cfg =>
                 cfg.CreateMap<parametersInApart, parInApartDto>()
             );
            var mapper = new Mapper(config);
            return mapper.Map<parInApartDto>(p);

        }
        public parametersInApart DtoToDal()
        {
            var config = new MapperConfiguration(cfg =>
                     cfg.CreateMap<parInApartDto, parametersInApart>()
                 );
            var mapper = new Mapper(config);
            return mapper.Map<parametersInApart>(this);
        }
    }
}
