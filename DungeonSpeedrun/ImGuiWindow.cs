using System.Numerics;
using Raylib_cs;
using ImGuiNET;
using static ImGuiNET.ImGui;

namespace DungeonSpeedrun;

public static class ImGuiWindow
{
  public static void Render(RenderTexture2D mainRender)
  {
    Begin("Debugger", ImGuiWindowFlags.NoMove | ImGuiWindowFlags.NoResize | ImGuiWindowFlags.NoCollapse);
    switch (Config.State)
    {
      case WindowState.Width:
        SetWindowPos(Vector2.Zero);
        SetWindowSize(new Vector2(Config.SideSpace.X * 2, mainRender.Texture.Height));
        break;
      case WindowState.Height:
        SetWindowPos(new Vector2(0, mainRender.Texture.Height));
        SetWindowSize(new Vector2(mainRender.Texture.Width, Config.SideSpace.Y * 2));
        break;
    }
    
    Text($"FPS: {Raylib.GetFPS()}");
    End();
  }
}