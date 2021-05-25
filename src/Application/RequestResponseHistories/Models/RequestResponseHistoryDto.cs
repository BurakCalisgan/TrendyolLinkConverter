using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.RequestResponseHistories.Models
{
    public class RequestResponseHistoryDto
    {
        public int Id { get; set; }
        public Guid Guid { get; set; }
        public string Request { get; set; }
        public string Response { get; set; }
        public ConverterTypeEnum ConverterType { get; set; }
    }
}
