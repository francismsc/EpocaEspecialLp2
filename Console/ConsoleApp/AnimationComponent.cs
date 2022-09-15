namespace Lp2EpocaEspecial.ConsoleApp
{
	/// <summary>
	/// Handles the animations and puts them inside of the buffer
	/// </summary>
    public class AnimationComponent : Component
    {
        private IBuffer2D<char> buffer;
        private int frames = 0;

		/// <param name="buffer">Receives a double buffer</param>
        public AnimationComponent(IBuffer2D<char> buffer)
        {
            this.buffer = buffer;
        }
        public override void Update()
        {
            frames++;
            for (int bufferY = 0; bufferY < buffer.YDim; bufferY++)
            {
                for (int bufferX = 0; bufferX < buffer.XDim; bufferX++)
                    switch (frames)
                    {
                        case 0:
                            buffer[bufferX, bufferY] = '/';
                            break;
                        case 1:
                            buffer[bufferX, bufferY] = '|';
                            break;
                        case 2:
                            buffer[bufferX, bufferY] = '\\';
                            break;
                        case 3:
                            buffer[bufferX, bufferY] = '-';
                            break;
                        case 4:
                            buffer[bufferX, bufferY] = '/';
                            break;
                        case 5:
                            buffer[bufferX, bufferY] = '|';
                            break;
                        case 6:
                            buffer[bufferX, bufferY] = '\\';
                            break;
                        case 7:
                            buffer[bufferX, bufferY] = '-';
                            frames = 0;
                            break;
                        default:
                            buffer[bufferX, bufferY] = 'X';
                            break;
                    }
            }
        }
    }
}
