using NotAVampireSurvivor.Core;
using UnityEditor;

namespace NotAVampireSurvivor.Editor {
    [CustomPropertyDrawer(typeof(BaseAmount), true)]
    public class BaseAmountDrawer : WeaponIntStatDrawer<BaseAmount> {
    }
}