namespace DungeonSpeedrun.utils;

public class LevelGenerator
{
  private string[] files;
  
  public LevelGenerator(params string[] filenames)
  {
    files = filenames;
  }

  public void Generate(int index)
  {
    string current = files[index];
    Console.WriteLine(current);
  }
}