using MelonLoader;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using CyconiAPI;
using CyconiAPI_Template;

[assembly: MelonInfo(typeof(Class1), "CyconiAPI_Template", "0.0.1", "Cyconi")]
[assembly: MelonGame(null, "Lethal Company")]

namespace CyconiAPI_Template
{
    public class Class1 : MelonMod
    {
        public override void OnSceneWasInitialized(int buildIndex, string sceneName)
        {
            if (sceneName == "SampleSceneRelay")
                LoadMenus();
        }

        public static void LoadMenus()
        {
            MelonCoroutines.Start(WaitForMenu());

            IEnumerator WaitForMenu()
            {
                while (GameObject.Find("Systems/UI/Canvas/QuickMenu") == null) yield return null;
                yield return null;

                MenuInit();

                yield break;
            }
        }
        public static GameObject exampleMenu;
        public static GameObject quickMenu;
        public static GameObject menuButtons;
        public static GameObject settingsPanel;
        public static GameObject backButton;

        public static void MenuInit()
        {
            try
            {

                quickMenu = GameObject.Find("Systems/UI/Canvas/QuickMenu");
                menuButtons = GameObject.Find("Systems/UI/Canvas/QuickMenu/MainButtons");
                backButton = GameObject.Find("Systems/UI/Canvas/QuickMenu/SettingsPanel/BackButton");

                exampleMenu = new GameObject(name: "myMenu");
                new CyconiAPI.Menu(quickMenu.transform, exampleMenu);
                exampleMenu.SetActive(false); 

                Vector3 vector3 = new Vector3(-22.9f, - 58.48f, 12.17f);

                new CyconiAPI.Button(menuButtons.transform, "My Menu", vector3, () =>
                {
                    menuButtons.SetActive(false);
                    exampleMenu.SetActive(true);
                });

                new CyconiAPI.BackButton(exampleMenu.transform, () =>
                {
                    exampleMenu.SetActive(false);
                    menuButtons.SetActive(true);
                });

                
                new CyconiAPI.ClearButton(exampleMenu.transform, "Clear Button", 1, 1, () =>
                {

                });
                new CyconiAPI.ClearToggle(exampleMenu.transform, "Clear Button Off", "Clear Button On", 2, 1, () =>
                {
                    //on
                }, () =>
                {
                    //off
                });
                new CyconiAPI.Button(exampleMenu.transform, "Normal Button", 1, 2, () =>
                {
                    
                });
                new CyconiAPI.Toggle(exampleMenu.transform, "Normal Button Off", "Normal Button On", 2, 2, () =>
                {
                    // on
                }, () =>
                {
                    // off
                });
                
            }
            catch (Exception) { }
        }
    }
}
