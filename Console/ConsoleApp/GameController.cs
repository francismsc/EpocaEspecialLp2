using System;
using System.Diagnostics.Metrics;
using System.Numerics;
using Lp2EpocaEspecial.Common;


namespace Lp2EpocaEspecial.ConsoleApp
{
	public class GameController
	{
        private readonly GameModel gameModel;
        private bool running = false;
        private ICollection<IGameObject> gameObjectsP1;
        private ICollection<IGameObject> gameObjectsP2;
        public List<Point> vertexList;
        public Map gameMap;
        private int msPerFrame = 100;

        private DoubleBuffer2D<Point> buffer2D;
        private DoubleBuffer2D<char> animationbuffer;

        private const int worldDimX = 3, worldDimY = 3;

        public GameObject player1, player2;
        

        public GameController(GameModel gameModel)
		{
            this.gameModel = gameModel;
            gameObjectsP1 = new List<IGameObject>();
            gameObjectsP2 = new List<IGameObject>();
            buffer2D = new DoubleBuffer2D<Point>(3, 3);
            animationbuffer = new DoubleBuffer2D<char>(1, 1);
            SetupScene();



        }

        public void RunGame(IGameView gameView)
        {

            Console.Clear();
            running = true;
            int previous = DateTime.Now.Millisecond;
            gameModel.playerTurn = 1;
            foreach (GameObject gObj in gameObjectsP1) gObj.Start();
            foreach (GameObject gObj in gameObjectsP2) gObj.Start();
            while (running)
            {
                int start = DateTime.Now.Millisecond;
                if(gameModel.CheckWinCondition())
                {
                    GameEnded(gameModel);
                }
                CheckPlayerTurn(gameModel);

                Render(gameView);


                Thread.Sleep(
                    start + msPerFrame - DateTime.Now.Millisecond);




 
            }

            foreach (GameObject gObj in gameObjectsP1) gObj.Finish();
            foreach (GameObject gObj in gameObjectsP2) gObj.Finish();
        }

       

        public void SetupScene()
        {
            GameObject animation;
            animation = new GameObject("Animation");
            animation.AddComponent(new AnimationComponent(animationbuffer));
            gameObjectsP1.Add(animation);
            gameObjectsP2.Add(animation);

            GameObject background, player1,player2;
            KeyReaderComponent krc;
            gameMap = gameModel.SetupMap();
            krc = new KeyReaderComponent();

            background = new GameObject("Background");

            background.AddComponent(
                new BackgroundComponent(buffer2D, worldDimX, worldDimY, gameMap));
            player1 = new GameObject("Player1");
            player1.AddComponent(krc);
            player1.AddComponent(new MoveComponent(gameModel));
            player2 = new GameObject("Player2");
            player2.AddComponent(krc);
            player2.AddComponent(new MoveComponent(gameModel));

            background.AddChildGameobject(player1);
            background.AddChildGameobject(player2);

            gameObjectsP2.Add(player2);
            gameObjectsP1.Add(player1);
            gameObjectsP1.Add(background);
            gameObjectsP2.Add(background);

            
        }

        public void Render(IGameView gameView)
        {

            
            buffer2D.Swap();
            animationbuffer.Swap();
            


            gameView.RenderMap(buffer2D);
            gameView.RenderAnimation(animationbuffer);

            
        }

        public void GameEnded(GameModel gameModel)
        {
            gameModel.OnGameEnd();
        }

        public void CheckPlayerTurn(GameModel gameModel)
        {
            switch (gameModel.playerTurn)
            {
                case 1:
                    Player1Turn();


                    break;
                case 2:
                    Player2Turn();
                    break;

            }
        }




        public void ShowPlayer1TurnAction()
        {
            gameModel.OnPlayer1Turn();      
        }

        public void ShowPlayer2TurnAction()
        {
            gameModel.OnPlayer2Turn();
        }



        public void Player1Turn()
        {
            foreach (IGameObject gObj in gameObjectsP1) gObj.Update();        
        }

        public void Player2Turn()
        {
            foreach (IGameObject gObj in gameObjectsP2) gObj.Update();
        }



    }
}
