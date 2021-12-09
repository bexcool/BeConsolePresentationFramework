using BeConsolePresentationFramework;
using BeConsolePresentationFramework.Controls;
using BeConsolePresentationFramework.Rendering;
using BeConsolePresentationFramework.Utilities;
using System.Diagnostics;
using static BeConsolePresentationFramework.Utilities.Utilities;

public class Application : ConsolePresentation
{
    TextBlock textBlock, honza, hover, pressed, removeMe;
    int number = 0;
    Timer timer;

    public Application()
    {
        InitializeApplication();

        textBlock = new TextBlock(10, 20, "GGEGE");
        honza = new TextBlock(55, 20, "HONZA JE HONZA");
        hover = new TextBlock(55, 21, "NOT HOVERED");
        removeMe = new TextBlock(55, 23, "<-- REMOVE ME BY PRESSING THIS BUTTON!", ConsoleColor.Yellow);
        pressed = new TextBlock(55, 22, "RELEASED", ConsoleColor.Red);
        new TextBlock(55, 24, Convert.ToInt64((float)5 / 2).ToString());
        new TextBlock(55, 25, Math.Round(2.5).ToString());

        Button Exit = new Button(55, 15, "EXIT", ConsoleColor.Red);
        Exit.OnClick += Exit_OnClick;

        BeforeRender += Application_BeforeRender;
        AfterRender += Application_AfterRender;
        Loaded += Application_Loaded;

        Button zelva = new Button(40, 20, "ZelvaMan");
        zelva.Padding = new Thickness(2, 0, 5, 0);
        zelva.OnClick += Zelva_OnClick;
        zelva.MouseEnter += Zelva_MouseEnter;
        zelva.MouseLeave += Zelva_MouseLeave;
        zelva.MousePressed += Zelva_MousePressed;
        zelva.MouseReleased += Zelva_MouseReleased;
        zelva.Visibility = Visibility.Hidden;

        Button btnPlus = new Button(16, 20, "PLUS");
        btnPlus.Padding = new Thickness(2, 0, 2, 0);
        btnPlus.OnClick += BtnPlus_OnClick;

        Button btnMinus = new Button(25, 20, "MINUS");
        btnMinus.OnClick += BtnMinus_OnClick;

        timer = new Timer(new TimerCallback(TickTimer), null, 2000, 2000);

    }

    private void Application_Loaded(object sender, EventArgs e)
    {
        Debug.WriteLine("Loaded");
    }

    private void Application_AfterRender(object sender, EventArgs e)
    {
        Debug.WriteLine("After");
    }

    private void Application_BeforeRender(object sender, EventArgs e)
    {
        Debug.WriteLine("Before");
    }

    private void Exit_OnClick(object sender, EventArgs e)
    {
        Exit();
    }

    void TickTimer(object state)
    {
        honza.Content = "TICK BRACHO!!!";

        // Call for refreshing UI to show new TextBlock content
        RefreshRender();

        timer.Dispose();
    }

    private void Zelva_MouseReleased(object sender, EventArgs e)
    {
        pressed.ForegroundColor = ConsoleColor.Red;
        pressed.Content = "RELEASED";
    }

    private void Zelva_MousePressed(object sender, EventArgs e)
    {
        pressed.ForegroundColor = ConsoleColor.White;
        pressed.Content = "PRESSED";
    }

    private void Zelva_MouseLeave(object sender, EventArgs e)
    {
        hover.Content = "NOT HOVERED";
    }

    private void Zelva_MouseEnter(object sender, EventArgs e)
    {
        hover.Content = "HOVERED";
    }

    private void Zelva_OnClick(object sender, EventArgs e)
    {
        honza.Content = "ZelvaMan";
        removeMe.Remove();
        (sender as Button).Visibility = Visibility.Visible;
    }

    private void BtnMinus_OnClick(object sender, EventArgs e)
    {
        number--;
        textBlock.Content = number.ToString();
        CheckNumberColor();
    }

    private void BtnPlus_OnClick(object sender, EventArgs e)
    {
        number++;
        textBlock.Content = number.ToString();
        CheckNumberColor();
    }

    private void CheckNumberColor()
    {
        if (number < 0) textBlock.ForegroundColor = ConsoleColor.Red;
        else if (number == 0) textBlock.ForegroundColor = ConsoleColor.White;
        else if (number > 0) textBlock.ForegroundColor = ConsoleColor.Green;
    }
}