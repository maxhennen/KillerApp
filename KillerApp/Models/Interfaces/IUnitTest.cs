using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KillerApp.Models.Interfaces
{
    public interface IUnitTest
    {
        Producten ProductenToevoegenWinkelmandUnitTest(string productNaam, int specificatieID);
    }
}
