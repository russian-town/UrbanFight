using System.ComponentModel;

namespace Code.Gameplay.TimelineFeatures.Movements
{
    public enum MovementTypeId
    {
        None = 0,
        StepForward = 1,
        StepBack = 2,
        JumpForward = 3,
        JumpBack = 4,
        Dash = 5,
        Knockback = 6,
        FallDown = 7,
        RiseUp = 8,
        ReturnToStart = 9,
        [Description("Выпад")] Lunge = 10,
        [Description("Скольжение")] Slide = 11,
        Teleport = 12,
        Airborne = 13,
        GroundedPush = 14,
        LaunchUp = 15,
        SlamDown = 16,
        [Description("Вращение вокруг цели")] OrbitTarget = 17,
        FollowTarget = 18,
    }
}
