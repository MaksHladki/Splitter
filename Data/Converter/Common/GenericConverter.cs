using System.Collections.Generic;
using System.Linq;


namespace Data.Converter.Common
{
    public abstract class GenericConverter<DB, DTO> : IGenericConverter<DB, DTO>
    {
        public abstract DTO Convert(DB entityDB);
        public abstract DB Convert(DTO entityDTO);
        public abstract DB Copy(DTO entityDTO, DB entityDB);

        public IEnumerable<DB> ConvertAll(IEnumerable<DTO> source)
        {
            return source != null ? source.Select(Convert) : null;
        }

        public IEnumerable<DTO> ConvertAll(IEnumerable<DB> source)
        {
            return source != null ? source.Select(Convert) : null;
        }
    }
}
