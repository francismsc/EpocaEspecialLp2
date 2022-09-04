namespace EpocaEspecialLp2.ConsoleApp
{ 
    public interface IBuffer2D<T>
    {
        int XDim { get; }
        int YDim { get; }
        T this[int x, int y] { get; set; }
    }
}
