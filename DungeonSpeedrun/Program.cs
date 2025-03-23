using System.Numerics;
using DungeonSpeedrun;
using DungeonSpeedrun.utils;
using Raylib_cs;
using rlImGui_cs;
using static Raylib_cs.Raylib;

SetConfigFlags(ConfigFlags.ResizableWindow | ConfigFlags.VSyncHint);
InitWindow((int)Config.Resolution.X, (int)Config.Resolution.Y, "Hello, Dungeon!");
rlImGui.Setup();

RenderTexture2D mainRender = LoadRenderTexture((int)(Config.Resolution.X - Config.SideSpace.X * 2), (int)(Config.Resolution.Y - Config.SideSpace.Y * 2));

WindowHandler.RedoRenderTexture(ref mainRender);
while (!WindowShouldClose())
{ 
  // Process Update
  UpdateProcess.Go(ref mainRender); 
  
  BeginDrawing();
  
  // Draw Allocation
  BeginTextureMode(mainRender);
  ClearBackground(Color.DarkGray);
  
  RenderToTexture.Go(mainRender);
  
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

rlImGui.Shutdown();
CloseWindow();