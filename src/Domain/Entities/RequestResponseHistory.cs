using Domain.Common;
using Domain.Enums;
using System;

namespace Domain.Entities
{
    public class RequestResponseHistory : AuditableEntity<int>
    {
        public Guid Guid { get; set; }
        public string Request { get; set; }
        public string Response { get; set; }
        public ConverterTypeEnum ConverterType { get; set; }

    }
}
