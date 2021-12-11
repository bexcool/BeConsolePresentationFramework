// Framework classes
using BeConsolePresentationFramework;
using BeConsolePresentationFramework.Controls;
using BeConsolePresentationFramework.Rendering;
using BeConsolePresentationFramework.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BeConsolePresentationFramework.Utilities.Utilities;

namespace BCPF_Showcase
{
    public class Application : ConsolePresentation
    {
        // Declared button (Don't create here "new Button();")
        Button ContinueButton, CreditsButton, ExitButton;

        public Application()
        {
            // Code before initialization (Do not create controls before initialization!)

            // Initialization of BCPF
            InitializeApplication();

            // Code after initialization
            ContinueButton = new Button(5, 10, 13, 3, "Continue", new Thickness(0, 0, 0 ,1), Alignment.Left);
            CreditsButton = new Button(5, 13, 13, 3, "Credits", new Thickness(0, 0, 0, 1), Alignment.Left);
            ExitButton = new Button(5, 16, 13, 3, "Exit", new Thickness(0, 0, 0, 1), Alignment.Left);

            // Assigning events
            ContinueButton.OnClick += Continue_OnClick;
            CreditsButton.OnClick += CreditsButton_OnClick;
            ExitButton.OnClick += ExitButton_OnClick;
        }

        private void ExitButton_OnClick(object sender, EventArgs e)
        {
            Exit();
        }

        private void CreditsButton_OnClick(object sender, EventArgs e)
        {

        }

        // OnClick event for button
        private void Continue_OnClick(object sender, EventArgs e)
        {
            // Set button content
            ContinueButton.Content = "Clicked!";
        }
    }
}
