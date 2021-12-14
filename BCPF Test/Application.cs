﻿using BeConsolePresentationFramework;
using BeConsolePresentationFramework.Controls;
using BeConsolePresentationFramework.Rendering;
using BeConsolePresentationFramework.Utilities;
using System.Diagnostics;
using static BeConsolePresentationFramework.Utilities.Utilities;

public class Application : ConsolePresentation
{
    TextBlock textBlock, honza, hover, pressed, removeMe;
    TextBox textBox;
    int number = 0;
    Timer timer;

    public Application()
    {
        InitializeApplication();

        ShowDebug = true;

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

        new Border(50, 5, 10, 5, Line.SingleRound);

        //timer = new Timer(new TimerCallback(TickTimer), null, 2000, 2000);

        textBox = new TextBox(25, 10, 20, 3);
        textBox.ContentHorizontalAlignment = HorizontalAlignment.Left;

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
        (sender as Button).Content = "ZLVMN";
        textBox.Width = 10;
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