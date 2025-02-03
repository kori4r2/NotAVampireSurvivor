namespace NotAVampireSurvivor.Core {
    [System.Serializable]
    public struct StatBoost {
        public PlayerStat stat;
        public float increase;

        public void ApplyBoost() {
            if (stat == null)
                return;
            stat.ApplyBoost(increase);
        }

        public void ApplyBaseStat() {
            if (stat == null)
                return;
            stat.ApplyBaseStat(increase);
        }
    }
}
