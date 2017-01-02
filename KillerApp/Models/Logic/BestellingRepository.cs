using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KillerApp.Interfaces;
using KillerApp.Models;

namespace KillerApp.Logic
{
    class BestellingRepository
    {
        private IBestellingSQLContext Context;

        public BestellingRepository(IBestellingSQLContext context)
        {
            Context = context;
        }

       
    }
}
