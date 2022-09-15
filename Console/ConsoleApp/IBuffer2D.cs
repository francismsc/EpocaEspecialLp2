namespace Lp2EpocaEspecial.ConsoleApp
{
    /// <summary>
    /// Interface of the doubleBuffer
    /// </summary>
    /// <typeparam name="T">generic type</typeparam>
    public interface IBuffer2D<T>
    {
        int XDim { get; }
        int YDim { get; }
        T this[int x, int y] { get; set; }
    }
}
