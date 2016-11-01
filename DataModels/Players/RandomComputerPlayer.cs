using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataModels
{
    public class RandomComputerPlayer : PlayerBase
    {
        public RandomComputerPlayer()
            : base() 
        {
            Name = "RandCP";
        }

        public override IMove Move()
        {
            return generateRandomMove();
        }
    }
}
