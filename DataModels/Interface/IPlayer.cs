using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels
{
    public interface IPlayer
    {
        string Name { get; set; }
        List<IMove> PlayedMoves { get; set; }
        int WinCount { get; set; }
        IMove Move();
    }
}
