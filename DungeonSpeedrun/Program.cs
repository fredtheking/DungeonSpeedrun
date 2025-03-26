using System.Numerics;
using DungeonSpeedrun;
using DungeonSpeedrun.utils;
using Raylib_cs;
using rlImGui_cs;
using static Raylib_cs.Raylib;

// System Setup
SetConfigFlags(ConfigFlags.ResizableWindow);
InitWindow((int)Config.Resolution.X, (int)Config.Resolution.Y, "Hello, Dungeon!");
SetExitKey(KeyboardKey.Null);
rlImGui.Setup();

// Loading Variables
bool debug;
RenderTexture2D mainRender = LoadRenderTexture((int)(Config.Resolution.X - Config.SideSpace.X * 2), (int)(Config.Resolution.Y - Config.SideSpace.Y * 2));
PlayerController player = new(mainRender, new Vector3(0, 1, 0), 0.3f);

// Force Setup
WindowHandler.RedoRenderTexture(ref mainRender);
#if DEBUG
debug = true;
#endif

//Loop
while (!WindowShouldClose())
{ 
  // Process Update
  if (IsKeyPressed(KeyboardKey.Grave) || IsKeyPressed(KeyboardKey.F3)) debug = !debug;
  if (!player.CatchCursor && IsKeyPressed(KeyboardKey.Escape)) break;
  UpdateProcess.Go(ref mainRender, player, debug); 
  
  // Begin Render
  BeginDrawing();
  ClearBackground(Color.Black);
  
  // Draw Allocation
  BeginTextureMode(mainRender);
  ClearBackground(Color.DarkGray);
  RenderToTexture.Go(mainRender, player);
  EndTextureMode();
  
  // RenderTexture Render
  Rectangle windowRect = new(0, 0, mainRender.Texture.Width, -mainRender.Texture.Height);
  Vector2 position = new Vector2(Config.SideSpace.X, Config.SideSpace.Y);
  DrawTextureRec(mainRender.Texture, windowRect, debug ? position * new Vector2(2, 0) : position, Color.White);
  
  // ImGui Render
  if (debug && Config.State != WindowState.Equal)
  {
    rlImGui.Begin();
    ImGuiWindow.Render(mainRender);
    rlImGui.End();
  }
  
  // End Render
  EndDrawing();
}

// Unloading Resources
UnloadRenderTexture(mainRender);

rlImGui.Shutdown();
CloseWindow();