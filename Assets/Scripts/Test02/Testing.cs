using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Testing : MonoBehaviour
{
    [SerializeField]private TextMeshProUGUI logText;

    [SerializeField]private Color color1;
    [SerializeField]private Color color2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TestOVRInput();
    }

    private void TestOVRInput()
    {
        // returns true if the primary button (typically “A”) is currently pressed.
        //if(OVRInput.Get(OVRInput.Button.One))
            //logText.text = "Estás pulsando el botón A";

        // returns true if the primary button (typically “A”) was pressed this frame.
        if(OVRInput.GetDown(OVRInput.Button.One))
        {
            if(logText.color == color1)
                logText.color = color2;
            else
                logText.color = color1;
            
            logText.text = "A";
            OVRInput.SetControllerVibration(1, 1, OVRInput.Controller.RTouch);
            IEnumerator coroutine = DisableVibration(0.5f);
            StartCoroutine(coroutine);
        }

        // returns true if the “X” button was released this frame.
        if(OVRInput.GetUp(OVRInput.RawButton.X))
        {
            if(logText.color == color1)
                logText.color = color2;
            else
                logText.color = color1;
            
            logText.text = "X";
        }

        // returns a Vector2 of the primary (typically the Left) thumbstick’s current state.
        // (X/Y range of -1.0f to 1.0f)
        // OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);

        // returns true if the primary thumbstick is currently pressed (clicked as a button)
        // OVRInput.Get(OVRInput.Button.PrimaryThumbstick);

        // returns true if the primary thumbstick has been moved upwards more than halfway.
        // (Up/Down/Left/Right - Interpret the thumbstick as a D-pad).
        if(OVRInput.Get(OVRInput.Button.PrimaryThumbstickUp))       
            logText.text = "Arriba";
        if(OVRInput.Get(OVRInput.Button.PrimaryThumbstickDown))       
            logText.text = "Abajo";
        if(OVRInput.Get(OVRInput.Button.PrimaryThumbstickLeft))       
            logText.text = "Izquierda";
        if(OVRInput.Get(OVRInput.Button.PrimaryThumbstickRight))       
            logText.text = "Derecha";
       

        // returns a float of the secondary (typically the Right) index finger trigger’s current state.
        // (range of 0.0f to 1.0f)
        // OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger);

        // returns a float of the left index finger trigger’s current state.
        // (range of 0.0f to 1.0f)
        // OVRInput.Get(OVRInput.RawAxis1D.LIndexTrigger);

        // returns true if the left index finger trigger has been pressed more than halfway.
        // (Interpret the trigger as a button).
        if(OVRInput.Get(OVRInput.RawButton.LIndexTrigger))
        {
            logText.text = "Gatillo apretado +1/2";
        }

        // returns true if the secondary gamepad button, typically “B”, is currently touched by the user.
        if(OVRInput.Get(OVRInput.Touch.Two))
            logText.text = "B";
    }

    private IEnumerator DisableVibration(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.RTouch);
    }
}
