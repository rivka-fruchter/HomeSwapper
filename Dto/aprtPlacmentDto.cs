using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;
using AutoMapper;
namespace Dto
{
    //מחלקת השיבוץ
    public class aprtPlacmentDto
    {
        public aprtPlacmentDto()
        {

        }
        public int placementCode { get; set; }
        public Nullable<int> apartmentCode { get; set; }
        public Nullable<int> familyCode { get; set; }
        public Nullable<System.DateTime> startDate { get; set; }
        public Nullable<System.DateTime> endDate { get; set; }
        public Nullable<double> Precent { get; set; }
        //פונקציות המרה
        public static aprtPlacmentDto DalToDto(apartmentPlacement ap)
        {
            var config = new MapperConfiguration(cfg =>
                 cfg.CreateMap<apartmentPlacement, aprtPlacmentDto>()
             );
            var mapper = new Mapper(config);
            return mapper.Map<aprtPlacmentDto>(ap);

        }
        public apartmentPlacement DtoToDal()
        {
            var config = new MapperConfiguration(cfg =>
                     cfg.CreateMap<aprtPlacmentDto, apartmentPlacement>()
                 );
            var mapper = new Mapper(config);
            return mapper.Map<apartmentPlacement>(this);
        }
    }
}
