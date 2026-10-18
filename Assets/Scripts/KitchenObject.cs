using UnityEngine;

public class KitchenObject : MonoBehaviour {
    [SerializeField] private KitchenObjectSO kitchenObjectSO;

    private ClearCounter clearCounter;

    public KitchenObjectSO GetKitchenObjectSO() {
        return kitchenObjectSO;
    }

    public void SetClearCounter(ClearCounter clearCounter) {
        if (this.clearCounter != null) { // previous clearCounter
            this.clearCounter.ClearKitchenObject();
        }

        // new clearCounter
        if (clearCounter.HasKitchenObject()) {
            Debug.LogError("Counter already has a KitchenObject!");
            return;
        }

        this.clearCounter = clearCounter;
        clearCounter.SetKitchenObject(this);

        //position at counter top point
        transform.parent = clearCounter.GetCounterTopPoint();
        transform.localPosition = Vector3.zero;
    }

    public ClearCounter GetClearCounter() {
        return clearCounter;
    }
}
