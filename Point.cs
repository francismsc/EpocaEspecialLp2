namespace Lp2EpocaEspecial.Common
{
	/// <summary>
	/// Points on the gameboard 
	/// connections = Each point contains a list of connected points
	/// pointNumber = The number of the point =
	/// 
	/// </summary>
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
