using System.Numerics;
using DungeonSpeedrun.utils;
using Raylib_cs;
using static Raylib_cs.Raylib;
namespace DungeonSpeedrun;

public static class UpdateProcess
{
  public static void Go(ref RenderTexture2D mainRender)
  {
    if (IsWindowResized())
      WindowHandler.RedoRenderTexture(ref mainRender);
  }
}