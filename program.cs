using System;
using System.Threading;
using System.Linq;
using System.Collections.Generic;

namespace xiaomaodiaoyu
{
    class Program
    {

        static void Main(string[] args)
        {
            var list = new List<char>();

            var cards = Shuffle(InitCards());
            var player1 = cards[0..27].ToList();
            var player2 = cards[27..54].ToList();
            var count = 0;
            while (player1.Count() > 0 && player2.Count() > 0)
            {
                count++;

                while (ChuPai(ref player1, ref list))
                {

                };
                while (ChuPai(ref player2, ref list))
                {

                };

                Console.WriteLine($"Player1:{player1.Count()}, Player2:{player2.Count()}");
                if (count % 1000 == 0)
                    Thread.Sleep(1000);
            }



            if (player1.Count() > 0)
                Console.Write("Player1");
            else
                Console.Write("Player2");

            Console.WriteLine($" is WINNER, At {count}");

        }

        static bool ChuPai(ref List<char> player, ref List<char> list)
        {
            list.Insert(0, player[0]);
            player.RemoveAt(0);

            if (list[0] == 'J' && list.Count > 1)
            {
                player.AddRange(list);
                list.Clear();
                return true;
            }

            var index = list.IndexOf(list[0], 1);
            if (index > 0)
            {
                player.AddRange(list.ToArray()[0..(index + 1)]);
                list = list.ToArray()[(index + 1)..].ToList();

                return true;
            }

            return false;
        }

        private static char[] InitCards()
        {
            char[] cards =  {
                '2','3','4','5','6','7','8','9','0','J','Q','K','A',
                '2','3','4','5','6','7','8','9','0','J','Q','K','A',
                '2','3','4','5','6','7','8','9','0','J','Q','K','A',
                '2','3','4','5','6','7','8','9','0','J','Q','K','A',
                'J', 'J'
            };

            return cards;
        }

        private static char[] Shuffle(char[] cards)
        {
            Random r = new Random();
            for (var i = cards.Length - 1; i >= 0; i--)
            {
                var cardIndex = r.Next(i);
                var temp = cards[cardIndex];
                cards[cardIndex] = cards[i];
                cards[i] = temp;

            }

            return cards;
        }
    }
}
