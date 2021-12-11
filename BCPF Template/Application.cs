using System;
using System.Collections.Generic;
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
        // Declared button (Don't create here "new Button();")
        Button btn;

        public Application()
        {
            // Code before initialization (Do not create controls before initialization!)

            // Initialization of BCPF
            InitializeApplication();

            // Code after initialization

            // Created new button
            btn = new Button(10, 15, 10, 3, "Click me!");

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
