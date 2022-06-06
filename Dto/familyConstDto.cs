using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;
using AutoMapper;
namespace Dto
{
    //מחלקת אילוצי משפחה
    public class familyConstDto
    {
        public familyConstDto(){}
        public int constCode { get; set; }
        public Nullable<int> familyCode { get; set; }
        public Nullable<int> cityCode { get; set; }
        public Nullable<int> numRooms { get; set; }
        public Nullable<int> numBeds { get; set; }
        public Nullable<System.DateTime> startDate { get; set; }
        public Nullable<System.DateTime> endDate { get; set; }
        //פונקציות המרה
        public static familyConstDto DalToDto(familyConstraint fc)
        {
            var config = new MapperConfiguration(cfg =>
                 cfg.CreateMap<familyConstraint, familyConstDto>()
             );
            var mapper = new Mapper(config);
            return mapper.Map<familyConstDto>(fc);

        }
        public familyConstraint DtoToDal()
        {
            var config = new MapperConfiguration(cfg =>
                     cfg.CreateMap<familyConstDto, familyConstraint>()
                 );
            var mapper = new Mapper(config);
            return mapper.Map<familyConstraint>(this);
        }
    }
}
