using UnityEngine;

namespace NotAVampireSurvivor.Core {
    [CreateAssetMenu(menuName = "VampSurvivor/Character")]
    public class Character : ScriptableObject {
        [Header("Character Info")]
        [SerializeField] private string characterName;
        public string Name => characterName;
        [SerializeField] private Weapon defaultWeapon;
        public Weapon DefaultWeapon => defaultWeapon;
        [SerializeField] private Sprite sprite;
        [SerializeField] private AnimationInfo idleAnimation;
        public AnimationInfo IdleAnimation => idleAnimation;
        [SerializeField] private AnimationInfo walkAnimation;
        public AnimationInfo WalkAnimation => walkAnimation;
        public Sprite Sprite => sprite;
        [SerializeField, TextArea] private string description;
        public string Description => description;
        [Header("Character Stats")]
        [SerializeField] private StatBoost[] permanentBoosts;
        [SerializeField, Range(0, 100)] private int growthPeriod;
        [SerializeField, Range(-1, 100)] private int growthLimit;
        [SerializeField] private StatBoost[] growthBoost;

        public bool HasGrowth => growthPeriod > 0;

        public void ApplyLevelGrowth(int level) {
            if (growthPeriod <= 0
            || growthBoost == null
            || growthBoost.Length < 1
            || level > growthLimit
            || level % growthPeriod != 0) {
                return;
            }

            foreach (StatBoost boost in growthBoost) {
                boost.ApplyBoost();
            }
        }

        public void ApplyInitialStats() {
            foreach (StatBoost boost in permanentBoosts) {
                boost.ApplyBoost();
            }
        }
    }
}
