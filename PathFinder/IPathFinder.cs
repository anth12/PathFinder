using PathFinder.Map;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PathFinder
{
    public interface IPathFinder
    {
        Task<List<Point>> Solve(Maze maze);
    }
}
