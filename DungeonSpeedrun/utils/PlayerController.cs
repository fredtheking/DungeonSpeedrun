using System.Numerics;
using Raylib_cs;
using static Raylib_cs.Raylib;
namespace DungeonSpeedrun.utils;

public class PlayerController
{
  public Vector3 Position;
  public float UsualSpeed = 5f;
  public float FastSpeed = 21f;
  public float ReallySpeed = 100f;
  public float Speed;
  public float Sensitivity;
  public float Yaw;
  public float Pitch;
  public bool CatchCursor;
  private Camera3D camera;
  private RenderTexture2D mainRender;

  public PlayerController(RenderTexture2D render, Vector3 startPosition, float startSensitivity)
  {
    mainRender = render;
    Position = startPosition;
    Speed = UsualSpeed;
    Sensitivity = startSensitivity / 100f;
    camera = new Camera3D
    {
      Position = Position,
      Target = Position + new Vector3(0, 0, 1),
      Up = new Vector3(0, 1, 0),
      FovY = 70.0f,
      Projection = CameraProjection.Perspective
    };
  }

  public void CatchMouseTrigger(bool catto)
  {
    CatchCursor = catto;
    if (CatchCursor)
    {
      HideCursor();
      DisableCursor();
    }
    else
    {
      ShowCursor();
      EnableCursor();
    }
  }

  public void Update(bool debug)
  {
    Rectangle rectX = new(Config.SideSpace.X*2, 0, Config.Resolution.X, Config.Resolution.Y);
    Rectangle rectY = new(Vector2.Zero, Config.Resolution.X, Config.Resolution.Y-Config.SideSpace.Y*2);
    bool rectVerdict = debug ? CheckCollisionPointRec(GetMousePosition(), Config.State == WindowState.Width ? rectX : rectY) : true;
    
    if (rectVerdict && IsMouseButtonPressed(MouseButton.Left) && !CatchCursor) 
      CatchMouseTrigger(true);
    if (IsKeyPressed(KeyboardKey.Escape))
      CatchMouseTrigger(false);

    if (!CatchCursor) return;
    
    float deltaTime = GetFrameTime();
    Vector3 forward = Vector3.Normalize(new Vector3((float)Math.Cos(Yaw), 0, (float)Math.Sin(Yaw)));
    Vector3 right = Vector3.Normalize(new Vector3(-forward.Z, 0, forward.X));

    Speed = IsKeyDown(KeyboardKey.LeftShift) ? FastSpeed : IsKeyDown(KeyboardKey.RightShift) ? ReallySpeed : UsualSpeed;
    
    if (IsKeyDown(KeyboardKey.W)) Position += forward * Speed * deltaTime;
    if (IsKeyDown(KeyboardKey.S)) Position -= forward * Speed * deltaTime;
    if (IsKeyDown(KeyboardKey.A)) Position -= right * Speed * deltaTime;
    if (IsKeyDown(KeyboardKey.D)) Position += right * Speed * deltaTime;
    if (IsKeyDown(KeyboardKey.Space)) Position.Y += Speed * deltaTime;
    if (IsKeyDown(KeyboardKey.LeftAlt)) Position.Y -= Speed * deltaTime;
    if (IsKeyPressed(KeyboardKey.R)) Position.Y = 1;
        
    Vector2 mouseDelta = GetMouseDelta();
    Yaw += mouseDelta.X * Sensitivity;
    Pitch -= mouseDelta.Y * Sensitivity;
    Pitch = Math.Clamp(Pitch, -1.5f, 1.5f);

    Vector3 direction = new Vector3(
      (float)(Math.Cos(Pitch) * Math.Cos(Yaw)),
      (float)Math.Sin(Pitch),
      (float)(Math.Cos(Pitch) * Math.Sin(Yaw))
    );

    camera.Position = Position;
    camera.Target = Position + direction;
  }

  public Camera3D GetCamera() => camera;
}