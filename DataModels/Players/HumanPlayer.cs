using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataModels
{
    public class HumanPlayer : PlayerBase
    {
        public HumanPlayer(int indice) : base() 
        {
            Name = string.Format("Human {0}", indice);
        }

        public override IMove Move()
        {
            string input = string.Empty;
            while (!Enum.GetNames(typeof(MoveType)).Contains(input))
            {
                Console.Write("{0}, {1}", Name, Constants.ENTER_YOUR_MOVE);
                input = Console.ReadLine();
            }
            Type t = Type.GetType(string.Format("{0}.{1}", 
                Assembly.GetExecutingAssembly().GetName().Name,
                input));
            IMove move = Activator.CreateInstance(t) as IMove;
            PlayedMoves.Add(move);
            return move;
        }

    }
}
