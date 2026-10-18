using UnityEngine;

public class SelectedCounterVIsual : MonoBehaviour {
    [SerializeField] private ClearCounter clearCounter;
    [SerializeField] private GameObject visualGameObject;

    private void Start() {
        Player.Instance.OnSelectedCounterChanged += Instance_OnSelectedCounterChanged;
    }

    private void Instance_OnSelectedCounterChanged(object sender, Player.OnSelectedCounterChangedEventArgs e) {
        if (e.selectedCounter == clearCounter) {
            ShowHighlight();
        } else {
            HideHighlight();
        }
    }

    private void ShowHighlight() {
        visualGameObject.SetActive(true);
    }

    private void HideHighlight() {
        visualGameObject.SetActive(false);
    }
}
