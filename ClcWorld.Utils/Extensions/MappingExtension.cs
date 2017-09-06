using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using AutoMapper.Mappers;

namespace ClcWorld.Utils.Extensions
{
    /// <summary>
    /// AutoMapping Extension
    /// </summary>
    public static class MappingExtension
    {
        /// <summary>
        /// Extension method to map this object type into destination type.
        /// </summary>
        /// <typeparam name="TDest"></typeparam>
        /// <param name="src"></param>
        /// <returns></returns>
        public static TDest ToMap<TDest>(this object src)
        {
            return (TDest)global::AutoMapper.Mapper.Map(src, src.GetType(), typeof(TDest));
        }
    }
}
