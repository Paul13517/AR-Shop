using System.Collections;
using UnityEngine;

public class OnCollisionOpenDoor : MonoBehaviour {

    public GameObject door;
    public float moveSpeed = 2f;
    private float closeDoor, openDoor = 90f;
    private Coroutine coroutine;

    private void OnTriggerEnter(Collider other) {
        stopRotate(other);

        if(coroutine == null && other.CompareTag("Door"))
           coroutine = StartCoroutine(RotateDoor(openDoor, true));
    }

    private void OnTriggerExit(Collider other) {
        stopRotate(other);

        if (coroutine == null && other.CompareTag("Door"))
            coroutine = StartCoroutine(RotateDoor(closeDoor, false));
    }

    IEnumerator RotateDoor(float yPos, bool needOpen) {
        if(needOpen) {
            while(door.transform.localRotation.y < yPos) {
                RotateObject(yPos);
                yield return null;
            }
        } else {
            while (door.transform.localRotation.y > yPos) {
                 RotateObject(yPos);
                 yield return null;
             }
        }
     }
     void RotateObject(float yPos) {
    door.transform.localRotation = Quaternion.Slerp(
        door.transform.localRotation,
        Quaternion.Euler(0, yPos, 0),
        moveSpeed * Time.deltaTime
        );
     } 

     void stopRotate(Collider other) {
          if (coroutine != null && other.CompareTag("Door")) {
          StopCoroutine(coroutine);
          coroutine = null;
       }


     }
}
