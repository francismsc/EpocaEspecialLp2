using System;


namespace Lp2EpocaEspecial.Common
{
	public class Point
	{

		public List<Point> connections { get; set; }
		public char pointNumber { get; set; }

		public Vertex vertex { get; set; }

		public Point(char pointNumber, Vertex vertex)
		{
			this.pointNumber = pointNumber;
			connections = new List<Point>();
			this.vertex = vertex;

		}
	}
}

