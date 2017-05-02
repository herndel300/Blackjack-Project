using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackjackProject
{
    public class Player
    {
        public string name;
        public int handTotal;
        public int chipTotal;

    public Player()
    {
        name = " ";
        handTotal = 0;
        chipTotal = 0;
    }

    //need to add chip total eventually. do this at the end
    public Player(string name, int handTotal, int chipTotal)
    {
        this.name = name;
        this.handTotal = handTotal;
        this.chipTotal = chipTotal;
    }

    }
}
