using UnityEngine;
using UnityEngine.Events;

# Hi there!

public class UIController : MonoBehaviour
{
    public UnityEvent myEvent;

    public GameObject quitDialog;

    public void QuitApplication() {
        print("You have quit!");
        quitDialog.SetActive(false);
        Application.Quit();

    }

    public void CancelQuit() {
        quitDialog.SetActive(false);
    }

    public void Update() {
        if (Input.GetKeyDown("escape")) {
            //quitDialog.SetActive(true);
            myEvent.Invoke();
        }
    }
}
