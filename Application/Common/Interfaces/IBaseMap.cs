using AutoMapper;

namespace Application.Common.Interfaces
{
    public interface IBaseMap<T>
    {
            void Mapping(Profile profile) => profile.CreateMap(typeof (T), this.GetType());
    }
}