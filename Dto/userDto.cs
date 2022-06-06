using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;
using AutoMapper;
namespace Dto
{
    //מחלקת משתמש
    public class userDto
    {
        public userDto() {}

        public int userId { get; set; }
        public string userPassword { get; set; }
        public string userName { get; set; }
        public Nullable<int> apartmentCode { get; set; }
        public Nullable<int> familyCode { get; set; }
        //פונקציות המרה
        public static userDto DalToDto(userDetails u)
        {
            var config = new MapperConfiguration(cfg =>
                 cfg.CreateMap<userDetails, userDto>()
             );
            var mapper = new Mapper(config);
            return mapper.Map<userDto>(u);

        }
        public userDetails DtoToDal()
        {
            var config = new MapperConfiguration(cfg =>
                     cfg.CreateMap<userDto, userDetails>()
                 );
            var mapper = new Mapper(config);
            return mapper.Map<userDetails>(this);
        }
    }
}
