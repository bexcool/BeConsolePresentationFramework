// Framework classes
using BCPF;
using BCPF.Core;
using BCPF.Core.Controls;
using BCPF.Core.Rendering;
using BCPF.Core.Rendering.Style;
using BCPF.Core.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BCPF.Core.Utilities.Utilities;

namespace BCPF.Showcase
{
    public class Application : ConsolePresentation
    {
        // Declared Buttons
        Button
            ContinueButton = new Button(5, 10, 13, 3, "Continue", new Thickness(0, 0, 0, 1), new BorderStyle(Line.Double), HorizontalAlignment.Left),
            CreditsButton = new Button(5, 13, 13, 3, "Credits", new Thickness(0, 0, 0, 1), HorizontalAlignment.Left),
            ExitButton = new Button(5, 16, 13, 3, "Exit", new Thickness(0, 0, 0, 1), new BorderStyle(Line.DoubleSingle), HorizontalAlignment.Left),
            BackToMainMenuButton = new Button(0, 0, 16, 3, "Back", new Thickness(0, 0, 0, 1), new BorderStyle(Line.DoubleSingle), HorizontalAlignment.Left),
            BackToShowcasesButton = new Button(0, 0, 13, 3, "Back", new Thickness(0, 0, 0, 1), new BorderStyle(Line.DoubleSingle), HorizontalAlignment.Left),
            TextBlockShowcaseButton = new Button(0, 0, 16, 3, "Text", new Thickness(0, 0, 0, 1), HorizontalAlignment.Left),
            ButtonShowcaseButton = new Button(0, 0, 16, 3, "Button", new Thickness(0, 0, 0, 1), HorizontalAlignment.Left),
            BorderShowcaseButton = new Button(0, 0, 16, 3, "Border", new Thickness(0, 0, 0, 1), HorizontalAlignment.Left),
            TextBoxShowcaseButton = new Button(0, 0, 16, 3, "Text Box", new Thickness(0, 0, 0, 1), HorizontalAlignment.Left),
            StackPanelShowcaseButton = new Button(0, 0, 16, 3, "Stack Panel", new Thickness(0, 0, 0, 1), HorizontalAlignment.Left);

        // Declared Borders
        Core.Controls.Border
            NavigationBorder = new Core.Controls.Border()
            {
                X = 5,
                Y = 3,
                Width = 45,
                Height = 5,
                BorderStyle = new BorderStyle(Line.SingleRound),
                Content = "Welcome to BCPF showcase!"
            },
            ShowcaseBackgroundBorder = new Core.Controls.Border()
            {
                X = 37,
                Y = 3,
                BorderStyle = new BorderStyle(Line.SingleRound)
            };

        // Declared TextBlocks
        TextBlock
            ShowcaseNavTextBlock = new TextBlock(0, 0, "Text Block - Showcase");

        // Declared StackPanel
        StackPanel
            MainMenuStackPanel = new StackPanel(5, 10, 13, 20),
            ShowcasesStackPanel = new StackPanel(5, 10, 13, 20),
            ShowcasesRow1StackPanel = new StackPanel { Orientation = Orientation.Horizontal, Height = 3, Spacing = 1 },
            ShowcasesRow2StackPanel = new StackPanel { Orientation = Orientation.Horizontal, Height = 3, Spacing = 1 },
            ShowcasesRow3StackPanel = new StackPanel { Orientation = Orientation.Horizontal, Height = 3, Spacing = 1 },
            ShowcaseNavStackPanel = new StackPanel(5, 5, 13, 20),
            ShowcaseContentStackPanel = new StackPanel(40, 5, 13, 20);

        public Application()
        {
            // Initialization of BCPF
            InitializeApplication();

            // Code after initialization

            // Set colors to controls
            ExitButton.ForegroundColor = ConsoleColor.Red;

            // Assigning events
            // Main Menu
            ContinueButton.OnClick += Continue_OnClick;
            CreditsButton.OnClick += CreditsButton_OnClick;
            ExitButton.OnClick += ExitButton_OnClick;
            // Showcases
            BackToMainMenuButton.OnClick += BackToMainMenuButton_OnClick;
            BackToShowcasesButton.OnClick += BackToShowcasesButton_OnClick;
            TextBlockShowcaseButton.OnClick += TextBlockShowcaseButton_OnClick;
            ButtonShowcaseButton.OnClick += ButtonShowcaseButton_OnClick;
            BorderShowcaseButton.OnClick += BorderShowcaseButton_OnClick;
            TextBoxShowcaseButton.OnClick += TextBoxShowcaseButton_OnClick;
            StackPanelShowcaseButton.OnClick += StackPanelShowcaseButton_OnClick;

            // Add children to Stack Panels
            // Main Menu
            MainMenuStackPanel.Children.Add(ContinueButton);
            MainMenuStackPanel.Children.Add(CreditsButton);
            MainMenuStackPanel.Children.Add(ExitButton);
            // Showcases
            ShowcasesStackPanel.Children.Add(ShowcasesRow1StackPanel);
            ShowcasesStackPanel.Children.Add(ShowcasesRow2StackPanel);
            ShowcasesStackPanel.Children.Add(ShowcasesRow3StackPanel);
            ShowcasesRow1StackPanel.Children.Add(TextBlockShowcaseButton);
            ShowcasesRow1StackPanel.Children.Add(ButtonShowcaseButton);
            ShowcasesRow1StackPanel.Children.Add(BorderShowcaseButton);
            ShowcasesRow2StackPanel.Children.Add(TextBoxShowcaseButton);
            ShowcasesRow2StackPanel.Children.Add(StackPanelShowcaseButton);
            ShowcasesRow3StackPanel.Children.Add(BackToMainMenuButton);
            // Showcase
            ShowcaseNavStackPanel.Children.Add(ShowcaseNavTextBlock);
            ShowcaseNavStackPanel.Children.Add(BackToShowcasesButton);

            // Prepare showcases
            // Preparing Stack Panels
            ShowcasesStackPanel.Visibility = Visibility.Collapsed;
            ShowcaseNavStackPanel.Visibility = Visibility.Collapsed;
            ShowcaseNavStackPanel.Spacing = 1;
            ShowcaseContentStackPanel.Visibility = Visibility.Collapsed;
            ShowcaseContentStackPanel.Spacing = 1;
            // Prepare borders
            ShowcaseBackgroundBorder.Visibility = Visibility.Collapsed;
        }

