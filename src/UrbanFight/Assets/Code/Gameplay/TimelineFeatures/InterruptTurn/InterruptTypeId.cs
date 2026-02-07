using System.ComponentModel;

namespace Code.Gameplay.TimelineFeatures.InterruptTurn
{
    public enum InterruptTypeId
    {
        None = 0,
        [Description("Оглушение")] Stun = 1,
        [Description("Сбили с ног")] Knockdown = 2,
        [Description("Умер")] Death = 3,
        [Description("Пропуск хода/Паралич")] Shock = 4,
        [Description("Отмена способности")] Cancel = 5,
        [Description("Контратака")] Counter = 6,
        [Description("Системная остановка (Например, конец раунда)")] ForcedStop = 7,
        [Description("Реакция на удар")] HitReaction = 8,
        [Description("Пробили блок")] GuardBreak = 9,
        [Description("Подбросили")] AirLaunch = 10,
        [Description("Притяжение")] Pull = 11,
        [Description("Оттолкнули")] Push = 12,
        [Description("Заморозка")] Freeze = 13,
        [Description("Потеря контроля")] Fear = 14,
    }
}
