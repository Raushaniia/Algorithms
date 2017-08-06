using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphAlgorithms
{
    static class Program
    {
        static void Main(string[] args)
        {
            var graph = Graph.MakeGraph(
                0, 1,
                0, 2,
                1, 3,
                1, 4,
                2, 3,
                3, 4);


            Console.WriteLine(graph[0]
                .DepthSearch()
                .Select(z => z.NodeNumber.ToString())
                .Aggregate((a, b) => a + " " + b));
            

            Console.WriteLine(graph[0]
                .BreadthSearch()
                .Select(z => z.NodeNumber.ToString())
                .Aggregate((a, b) => a + " " + b));
            Console.ReadLine();



        }
        public static IEnumerable<Node> DepthSearch(this Node startNode)
        {
            var visited = new HashSet<Node>();
            var stack = new Stack<Node>();
            visited.Add(startNode);
            stack.Push(startNode);
            while (stack.Count != 0)
            {
                var node = stack.Pop();
                yield return node;
                foreach (var nextNode in node.IncidentNodes.Where(n => !visited.Contains(n)))
                {
                    visited.Add(nextNode);
                    stack.Push(nextNode);
                }
            }
        }

        public static IEnumerable<Node> BreadthSearch(this Node startNode)
        {
            var visited = new HashSet<Node>();
            var queue = new Queue<Node>();
            visited.Add(startNode);
            queue.Enqueue(startNode);
            while (queue.Count != 0)
            {
                var node = queue.Dequeue();
                yield return node;
                foreach (var nextNode in node.IncidentNodes.Where(n => !visited.Contains(n)))
                {
                    visited.Add(nextNode);
                    queue.Enqueue(nextNode);
                }

            }
        }
    }

}
