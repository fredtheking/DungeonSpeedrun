using System.Numerics;
using DungeonSpeedrun.utils;
using Raylib_cs;
using static Raylib_cs.Raylib;
namespace DungeonSpeedrun;

public static class UpdateProcess
{
  public static void Go(ref RenderTexture2D mainRender, PlayerController player, bool debug)
  {
    if (IsWindowResized())
      WindowHandler.RedoRenderTexture(ref mainRender);
    player.Update(debug);
    Config.Resolution = new Vector2(GetRenderWidth(), GetRenderHeight());
  }
}