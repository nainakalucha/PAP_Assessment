using AutoMapper;

namespace Assignment.Common
{
    /// <summary>
    /// Mapping class used by automapper.
    /// </summary>
    public class AutoMapping : Profile
    {
        /// <summary>
        /// Create new instance of <see cref="AutoMapping"/> class.
        /// </summary>
        public AutoMapping()
        {
            CreateMap<UserLogin, UserLoginDto>().ReverseMap();
        }
    }
}
