using NotAVampireSurvivor.Core;
using UnityEditor;

namespace NotAVampireSurvivor.Editor {
    [CustomPropertyDrawer(typeof(BaseDamage), true)]
    public class BaseDamageDrawer : WeaponIntStatDrawer<BaseDamage> {
    }
}