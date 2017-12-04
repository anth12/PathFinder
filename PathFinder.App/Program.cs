using PathFinder.LeftTurn;
using PathFinder.Map;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;

namespace PathFinder.App
{
    class Program
    {
        private static Type[] Finders = new[]
        {
            typeof(LeftTurnPathFinder)
        };

        static void Main(string[] args)
        {
            Task.Run(async () =>
            {
                await Process(args);
            }).GetAwaiter().GetResult();

#if DEBUG
            Console.ReadLine();
#endif
        }

        private static async Task Process(string[] args)
        {
            if (args.Length < 1)
            {
                Console.WriteLine("Missing maze");
                return;
            }
            if(args.Length < 2)
            {
                PrintFinders();
                return;
            }
            var finder = Finders.FirstOrDefault(f => f.Name.ToLower().Contains(args[1].ToLower()));

            if(finder == null)
            {
                PrintFinders();
                return;
            }

            var pathFinder = (IPathFinder) Activator.CreateInstance(finder);

            Maze maze;
            using(var imageStream = File.OpenRead(args[0]))
            {
                var image = new Bitmap(imageStream);
                maze = new MazeImageProcessor(image).Read();
            }

            Console.WriteLine("Starting...");
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            var solution = await pathFinder.Solve(maze);

            stopwatch.Stop();

            Console.WriteLine($"Solution found after: {stopwatch.Elapsed}");

            // Write the solution
            var solutionWriter = new SolutionWriter(maze);
            solutionWriter.WriteNextTo(args[0], solution, openAfter: true);

        }

        private static void PrintFinders()
        {
            Console.WriteLine("Please specify your desired Path Finder");
            foreach (var finderType in Finders)
                Console.WriteLine($"    {finderType.Name}");
        }
    }
}