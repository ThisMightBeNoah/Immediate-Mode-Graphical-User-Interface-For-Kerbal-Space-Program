using API.DrippyDevelopment.IMGUI;
using System.Collections.Generic;
using UnityEngine;

[KSPAddon(KSPAddon.Startup.Flight | KSPAddon.Startup.SpaceCentre, false)]
public class MyKSPMod : MonoBehaviour
{
    private IMGUIWindowManager windowManager;
    private IMGUIWindow myWindow;
    private const KeyCode toggleKey = KeyCode.Minus;

    void Start()
    {
        windowManager = gameObject.AddComponent<IMGUIWindowManager>();
        CreateWindow();
    }

    void Update()
    {
        if (Input.GetKeyDown(toggleKey))
        {
            if (myWindow == null)
            {
                CreateWindow();
            }
            else
            {
                myWindow.IsVisible = !myWindow.IsVisible;
            }
        }
    }
    bool CanTroll = false;
    private void CreateWindow()
    {
        myWindow = windowManager.CreateWindow("I hate myself", new Vector2(100, 100), new Vector2(300, 400));

        // Add close button handler
        myWindow.OnCloseButton += () =>
        {
            windowManager.DestroyWindow(myWindow);
            myWindow = null;
        };

        // Add UI elements
        myWindow.AddMenuItem(new IMGUILabel("Subscribe to Drippy Development!"));
        myWindow.AddMenuItem(new IMGUIButton("Blow up a random part", () => TROLL()));
        myWindow.AddMenuItem(new IMGUIToggle("Enable Feature", CanTroll, (val) => CanTroll = true));
    }
    void TROLL()
    {
        List<Part> parts = FlightGlobals.ActiveVessel.parts;
        System.Random rnd = new System.Random();
        int r = rnd.Next(parts.Count);
        if (CanTroll == true)
        {
            Part part = FlightGlobals.ActiveVessel.parts[r];
            part.explode();
        }
        else
        {
            Application.Quit(); // Devious plan to troll the user
        }
    }
    void OnDestroy()
    {
        if (windowManager != null)
        {
            Destroy(windowManager);
        }
    }
}