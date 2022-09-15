namespace Lp2EpocaEspecial.Common
{
    /// <summary>
    /// The more specific data of a point
    /// value = value of the piece ex: Black or White
    /// number = number of the vertex
    /// </summary>
    public class Vertex
    {
        public char number { get; set; }
        public Value value;
        public Vertex(char number, Value value)
        {
            this.number = number;
            this.value = value;
        }
    }
}