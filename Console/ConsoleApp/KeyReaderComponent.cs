using System;
using System.Collections.Concurrent;
using System.Threading;

namespace Lp2EpocaEspecial.ConsoleApp
{
    // A key reader components
    // Note that this implementation is very limited, since only one game
    // object can have this component.
    // See https://github.com/fakenmc/CoreGameEngine/ for a better approach.
    public class KeyReaderComponent : Component
    {
        // Direction to move
        public char? pieceToMove { get; private set; }
        // Collection used for the input thread to communicate with the
        // component in the main thread
        private BlockingCollection<ConsoleKey>? input;
        // The input thread
        private Thread? inputThread;
        // Start is called immediately before the game loop starts
        public override void Start()
        {
            // Initially there is no Piece
            pieceToMove = null;
            // Instantiate the thread communication collection
            input = new BlockingCollection<ConsoleKey>();
            // Create and start the input thread
            inputThread = new Thread(ReadKeys);
            inputThread.Start();
            // Make sure cursor doesn't blink in the middle of the game
            Console.CursorVisible = false;
        }
        // Update is called once per frame
        public override void Update()
        {
            // A possible key that was pressed
            ConsoleKey key;
            // Was any key pressed?
            if (input != null && input.TryTake(out key))
            {
                Console.SetCursorPosition(0, 50);
                // If so, let's check out what key was pressed and set the
                // direction accordingly
                switch (key)
                {
                    case ConsoleKey.D1:
                        pieceToMove = '1';
                        break;
                    case ConsoleKey.D2:
                        pieceToMove = '2';
                        break;
                    case ConsoleKey.D3:
                        pieceToMove = '3';
                        break;
                    case ConsoleKey.D4:
                        pieceToMove = '4';
                        break;
                    case ConsoleKey.D5:
                        pieceToMove = '5';
                        break;
                    case ConsoleKey.D6:
                        pieceToMove = '6';
                        break;
                    case ConsoleKey.Escape:
                        // If the escape key was read, notify
                        // possible listeners
                        OnEscapePressed();
                        break;
                    default:
                        pieceToMove = null;
                        break;
                }
            }
            else
            {
                // If no key was pressed, set direction to none
                pieceToMove = null;
            }
        }
        // Finish() is called after the game loop terminates
        public override void Finish()
        {
            // Make sure cursor is again visible
            Console.CursorVisible = true;
            // Wait for the input thread
            inputThread?.Join();
        }
        // This method will run inside the input thread, waiting for keys to
        // be pressed
        private void ReadKeys()
        {
            ConsoleKey ck;
            do
            {
                // When a key is pressed, add it to the collection
                ck = Console.ReadKey(true).Key;
                input?.Add(ck);
            } while (ck != ConsoleKey.Escape);
        }
        // Following good practices, this method invokes the EscapePressed
        // event
        private void OnEscapePressed()
        {
            EscapePressed?.Invoke();
        }
        // Event to be invoked when the Escape key is detected
        public event Action? EscapePressed;
    }
}