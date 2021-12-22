using BeConsolePresentationFramework;
using BeConsolePresentationFramework.Controls;
using BeConsolePresentationFramework.Controls.Base;
using BeConsolePresentationFramework.Rendering;
using BeConsolePresentationFramework.Utilities;
using System.Diagnostics;
using static BeConsolePresentationFramework.Utilities.Utilities;

public class Application : ConsolePresentation
{
    TextBlock textBlock, honza, hover, pressed, removeMe, textBoxOutput;
    TextBox textBox;
    int number = 0;
    Timer timer;
    StackPanel stackPanel;
    StackPanel stackPanelTXT;

    public Application()
    {
        //ShowDebug = true;

        // Init application
        InitializeApplication();

        textBlock = new TextBlock(10, 20, "GGEGE");
        honza = new TextBlock(55, 20, "HONZA JE HONZA");
        hover = new TextBlock(55, 21, "NOT HOVERED");
        removeMe = new TextBlock(55, 23, "<-- REMOVE ME BY PRESSING THIS BUTTON!", ConsoleColor.Yellow);
        pressed = new TextBlock(55, 22, "RELEASED", ConsoleColor.Red);
        new TextBlock(55, 24, Convert.ToInt64((float)5 / 2).ToString());
        new TextBlock(55, 25, Math.Round(2.5).ToString());
        new TextBlock(55, 26, "Ahoj!\nNový řádek!");

        Button Exit = new Button(55, 15, 8, 5, "EXIT", Line.SingleDouble);
        Exit.OnClick += Exit_OnClick;
        //Exit.MousePressed += Exit_Pressed;
        Exit.Padding = new Thickness(0, 2, 0, 1);

        Button zelva = new Button(40, 20, 13, 5, "ZelvaMan", Line.SingleRound);
        zelva.OnClick += Zelva_OnClick;
        zelva.MouseEnter += Zelva_MouseEnter;
        zelva.MouseLeave += Zelva_MouseLeave;
        zelva.MousePressed += Zelva_MousePressed;
        zelva.MouseReleased += Zelva_MouseReleased;

        Button btnPlus = new Button(16, 20, 8, 5, "PLUS", Line.Double);
        btnPlus.ContentVerticalAlignment = VerticalAlignment.Top;
        btnPlus.Padding = new Thickness(4, 0, 0, 0);
        btnPlus.OnClick += BtnPlus_OnClick;

        Button btnMinus = new Button(25, 20, 9, 5, "MINUS", Line.DoubleSingle);
        btnMinus.OnClick += BtnMinus_OnClick;

        //new Border(50, 5, 10, 5, Line.SingleRound);

        timer = new Timer(new TimerCallback(TickTimer), null, 100, 100);

        textBox = new TextBox(25, 10, 40, 3);
        textBox.Line = Line.SingleRound;
        textBox.ContentHorizontalAlignment = HorizontalAlignment.Left;
        textBox.ContentChanged += TextBox_ContentChanged;
        textBox.OnClick += TextBox_OnClick;

        textBoxOutput = new TextBlock(25, 15, "Type in TextBox");


        // Stack panel file search

        stackPanel = new StackPanel(25, 4, 100, 100);
        //stackPanel.Children.Add(btnMinus);
        stackPanel.Children.Add(btnPlus);

        Button SearchBtn = new Button
        {
            Width = 10,
            Height = 3,
            Content = "Search",
            Line = Line.Double
        };

        SearchBtn.OnClick += (s, e) =>
        {
            stackPanel.Children.Clear();
            //@"C:\Users\Santa\OneDrive\Obrázky"
            List<string> list = Directory.GetFiles(textBox.Content).ToList();

            for (int i = 0; i < list.Count; i++)
            {
                stackPanel.Children.Add(new TextBlock { Content = Path.GetFileName(list[i]), Padding = new Thickness(0, 0, 0, 2) });
            }
        };

        stackPanelTXT = new StackPanel(25, 1, 40, 4);
        stackPanelTXT.Orientation = Orientation.Horizontal;
        stackPanelTXT.Children.Add(textBox);
        stackPanelTXT.Children.Add(SearchBtn);
    }

    private void Exit_Pressed(object sender, EventArgs e)
    {
        foreach (TextBlock textBlock in stackPanel.Children)
        {
            textBlock.Remove();
        }

        stackPanel.Children.Clear();
    }

    private void TextBox_OnClick(object sender, EventArgs e)
    {

    }

    private void TextBox_ContentChanged(object sender, EventArgs e)
    {

    }

    private void Exit_OnClick(object sender, EventArgs e)
    {
        Exit();
    }

    void TickTimer(object state)
    {
        honza.Content = FPS.ToString();
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
        (sender as Button).Content = "ZLVMN";
        textBoxOutput.Content = textBox.Content;
        stackPanelTXT.Visibility = Visibility.Collapsed;
    }

    private void BtnMinus_OnClick(object sender, EventArgs e)
    {
        number--;
        textBlock.Content = number.ToString();
        CheckNumberColor();
        stackPanelTXT.Visibility = Visibility.Collapsed;
    }

    private void BtnPlus_OnClick(object sender, EventArgs e)
    {
        number++;
        textBlock.Content = number.ToString();
        CheckNumberColor();
        stackPanelTXT.Visibility = Visibility.Visible;
    }

    private void CheckNumberColor()
    {
        if (number < 0) textBlock.ForegroundColor = ConsoleColor.Red;
        else if (number == 0) textBlock.ForegroundColor = ConsoleColor.White;
        else if (number > 0) textBlock.ForegroundColor = ConsoleColor.Green;
    }
}