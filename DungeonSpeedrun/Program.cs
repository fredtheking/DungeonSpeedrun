using System.Numerics;
using DungeonSpeedrun;
using Raylib_cs;
using rlImGui_cs;
using static Raylib_cs.Raylib;

SetConfigFlags(ConfigFlags.ResizableWindow | ConfigFlags.VSyncHint);
InitWindow((int)Config.Resolution.X, (int)Config.Resolution.Y, "Hello, Dungeon!");
rlImGui.Setup();

RenderTexture2D mainRender = LoadRenderTexture(1280, 720);

while (!WindowShouldClose())
{ 
  UpdateProcess.Go(mainRender); 
  
  BeginDrawing();
  rlImGui.Begin();
  ClearBackground(Color.Black);
  
  ImGuiWindow.Render(mainRender);
  
  rlImGui.End();
  
  BeginTextureMode(mainRender);
  ClearBackground(Color.DarkGray);
  
  RenderToTexture.Go(mainRender);
  
  EndTextureMode();
  DrawTextureRec(mainRender.Texture, new(0, 0, mainRender.Texture.Width, -mainRender.Texture.Height), Vector2.Zero, Color.White);
  EndDrawing();
}

rlImGui.Shutdown();
CloseWindow();