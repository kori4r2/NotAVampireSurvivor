using NotAVampireSurvivor.Core;
using UnityEditor;

namespace NotAVampireSurvivor.Editor {
    [CustomPropertyDrawer(typeof(BaseArea), true)]
    public class BaseAreaDrawer : WeaponFloatStatDrawer<BaseArea> {
    }
}