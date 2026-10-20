using UnityEngine;

public class KitchenObject : MonoBehaviour {
    [SerializeField] private KitchenObjectSO kitchenObjectSO;

    private IKitchenObjectParent kitchenObjectParent;

    public KitchenObjectSO GetKitchenObjectSO() {
        return kitchenObjectSO;
    }

    public void SetKitchenObjectParent(IKitchenObjectParent kitchenObjectParent) {
        if (this.kitchenObjectParent != null) { // previous kitchenObjectParent
            this.kitchenObjectParent.ClearKitchenObject();
        }

        // new kitchenObjectParent
        if (kitchenObjectParent.HasKitchenObject()) {
            Debug.LogError("KtchenObjectParent already has a KitchenObject!");
            return;
        }

        this.kitchenObjectParent = kitchenObjectParent;
        kitchenObjectParent.SetKitchenObject(this);

        //position at counter top point
        transform.parent = kitchenObjectParent.GetKitchenObjectHoldPoint();
        transform.localPosition = Vector3.zero;
    }

    public IKitchenObjectParent GetKitchenObjectParent() {
        return kitchenObjectParent;
    }

    public void DestroyThis() {
        kitchenObjectParent.ClearKitchenObject();
        Destroy(gameObject);
    }
}
