using System.Numerics;
using Raylib_cs;
using static Raylib_cs.Raylib;

namespace DungeonSpeedrun.utils;

public static class WindowHandler
{
  public static void RedoRenderTexture(ref RenderTexture2D mainRender)
  {
    UnloadRenderTexture(mainRender);
    
    Vector2 windowSize = new(GetRenderWidth(), GetRenderHeight());
    Vector2 actualSize = new();
    
    Vector2 yLower = windowSize with { X = 1.33333333333f * windowSize.Y };
    Vector2 xLower = windowSize with { Y = 0.75f * windowSize.X };
    
    // this formula tool WAY too long...
    if (windowSize.X < windowSize.Y || yLower.X > xLower.X)
    {
      actualSize = xLower;
      Config.State = WindowState.Height;
    }
    else if (windowSize.Y < windowSize.X)
    {
      actualSize = yLower;
      Config.State = WindowState.Width;
    }
    else
    {
      actualSize = windowSize;
      Config.State = WindowState.Equal;
    }
    
    Config.SideSpace = new Vector2((windowSize.X - actualSize.X)/2, (windowSize.Y - actualSize.Y)/2);
    
    Console.WriteLine($"yLower: {yLower}\nxLower: {xLower}\nnew window size: {windowSize}\ndetermined window size: {actualSize}");
    mainRender = LoadRenderTexture((int)actualSize.X, (int)actualSize.Y);
  }
}