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
      Vector2 actualSize = windowSize with { X = windowSize.X - Config.SideSpace*2 };
      Console.WriteLine($"new window size: {windowSize}\ndetermined window size: {actualSize}");
      mainRender = LoadRenderTexture((int)actualSize.X, (int)actualSize.Y);
    }
  }
}