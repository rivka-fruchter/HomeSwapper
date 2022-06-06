using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;
using AutoMapper;
namespace Dto
{
    public class apartmentDto
    {
        //מחלקת דירה
        public apartmentDto()
        {

        }
        public int apartcode { get; set; }
        public Nullable<int> cityCode { get; set; }
        public string Street { get; set; }
        public Nullable<int> numRooms { get; set; }
        public Nullable<int> numBeds { get; set; }
        public Nullable<System.DateTime> startDate { get; set; }
        public Nullable<System.DateTime> endDate { get; set; }
        //פונקציות המרה 
        public static apartmentDto DalToDto(apartment customer)
        {
            var config = new MapperConfiguration(cfg =>
                 cfg.CreateMap<apartment, apartmentDto>()
             );
            var mapper = new Mapper(config);
            return mapper.Map<apartmentDto>(customer);

        }
        public apartment DtoToDal()
        {
            var config = new MapperConfiguration(cfg =>
                     cfg.CreateMap<apartmentDto, apartment>()
                 );
            var mapper = new Mapper(config);
            return mapper.Map<apartment>(this);
        }
    }
}

