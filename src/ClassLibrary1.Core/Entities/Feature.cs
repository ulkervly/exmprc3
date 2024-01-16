using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hook.Core.Entities
{
    public class Feature:BaseEntity
    {
        public string Icon {  get; set; }
        public string Title { get; set; }
        public string ButtonName { get; set; }
        public string Description { get; set; }
    }
}
