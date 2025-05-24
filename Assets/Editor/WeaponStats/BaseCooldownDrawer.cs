using NotAVampireSurvivor.Core;
using UnityEditor;

namespace NotAVampireSurvivor.Editor {
    [CustomPropertyDrawer(typeof(BaseCooldown), true)]
    public class BaseCooldownDrawer : WeaponFloatStatDrawer<BaseCooldown> {
    }
}