using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public struct Location
{
	public readonly int x, y;
	public Location(int x, int y)
	{
		this.x = x;
		this.y = y;
	}
}
public class SimpleGraph<Location>
{
	// NameValueCollection would be a reasonable alternative here, if
	// you're always using string location types
	public Dictionary<Location, Location[]> edges = new Dictionary<Location, Location[]>();

	public Location[] Neighbors(Location id)
	{
		return edges[id];
	}
}
//public struct Graph
//{
//	Dictionary<char, Vector2[]> map;
//	public Vector2[] neighbors(char id)
//	{
//		return map[id];
//	}
//}
public class BreadthFirst : MonoBehaviour 
{
	static void Search(SimpleGraph<string> graph, string start)
	{
		var frontier = new Queue<string>();
		frontier.Enqueue(start);

		var visited = new HashSet<string>();
		visited.Add(start);

		while (frontier.Count > 0)
		{
			var current = frontier.Dequeue();

			Debug.Log("Visiting "+ current);
			foreach (var next in graph.Neighbors(current))
			{
				if (!visited.Contains(next)) {
					frontier.Enqueue(next);
					visited.Add(next);
				}
			}
		}
	}

	static void Main()
	{
		SimpleGraph<string> g = new SimpleGraph<string>();
		g.edges = new Dictionary<string, string[]>
		{
			{ "A", new [] { "B" } },
			{ "B", new [] { "A", "C", "D" } },
			{ "C", new [] { "A" } },
			{ "D", new [] { "E", "A" } },
			{ "E", new [] { "B" } }
		};

		Search(g, "A");
	}
	void Start()
	{ 
		Main();
	}

}
