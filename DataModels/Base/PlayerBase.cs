using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataModels
{
    public abstract class PlayerBase : IPlayer
    {
        public string Name { get; set; }
        public List<IMove> PlayedMoves { get; set; }
        public int WinCount { get; set; }
        public PlayerBase()
        {
            WinCount = 0;
            PlayedMoves = new List<IMove>();
        }
        public abstract IMove Move();

        protected IMove generateRandomMove()
        {
            Random rnd = new Random();
            MoveType typeOfMove = (MoveType)rnd.Next(3);
            return createMoveFromType(typeOfMove);
        }

        protected IMove createMoveFromType(MoveType typeOfMove)
        {
            Type t = Type.GetType(string.Format("{0}.{1}",
                                Assembly.GetExecutingAssembly().GetName().Name,
                                typeOfMove.ToString()));

            IMove move = Activator.CreateInstance(t) as IMove;
            PlayedMoves.Add(move);
            Console.WriteLine("{0}{1}{2}", Name, Constants.COMPUTER_MOVE, move.TypeOfMove);
            return move;
        }

    }
}
