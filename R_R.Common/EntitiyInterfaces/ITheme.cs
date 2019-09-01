using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using R_R.Common.Entities;

namespace R_R.Common.EntitiyInterfaces
{
    public interface ITheme
    {
        int Id { get; set; }
        List<PowerTag> PowerTags { get; set; }



    }
}
