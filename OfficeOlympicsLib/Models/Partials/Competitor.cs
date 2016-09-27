using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeOlympicsLib.Models
{
    public partial class Competitor
    {
        public string FullName => $"{FirstName} {LastName}";
    }
}
