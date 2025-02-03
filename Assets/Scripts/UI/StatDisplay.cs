using NotAVampireSurvivor.Core;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace NotAVampireSurvivor.UI {
    public class StatDisplay : MonoBehaviour {
        [SerializeField] private PlayerStat stat;
        [SerializeField] private Image image;
        [SerializeField] private TextMeshProUGUI statName;
        [SerializeField] private TextMeshProUGUI statValue;

        private UnityEvent onDestroy = new UnityEvent();

        private void OnValidate() {
            if (image != null)
                image.sprite = stat == null ? null : stat.Sprite;
            if (statName == null || statValue == null)
                return;
            if (stat == null) {
                statName.text = "None";
                statValue.text = "-";
            } else {
                statName.text = stat.name;
            }
            if (stat is TypedPlayerStat<int>) {
                TypedPlayerStat<int> intStat = stat as TypedPlayerStat<int>;
                OnValueChange(intStat.Value);
            } else if (stat is TypedPlayerStat<float>) {
                TypedPlayerStat<float> floatStat = stat as TypedPlayerStat<float>;
                OnValueChange(floatStat.Value);
            }
        }

        private void Awake() {
            image.sprite = stat.Sprite;
            statName.text = stat.name;
            if (stat is TypedPlayerStat<int>) {
                TypedPlayerStat<int> intStat = stat as TypedPlayerStat<int>;
                OnValueChange(intStat.Value);
                intStat.ObserveChanges(OnValueChange);
                onDestroy.AddListener(() => intStat.RemoveListener(OnValueChange));
            } else if (stat is TypedPlayerStat<float>) {
                TypedPlayerStat<float> floatStat = stat as TypedPlayerStat<float>;
                OnValueChange(floatStat.Value);
                floatStat.ObserveChanges(OnValueChange);
                onDestroy.AddListener(() => floatStat.RemoveListener(OnValueChange));
            }
        }

        private void OnDestroy() {
            onDestroy.Invoke();
        }

        private void OnValueChange(int number) {
            UpdateDisplay($"{number}");
        }

        private void OnValueChange(float number) {
            UpdateDisplay($"{number:0.##}");
        }

        private void UpdateDisplay(string number) {
            statValue.text = $"{stat.DisplayPrefix}{number}{stat.DisplaySuffix}";
        }
    }
}
