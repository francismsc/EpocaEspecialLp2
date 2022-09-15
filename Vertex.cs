namespace Lp2EpocaEspecial.Common
{
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