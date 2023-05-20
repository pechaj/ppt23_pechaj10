using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ppt23.Shared
{
    public class UkonVm
    {
        public Guid Id { get; set; }
        public string NazevAkce { get; set; } = null!;
        public DateTime DateTime { get; set; }
    }
}
