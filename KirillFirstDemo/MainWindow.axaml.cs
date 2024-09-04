using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Input;
using System;
using System.Globalization;

namespace KirillFirstDemo
{
    public partial class MainWindow : Window
    {
        private int contorl;
        private string name;
        private int provbutton;
        public MainWindow()
        {
            InitializeComponent();
            GridRedact(provbutton);
        }
        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            if (contorl == 0)
            { contorl = 1; provbutton = 1; name = "admin"; }
            else { contorl = 0; provbutton = 0; }
            GridRedact(provbutton);
        }
        private void ButtonClick1(object sender, RoutedEventArgs e)
        {
            if (contorl == 0)
            { contorl = 2; provbutton = 2; name = "user"; }
            else { contorl = 0; provbutton = 0; }
            GridRedact(provbutton);
        }
        private void InputTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                var textBox = sender as TextBox;
                var inputText = textBox.Text;
                if (inputText == "0000" && name == "admin")
                {
                    new FirstWindow().Show();
                    Close();
                }
                e.Handled = true;
            }
        }
        private void GridRedact(int provbutton)
        {
            var grid = new Grid();
            grid.ColumnDefinitions.Add(new ColumnDefinition(new GridLength(200, GridUnitType.Pixel)));
            grid.RowDefinitions.Add(new RowDefinition(new GridLength(25, GridUnitType.Pixel)));
            if (contorl == 1 || contorl == 2)
            {
                grid.RowDefinitions.Add(new RowDefinition(new GridLength(80, GridUnitType.Pixel)));
                var textbox = new TextBox();
                textbox.KeyDown += InputTextBox_KeyDown;
                Grid.SetRow(textbox, 1);
                grid.Children.Add(textbox);
            }
            else { grid.RowDefinitions.Add(new RowDefinition(new GridLength(0, GridUnitType.Pixel))); }
            grid.RowDefinitions.Add(new RowDefinition(new GridLength(70, GridUnitType.Pixel)));
            var textBlock = new TextBlock { Text = "Авторизация" };
            textBlock.HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Center;
            Grid.SetRow(textBlock, 0);
            grid.Children.Add(textBlock);
            var button = new Button { Content = "Админ" };
            Grid.SetRow(button, 2);
            var button1 = new Button { Content = "Клиент" };
            Grid.SetRow(button1, 2);
            if (provbutton == 1){ button1.IsEnabled = false; }
            else if (provbutton == 2) { button.IsEnabled = false; }
            else { button.IsEnabled = true; button1.IsEnabled = true; }
            button.HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Right;
            button.Click += ButtonClick;
            button1.Click += ButtonClick1;
            grid.Children.Add(button);
            grid.Children.Add(button1);
            this.Content = grid;
            grid.HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Center;
            grid.VerticalAlignment = Avalonia.Layout.VerticalAlignment.Center;
        }
    }
}