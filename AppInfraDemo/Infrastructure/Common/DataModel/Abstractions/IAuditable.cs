using System;

namespace Common.DataModel.Abstractions
{
    public interface IAuditable
    {
        DateTime ModifiedDate { get; set; }
    }
}
