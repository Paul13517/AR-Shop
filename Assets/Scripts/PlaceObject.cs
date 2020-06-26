using UnityEngine;

public class PlaceObject : MonoBehaviour {

    public GameObject midAir;

    private void OnMouseUpAsButton() {
        midAir.SetActive(true);

    }
}
