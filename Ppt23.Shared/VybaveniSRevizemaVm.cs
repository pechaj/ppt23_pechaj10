using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ppt23.Shared
{
    public class VybaveniSRevizemaVm
    {
        public Guid RevizeId { get; set; }
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public List<RevizeViewModel>? Revizes { get; set; } = new List<RevizeViewModel>();
    }
}
