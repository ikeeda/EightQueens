using System;
using System.Collections.Generic;

namespace EightQueens
{
    /// <summary>
    /// 座標
    /// </summary>
    class Queen
    {
        public Queen(int x = 1, int y = 1)
        {
            if (x <= 0)
                throw new ArgumentOutOfRangeException(nameof(x));
            if (y <= 0)
                throw new ArgumentOutOfRangeException(nameof(y));
            Y = y;
            X = x;
        }

        public int Y { get; }
        public int X { get; }


        public bool HitTest(Queen other)
        {
            if (this.X == other.X)
                return true;
            if (this.Y == other.Y)
                return true;

            //絶対値でXとYの差が同じ場合は斜めの位置と同じこと
            return Math.Abs(this.X - other.X) == Math.Abs(this.Y - other.Y);
        }

        public Queen SetY(int y)
        {
            return new Queen(this.X, y);
        }

        public override bool Equals(object obj)
        {
            if (obj is Queen other)
                return this.X == other.X && this.Y == other.Y;
            return false;
        }

        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        public static bool HitTestWithLeft(Queen target, IEnumerable<Queen> queens)
        {
            foreach (var item in queens)
            {
                if (item == target)
                    continue;
                if (item.X >= target.X)
                    continue;

                if (target.HitTest(item))
                    return true;
            }
            return false;
        }

        public override string ToString()
        {
            return $"X:{X}, Y:{Y}";
        }
    }
}
