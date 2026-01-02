using UnityEngine;

namespace Code.Gameplay.Features.Weapons.Configs
{
    [CreateAssetMenu(menuName = "UrbanFight/Weapon/Config", fileName = "WeaponConfig", order = 59)]
    public class WeaponConfig : ScriptableObject
    {
        public WeaponTypeId TypeId;
        public int ShootCount;
        public float DamagePerShoot;
    }
}
