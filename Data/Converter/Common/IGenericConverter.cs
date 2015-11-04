using System.Collections.Generic;

namespace Data.Converter.Common
{
    interface IGenericConverter<DB, DTO>
    {
        DTO Convert(DB dbEntity);
        DB Convert(DTO entity);
        DB Copy(DTO source, DB target);

        IEnumerable<DB> ConvertAll(IEnumerable<DTO> source);
        IEnumerable<DTO> ConvertAll(IEnumerable<DB> source);
    }
}
