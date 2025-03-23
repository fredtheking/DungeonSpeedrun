using ImGuiNET;
using Raylib_cs;

namespace DungeonSpeedrun;

public static class ImGuiWindow
{
  public static void Render(RenderTexture2D mainRender)
  {
    ImGui.Begin("halo");
    ImGui.Text("Hello, World!");
    ImGui.End();
  }
}