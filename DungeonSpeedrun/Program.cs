using ImGuiNET;
using rlImGui_cs;
using static Raylib_cs.Raylib;
using static Raylib_cs.Color;


InitWindow(1280, 720, "Hello, Dungeon!");
rlImGui.Setup();

while (!WindowShouldClose())
{
  BeginDrawing();
  rlImGui.Begin();
  ClearBackground(RayWhite);

  ImGui.Begin("halo");
  ImGui.Text("Hello, World!");
  ImGui.End();
  
  rlImGui.End();
  EndDrawing();
}

rlImGui.Shutdown();
CloseWindow();