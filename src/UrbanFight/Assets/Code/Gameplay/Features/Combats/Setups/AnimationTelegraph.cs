namespace Code.Gameplay.Features.Combats.Setups
{
    public class AnimationTelegraph
    {
        public TelegraphTypeId TelegraphTypeId;
        public float Intensity;
        
        public AnimationTelegraph(TelegraphTypeId telegraphTypeId, float intensity)
        {
            TelegraphTypeId = telegraphTypeId;
            Intensity = intensity;
        }
    }
}