        private void ExitButton_OnClick(object sender, EventArgs e)
        {
            Exit();
        }

        private void CreditsButton_OnClick(object sender, EventArgs e)
        {

        }

        // Switching between pages
        private void Continue_OnClick(object sender, EventArgs e)
        {
            // Show showcases page
            NavigationBorder.Content = "Select showcase.";
            MainMenuStackPanel.Visibility = Visibility.Collapsed;
            ShowcasesStackPanel.Visibility = Visibility.Visible;
        }

        private void BackToMainMenuButton_OnClick(object sender, EventArgs e)
        {
            // Show main menu
            NavigationBorder.Content = "Welcome to BCPF showcase!";
            MainMenuStackPanel.Visibility = Visibility.Visible;
            ShowcasesStackPanel.Visibility = Visibility.Collapsed;
        }

        // Switching between showcases
        private void BackToShowcasesButton_OnClick(object sender, EventArgs e)
        {
            // Show showcase menu
            NavigationBorder.Content = "Select showcase.";

            ShowcaseBackgroundBorder.Visibility = Visibility.Collapsed;
            ShowcaseContentStackPanel.Visibility = Visibility.Collapsed;
            NavigationBorder.Visibility = Visibility.Visible;
            ShowcasesStackPanel.Visibility = Visibility.Visible;
            ShowcaseNavStackPanel.Visibility = Visibility.Collapsed;
        }

        private void ShowShowcase()
        {
            ShowcaseContentStackPanel.Children.Clear();
            NavigationBorder.Visibility = Visibility.Collapsed;
            ShowcasesStackPanel.Visibility = Visibility.Collapsed;
            ShowcaseNavStackPanel.Visibility = Visibility.Visible;
            ShowcaseContentStackPanel.Visibility = Visibility.Visible;
            ShowcaseBackgroundBorder.Visibility = Visibility.Visible;
        }

        private void TextBlockShowcaseButton_OnClick(object sender, EventArgs e)
        {
            ShowcaseNavTextBlock.Content = "Text Block - Showcase";

            ShowcaseBackgroundBorder.Width = 75;
            ShowcaseBackgroundBorder.Height = 20;

            ShowShowcase();
            
            ShowcaseContentStackPanel.Children.Add(new TextBlock { Content = "Text Block with one line:", ForegroundColor = ConsoleColor.Cyan });
            ShowcaseContentStackPanel.Children.Add(new TextBlock { Content = "Hello! I'm text block with one line." });
            ShowcaseContentStackPanel.Children.Add(new TextBlock { Content = @"Text Block with multiple lines (Split with '\n'):", ForegroundColor = ConsoleColor.Cyan });
            ShowcaseContentStackPanel.Children.Add(new TextBlock { Content = "Hello! I'm the 1st line.\nI'm the 2nd line!\nAnd I'm the 3rd line!" } );
            ShowcaseContentStackPanel.Children.Add(new TextBlock { Content = "// This is code example of multiline TextBlock\nStackPanel.Children.Add(new TextBlock \n{ Content = \"Hello! I'm the 1st line.\\nI'm the 2nd line!\\n\nAnd I'm the 3rd line!\" } );", Language = SyntaxHighlight.ProgrammingLanguage.CS });
        }

        private void ButtonShowcaseButton_OnClick(object sender, EventArgs e)
        {
            ShowcaseNavTextBlock.Content = "Button - Showcase";

            ShowcaseBackgroundBorder.Width = 75;
            ShowcaseBackgroundBorder.Height = 20;

            ShowShowcase();
        }

        private void StackPanelShowcaseButton_OnClick(object sender, EventArgs e)
        {
            ShowcaseNavTextBlock.Content = "Stack Panel - Showcase";
            ShowShowcase();

            ShowcaseBackgroundBorder.Width = 75;
            ShowcaseBackgroundBorder.Height = 20;
        }

        private void TextBoxShowcaseButton_OnClick(object sender, EventArgs e)
        {
            ShowcaseNavTextBlock.Content = "Text Box - Showcase";
            ShowShowcase();

            ShowcaseBackgroundBorder.Width = 75;
            ShowcaseBackgroundBorder.Height = 20;
        }

        private void BorderShowcaseButton_OnClick(object sender, EventArgs e)
        {
            ShowcaseNavTextBlock.Content = "Border - Showcase";
            ShowShowcase();

            ShowcaseBackgroundBorder.Width = 75;
            ShowcaseBackgroundBorder.Height = 20;
        }
    }
}
