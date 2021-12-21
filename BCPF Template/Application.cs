using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Framework classes
using BeConsolePresentationFramework;
using BeConsolePresentationFramework.Controls;
using BeConsolePresentationFramework.Utilities;

namespace BCPF_Template
{
    public class Application : ConsolePresentation
    {
        // Declared button
        Button btn = new Button((Console.WindowWidth / 2) - 9, (Console.WindowHeight / 2) - 1, 17, 3, "Click me!");

        public Application()
        {
            // Code before initialization

            // Initialization of BCPF
            InitializeApplication();

            // Code after initialization

            // Assigned OnClick event for button
            btn.OnClick += btn_OnClick;
        }

        // OnClick event for button
        private void btn_OnClick(object sender, EventArgs e)
        {
            // Set button content
            btn.Content = "Clicked!";
        }
    }
}
