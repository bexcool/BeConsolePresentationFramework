using BeConsolePresentationFramework;
using BeConsolePresentationFramework.Controls;
using BeConsolePresentationFramework.Rendering;
using BeConsolePresentationFramework.Utilities;
using System.Diagnostics;

public class Application : ConsolePresentation
{
    TextBlock textBlock;
    int number = 0;

    public Application()
    {
        textBlock = new TextBlock(10, 20, "Testuju!");

        Button btnPlus = new Button(16, 20, "PLUS");
        btnPlus.Padding = new Thickness(2, 0, 2, 0);
        btnPlus.OnClick += BtnPlus_OnClick;

        Button btnMinus = new Button(25, 20, "MINUS");
        btnMinus.OnClick += BtnMinus_OnClick;
    }

    private void BtnMinus_OnClick(object sender, EventArgs e)
    {
        number--;
        textBlock.Content = number.ToString();
    }

    private void BtnPlus_OnClick(object sender, EventArgs e)
    {
        number++;
        textBlock.Content = number.ToString();
    }

    protected override void KeyPressed(ConsoleKey consoleKey)
    {
        if (consoleKey == ConsoleKey.Enter) textBlock.Content = "123";
    }
}