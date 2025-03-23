using DungeonSpeedrun.utils;
using Raylib_cs;
using static Raylib_cs.Raylib;
namespace DungeonSpeedrun;

public static class RenderToTexture
{
  public static void Go(RenderTexture2D mainRender, PlayerController player)
  {
    ClearBackground(Color.White);

    BeginMode3D(player.GetCamera());

    DrawGrid(100, 1);

    EndMode3D();
    DrawRectangleLinesEx(new(0, 0, mainRender.Texture.Width, mainRender.Texture.Height), 12, Color.Red);
  }
}