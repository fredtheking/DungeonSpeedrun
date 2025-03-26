using System.Numerics;

namespace DungeonSpeedrun;

public enum WindowState : byte
{
  None,
  Width,
  Height,
  Equal
}

public static class Config
{
  public static Vector2 Resolution = new(1920, 1080);
  public static Vector2 SideSpace;
  public static WindowState State;
}