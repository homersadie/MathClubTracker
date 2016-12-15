using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathClubTracker.Domain.DomainObjects
{
    public class BaseDomainObject
    {
        public static T Copy<T, U>(U s)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<U, T>());
            Mapper mapper = new Mapper(config);
            T dto = (T)mapper.DefaultContext.Mapper.Map(s, typeof(U), typeof(T));
            return dto;
        }


        public static List<T> CopyList<T,U>(List<U> source)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<U, T>());
            List<T> list = new List<T>();
            Mapper mapper = new Mapper(config);
            foreach (U u in source)
            {
                T dto = (T)mapper.DefaultContext.Mapper.Map(u, typeof(U), typeof(T));
                list.Add(dto);
            }
            return list;
        }
    }
}
