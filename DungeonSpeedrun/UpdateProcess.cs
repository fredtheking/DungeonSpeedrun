using System.Numerics;
using Raylib_cs;
using static Raylib_cs.Raylib;
namespace DungeonSpeedrun;

public static class UpdateProcess
{
  public static void Go(RenderTexture2D mainRender)
  {
    if (IsWindowResized())
    {
      UnloadRenderTexture(mainRender);
      Vector2 windowSize = new Vector2(GetRenderWidth(), GetRenderHeight());
      Console.WriteLine($"new window size: {windowSize}");
      mainRender = LoadRenderTexture((int)windowSize.X, (int)windowSize.Y);
    }
  }
}