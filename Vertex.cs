using System;

namespace EpocaEspecialLp2.Common
{
    public class Vertex
    {
        public char Number{ get; set;}

        public List<Vertex> Edges{get;set;}

        public Value value;

        public Vertex(char Number, Value value)
        {
            this.Number = Number;
            Edges = new List<Vertex>();
            this.value = value;
           
        }


    }

}