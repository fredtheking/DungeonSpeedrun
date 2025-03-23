using System.Numerics;
using DungeonSpeedrun;
using DungeonSpeedrun.utils;
using Raylib_cs;
using rlImGui_cs;
using static Raylib_cs.Raylib;

SetConfigFlags(ConfigFlags.ResizableWindow | ConfigFlags.VSyncHint);
InitWindow((int)Config.Resolution.X, (int)Config.Resolution.Y, "Hello, Dungeon!");
SetExitKey(KeyboardKey.Null);
rlImGui.Setup();

RenderTexture2D mainRender = LoadRenderTexture((int)(Config.Resolution.X - Config.SideSpace.X * 2), (int)(Config.Resolution.Y - Config.SideSpace.Y * 2));
PlayerController player = new(mainRender, new Vector3(0, 1, 0), 0.32f);

WindowHandler.RedoRenderTexture(ref mainRender);
while (!WindowShouldClose())
{ 
  // Process Update
  if (!player.CatchCursor && IsKeyPressed(KeyboardKey.Escape))
    break;
  UpdateProcess.Go(ref mainRender, player); 
  
  BeginDrawing();
  
  // Draw Allocation
  BeginTextureMode(mainRender);
  ClearBackground(Color.DarkGray);
  
  RenderToTexture.Go(mainRender, player);
  
  EndTextureMode();
  
  // RenderTexture Render
  Rectangle windowRect = new(0, 0, mainRender.Texture.Width, -mainRender.Texture.Height);
  DrawTextureRec(mainRender.Texture, windowRect, new Vector2(Config.SideSpace.X, Config.SideSpace.Y), Color.White);
  
  // ImGui Render
  rlImGui.Begin();
  ClearBackground(Color.Black);
  
  ImGuiWindow.Render();
  
  rlImGui.End();
  EndDrawing();
}

// Unloading resources
UnloadRenderTexture(mainRender);

rlImGui.Shutdown();
CloseWindow();