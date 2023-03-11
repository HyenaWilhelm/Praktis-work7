using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Проводник
{
    internal class Navigation
    {
        public int position;
        int min, max;

        public Navigation(int max)
        {
            min = 0;
            this.max = max;
        }

        public void DownMove()
        {
            if (position + 1 < max)
            {
                Erase();
                Draw(++position);
            }
        }

        public void UpMove()
        {
            if (position > min)
            {
                Erase();
                Draw(--position);
            }
        }

        public void Draw(int arrow)
        {
            position = arrow;
            Console.SetCursorPosition(0, arrow);
            Console.WriteLine("->");
        }

        private void Erase()
        {
            Console.SetCursorPosition(0, position);
            Console.Write("  ");
        }
    }
}
