using Raylib_cs;
using static Raylib_cs.Raylib;
namespace DungeonSpeedrun;

public static class RenderToTexture
{
  public static void Go(RenderTexture2D mainRender)
  {
    DrawRectangleLinesEx(new(0, 0, mainRender.Texture.Width, mainRender.Texture.Height), 20, Color.Red);
    DrawText("Hello, World!", 400, 200, 20, Color.Black);
  }
}