namespace Code.Gameplay.Common.Random
{
  public class UnityRandomService : IRandomService
  {
    private const float MinChance = 0f;
    private const float MaxChance = 1f;
    
    public float GetChance() => UnityEngine.Random.Range(MinChance, MaxChance);
    
    public float Range(float inclusiveMin, float inclusiveMax) => 
      UnityEngine.Random.Range(inclusiveMin, inclusiveMax);

    public int Range(int inclusiveMin, int exclusiveMax) => 
      UnityEngine.Random.Range(inclusiveMin, exclusiveMax);
  }
}