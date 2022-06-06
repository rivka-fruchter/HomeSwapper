using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;
using AutoMapper;
namespace Dto
{
    //מחלקת עיר
    public class cityDto
    {
        public cityDto()
        {

        }
        public int cityCode { get; set; }
        public string cityName { get; set; }
        public Nullable<int> area { get; set; }
        //פונקציות המרה
        public static cityDto DalToDto(city_ c)
        {
            var config = new MapperConfiguration(cfg =>
                 cfg.CreateMap<city_, cityDto>()
             );
            var mapper = new Mapper(config);
            return mapper.Map<cityDto>(c);

        }
        public city_ DtoToDal()
        {
            var config = new MapperConfiguration(cfg =>
                     cfg.CreateMap<cityDto, city_>()
                 );
            var mapper = new Mapper(config);
            return mapper.Map<city_>(this);
        }
    }
}
