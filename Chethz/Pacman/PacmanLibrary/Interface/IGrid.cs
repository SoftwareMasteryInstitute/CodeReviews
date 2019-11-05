namespace PacmanLibrary.Interface
{
    public interface IGrid
    {
        int Width { get; set; }
        int Height { get; set; }

        bool IsValidPlace(int x, int y);
    }
}