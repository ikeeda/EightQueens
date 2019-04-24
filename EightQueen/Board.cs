using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EightQueens
{
    /// <summary>
    /// ボード
    /// </summary>
    class Board
    {
        public Board(int num)
        {
            if (num <= 3)
                throw new ArgumentOutOfRangeException(nameof(num));

            Height = num;
            Width = num;
        }

        public int Height { get; }

        public int Width { get; }


        public IEnumerable<Result> Analyze()
        {
            var queens = Enumerable.Range(1, Width)
                .Select(x => new Queen(x, 1))
                .ToArray();

            var ls = new List<Result>();
            Analyze(queens, 0, ls);

            return ls.Distinct().ToList();
        }

        private void Analyze(Queen[] queens, int index, List<Result> successes)
        {
            var queen = queens[index];
            for (int y = 1; y <= Height; y++)
            {
                var q = queens[index].SetY(y);
                queens[index] = q;

                if (Queen.HitTestWithLeft(q, queens))
                    continue;

                if (index == queens.Length - 1)
                {
                    successes.Add(
                        new Result(queens.ToArray()));
                    continue;
                }

                if (queens.Length - 1 > index)
                    Analyze(queens.ToArray(), index + 1, successes);

                if (index == 0)
                    Console.WriteLine($"{y}/{queens.Count()}");
            }
        }

    }
}
