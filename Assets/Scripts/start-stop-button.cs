using UnityEngine;
using UnityEngine.UI;

public class ChildYChecker : MonoBehaviour
{
    [SerializeField] private GameObject targetObject; // The object whose function you want to call
    [SerializeField] private GameObject stopObject;
    [SerializeField] private string functionName = "TargetFunction"; // The name of the function to call
    [SerializeField] private bool running = false;


    // Starts the button
    private void OnEnable()
    {
        CallFunctionOnTarget(targetObject);
        running = true;
    }

    // Stops the button
    private void OnDisable() {
        if (running) {
            running = false;
            CallFunctionOnTarget(stopObject);
        }
    }

    private void CallFunctionOnTarget(GameObject obj)
    {
        if (obj != null)
        {
            Button button = obj.GetComponent<Button>();
            if (button != null) {
                button.onClick.Invoke();
            }
        }
        else
        {
            Debug.LogWarning("Target object is not assigned.");
        }
    }
}
