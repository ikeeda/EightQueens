using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace EightQueens
{
    /// <summary>
    /// 結果
    /// </summary>
    class Result
    {
        public Result(IEnumerable<Queen> resultPoints)
        {
            ResultPoints = resultPoints
                .OrderBy(a=>a.X).ThenBy(a=>a.Y)
                .ToArray();
        }

        public IEnumerable<Queen> ResultPoints { get; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach(var item in ResultPoints)
                sb.Append(item).Append(" | ");
            return sb.ToString();
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Result other))
                return false;
            if (this.ResultPoints.Count() != other.ResultPoints.Count())
                return false;
            for(int i = 0; i < this.ResultPoints.Count(); i++)
            {
                if (!this.ResultPoints.ElementAt(i).Equals(other.ResultPoints.ElementAt(i)))
                    return false;
            }
            return true;
        }

        public override int GetHashCode()
        {
            return ToString()?.GetHashCode() ?? 0;
        }
    }
}
