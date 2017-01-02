using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KillerApp.Models;

namespace KillerApp.Interfaces
{
    public interface IBestellingSQLContext
    {
        void Bestelling(List<Bestelling> producten);
    }
}
