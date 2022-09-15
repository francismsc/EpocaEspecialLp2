using Lp2EpocaEspecial.Common;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Lp2EpocaEspecial.ConsoleApp
{
    /// <summary>
    /// The game loop of the game and the one who setups the game, passes
    /// the information to the gameModel/gameObjects and to the view for display
    /// </summary>
    public class GameController
    {
        private readonly GameModel gameModel;
        private bool running = false;
        private ICollection<IGameObject> gameObjectsP1;
        private ICollection<IGameObject> gameObjectsP2;
        private int msPerFrame = 60;
        private DoubleBuffer2D<Point> buffer2D;
        private DoubleBuffer2D<char> animationbuffer;
        private const int worldDimX = 3, worldDimY = 3;
        private Map gameMap;
        public GameController(GameModel gameModel)
        {
            this.gameModel = gameModel;
            gameObjectsP1 = new List<IGameObject>();
            gameObjectsP2 = new List<IGameObject>();
            buffer2D = new DoubleBuffer2D<Point>(3, 3);
            animationbuffer = new DoubleBuffer2D<char>(30, 1);
            gameMap = SetupMap();
            SetupScene();
        }
        /// <summary>
        /// GameLoop of the game
        /// </summary>
        /// <param name="gameView"></param>
        public void RunGame(IGameView gameView)
        {
            Console.Clear();
            running = true;
            int previous = DateTime.Now.Millisecond;
            gameModel.playerTurn = 1;
            gameView.Start();
            foreach (GameObject gObj in gameObjectsP1) gObj.Start();
            foreach (GameObject gObj in gameObjectsP2) gObj.Start();
            while (running)
            {
                int start = DateTime.Now.Millisecond;
                if (gameModel.CheckWinCondition(gameMap))
                {
                    GameEnded(gameModel);
                }
                CheckPlayerTurn(gameModel);
                Render(gameView);
                if (start + msPerFrame - DateTime.Now.Millisecond >= 0)
                {
                    Thread.Sleep(
                    start + msPerFrame - DateTime.Now.Millisecond);
                }
            }
            foreach (GameObject gObj in gameObjectsP1) gObj.Finish();
            foreach (GameObject gObj in gameObjectsP2) gObj.Finish();
        }
        /// <summary>
        /// Setups the scene by creating the GameObjects and adding the components
        /// </summary>
        public void SetupScene()
        {
            GameObject animation;
            GameObject player1, player2;
            GameObject background;
            animation = new GameObject("Animation");
            animation.AddComponent(new AnimationComponent(animationbuffer));
            gameObjectsP1.Add(animation);
            gameObjectsP2.Add(animation);
            ShowPlayer1TurnAction();
            KeyReaderComponent krc;
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
            krc.EscapePressed += () =>
            {
                running = false;
                MenuModel menuModel = new MenuModel();
                MenuController menuController = new MenuController(menuModel);
                MenuView menuView = new MenuView(menuController, menuModel);
                menuController.RunMenu(menuView);
            };
        }

        /// <summary>
        /// Swaps doublebuffer and calls the view to display all changes
        /// </summary>
        /// <param name="gameView">gameview of our game</param>
        public void Render(IGameView gameView)
        {
            buffer2D.Swap();
            animationbuffer.Swap();
            gameView.ShowEscapeMessage();
            gameView.RenderMap(buffer2D);
            gameView.RenderAnimation(animationbuffer);
        }
        /// <summary>
        /// calls gameModel if the game ends
        /// </summary>
        /// <param name="gameModel">GameModel of our game</param>
        public void GameEnded(GameModel gameModel)
        {
            gameModel.OnGameEnd();
        }
        /// <summary>
        /// Checks who is playing and calls the method to update the GameObjects
        /// </summary>
        /// <param name="gameModel"></param>
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
        /// <summary>
        /// Calls method to invoke an event
        /// </summary>
        public void ShowPlayer1TurnAction()
        {
            gameModel.OnPlayer1Turn();
        }
        /// <summary>
        /// Calls method to invoke an event
        /// </summary>
        public void ShowPlayer2TurnAction()
        {
            gameModel.OnPlayer2Turn();
        }
        /// <summary>
        /// Updates the GameObjects of Player1 (White pieces)
        /// </summary>
        public void Player1Turn()
        {
            foreach (IGameObject gObj in gameObjectsP1) gObj.Update();
        }
        /// <summary>
        /// Updates the GameObjects of Player2 (Black pieces)
        /// </summary>
        public void Player2Turn()
        {
            foreach (IGameObject gObj in gameObjectsP2) gObj.Update();
        }
        /// <summary>
        /// Setups the map of the game
        /// </summary>
        /// <returns>map of the game</returns>
        public Map SetupMap()
        {
            Vertex vertex1 = new Vertex('1', Value.Black);
            Vertex vertex2 = new Vertex('9', Value.OutofGame);
            Vertex vertex3 = new Vertex('2', Value.White);
            Vertex vertex4 = new Vertex('3', Value.White);
            Vertex vertex5 = new Vertex('8', Value.None);
            Vertex vertex6 = new Vertex('4', Value.Black);
            Vertex vertex7 = new Vertex('5', Value.Black);
            Vertex vertex8 = new Vertex('9', Value.Connection);
            Vertex vertex9 = new Vertex('6', Value.White);
            List<Point> points = new List<Point>();
            Point point1 = new Point('1', vertex1);
            Point point2 = new Point('2', vertex3);
            Point point3 = new Point('3', vertex4);
            Point point4 = new Point('4', vertex5);
            Point point5 = new Point('5', vertex6);
            Point point6 = new Point('6', vertex7);
            Point point7 = new Point('7', vertex9);
            Point point8 = new Point('8', vertex2);
            Point point9 = new Point('9', vertex8);
            points.Add(point1);
            points.Add(point8);
            points.Add(point2);
            points.Add(point3);
            points.Add(point4);
            points.Add(point5);
            points.Add(point6);
            points.Add(point9);
            points.Add(point7);
            point1.connections.Add(point3);
            point1.connections.Add(point4);
            point2.connections.Add(point5);
            point2.connections.Add(point4);
            point3.connections.Add(point1);
            point3.connections.Add(point4);
            point3.connections.Add(point6);
            point4.connections.Add(point1);
            point4.connections.Add(point2);
            point4.connections.Add(point3);
            point4.connections.Add(point5);
            point4.connections.Add(point6);
            point4.connections.Add(point7);
            point5.connections.Add(point2);
            point5.connections.Add(point4);
            point5.connections.Add(point7);
            point6.connections.Add(point3);
            point6.connections.Add(point4);
            point6.connections.Add(point7);
            point7.connections.Add(point4);
            point7.connections.Add(point5);
            point7.connections.Add(point6);
            gameMap = new Map(points);
            return gameMap;
        }
    }
}
