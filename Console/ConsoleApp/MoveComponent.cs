using Lp2EpocaEspecial.Common;
using System;
using System.Diagnostics.Metrics;
using System.Reflection;


namespace Lp2EpocaEspecial.ConsoleApp
{

	public class MoveComponent : Component
	{
        private int x, y;
        // Buffer where player will draw itself
        private IBuffer2D<Vertex> buffer;
        // A reference to the key reader component
        private KeyReaderComponent keyReader;

        public Map map;

        public Point point1;
        public Point point2;

        public GameModel gameModel;

        private Value valueToMove;

        



        private BackgroundComponent background;
        public MoveComponent(GameModel gameModel)
		{
            this.gameModel = gameModel;
        }

		public override void Start()
		{
			keyReader = ParentGameObject.GetComponent<KeyReaderComponent>();
            background = ParentGameObject.ParentGameObject.GetComponent<BackgroundComponent>();
            map = background.gameMap;

            
            
        }

        public override void Update()
        {
            if(gameModel.playerTurn == 1)
            {
                valueToMove = Value.White;
            }else
            {
                valueToMove = Value.Black;
            }

            if (keyReader.pieceToMove != null)
            {
                char? pieceToMove = keyReader.pieceToMove;


                foreach (Point points in map.points)
                {
                    if (points.vertex.number == pieceToMove && points.vertex.value == valueToMove)
                    {
                        
                        foreach (Point point in points.connections)
                        {
         
                            if (point.vertex.value == Value.None)
                            {


                                Swap(points, point, background.gameMap);
                                gameModel.ChangePlayer();


                                break;

                            }

                        }
                        break;
                    }
                }


            }
        }

        public void Swap(Point pointMoved, Point pointNone,Map gamemap)
        {
            Vertex temp = pointMoved.vertex;
            pointMoved.vertex = pointNone.vertex;
            pointNone.vertex = temp;


        }







    }
}