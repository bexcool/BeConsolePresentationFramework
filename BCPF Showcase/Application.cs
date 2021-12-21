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
        // Declared Buttons
        Button
            ContinueButton = new Button(5, 10, 13, 3, "Continue", new Thickness(0, 0, 0 ,1), Line.Double, HorizontalAlignment.Left),
            CreditsButton = new Button(5, 13, 13, 3, "Credits", new Thickness(0, 0, 0, 1), HorizontalAlignment.Left),
            ExitButton = new Button(5, 16, 13, 3, "Exit", new Thickness(0, 0, 0, 1), HorizontalAlignment.Left);

        // Declared Borders
        Border
            WelcomeBorder = new Border(5, 3, 40, 5, Line.SingleRound);

        // Declared TextBlocks
        TextBlock
            WelcomeTextBlock = new TextBlock(12, 5, "Welcome to BCPF showcase!");

        // Declared StackPanel
        StackPanel
            MainMenuStackPanel = new StackPanel(5, 10, 13, 20);

        public Application()
        {
            // Initialization of BCPF
            InitializeApplication();

            // Code after initialization

            // Assigning events
            ContinueButton.OnClick += Continue_OnClick;
            CreditsButton.OnClick += CreditsButton_OnClick;
            ExitButton.OnClick += ExitButton_OnClick;

            // Add children to Stack Panels
            MainMenuStackPanel.Children.Add(ContinueButton);
            MainMenuStackPanel.Children.Add(CreditsButton);
            MainMenuStackPanel.Children.Add(ExitButton);
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
