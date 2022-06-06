using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;
using AutoMapper;
namespace Dto
{
    //מחלקת פרמטרים
    public class parameterDto
    {
        public parameterDto() { }
        public int codeParameter { get; set; }
        public string descrip { get; set; }
        //פונקציות המרה
        public static parameterDto DalToDto(parameter p)
        {
            var config = new MapperConfiguration(cfg =>
                 cfg.CreateMap<parameter, parameterDto>()
             );
            var mapper = new Mapper(config);
            return mapper.Map<parameterDto>(p);

        }
        public parameter DtoToDal()
        {
            var config = new MapperConfiguration(cfg =>
                     cfg.CreateMap<parameterDto, parameter>()
                 );
            var mapper = new Mapper(config);
            return mapper.Map<parameter>(this);
        }
    }
}
