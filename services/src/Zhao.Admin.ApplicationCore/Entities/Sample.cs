using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zhao.Admin.ApplicationCore.Interfaces;

namespace Zhao.Admin.ApplicationCore.Entities
{
    public class Sample : IAggregateRoot
    {
        public Guid Id { get; set; }
        public string String { get; set; }
        public int Int32 { get; set; }
        public bool Boolean { get; set; }
        public DateTime DateTime { get; set; }
        public DateOnly DateOnly { get; set; }
    }
}