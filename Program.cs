using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace ConsoleApp1
{
    public class MainForm : Form
    {
        private TextBox nameTextBox;
        private Button _kamButton;
        private Button _bumButton;
        private Button _nojButton;
        private TextBox resultTextBox;
        private TextBox computerChoiceTextBox;
        private Label _computerLbl;
        private Label _nameLbl;

        public MainForm()
        {
            // Настройка формы
            this.Text = "Камень, Ножницы, Бумага";
            this.Size = new Size(500, 500);

            // Поле для ввода имени Сверху -------------------------------------------------------------------------------
            nameTextBox = new TextBox
            {
                Location = new Point(230, 30),
                Width = 240,
                Font = new Font("Arial", 16),
                TextAlign = HorizontalAlignment.Center
            };
            this.Controls.Add(nameTextBox);

            _nameLbl = new Label
            {
                Text = "Ваше имя:",
                Location = new Point(30, 30),
                Width = 180,
                Font = new Font("Arial", 16),
                TextAlign = ContentAlignment.MiddleCenter
            };
            this.Controls.Add(_nameLbl);


            // Кнопка "Камень" -------------------------------------------------------------------------------------------
            _kamButton = new Button
            {
                Text = "Камень",
                Location = new Point(30, 80),
                Size = new Size(170, 60),
                Font = new Font("Arial", 10),
            };
            //Присваивание значения переменной
            _kamButton.Click += (s, e) => PlayGame("камень");
            this.Controls.Add(_kamButton);


            // Кнопка "Ножницы" ------------------------------------------------------------------------------------------
            _nojButton = new Button
            {
                Text = "Ножницы",
                Location = new Point(30, 170),
                Size = new Size(170, 60),
                Font = new Font("Arial", 10),
            };
            //Присваивание значения переменной
            _nojButton.Click += (s, e) => PlayGame("ножницы");
            this.Controls.Add(_nojButton);


            // Кнопка "Бумага" -------------------------------------------------------------------------------------------
            _bumButton = new Button
            {
                Text = "Бумага",
                Location = new Point(30, 260),
                Size = new Size(170, 60),
                Font = new Font("Arial", 10),
            };
            //Присваивание значения переменной
            _bumButton.Click += (s, e) => PlayGame("бумага");
            this.Controls.Add(_bumButton);


            //------------------------------------------------------------------------------------------------------------

            _computerLbl = new Label
            {
                Text = "Выбор компьютера:",
                Location = new Point(230, 100),
                Width = 240,
                Font = new Font("Arial", 16),
                TextAlign = ContentAlignment.MiddleCenter
            };
            this.Controls.Add(_computerLbl);


            // Выбор компьютера
            computerChoiceTextBox = new TextBox
            {
                Location = new Point(230, 185),
                Width = 240,
                ReadOnly = true,
                Font = new Font("Arial", 16),
                TextAlign = HorizontalAlignment.Center
            };
            this.Controls.Add(computerChoiceTextBox);
            // Поле для вывода результата
            
            resultTextBox = new TextBox
            {
                Location = new Point(30, 400),
                Width = 440,
                ReadOnly = true,
                Font = new Font("Arial", 24),
                TextAlign = HorizontalAlignment.Center
            };
            this.Controls.Add(resultTextBox);
            
        }

        private void PlayGame(string userChoice)
        {
            // Генерация выбора компьютера
            Random random = new Random();
            string[] choices = { "камень", "бумага", "ножницы" };
            string computerChoice = choices[random.Next(choices.Length)];

            // Обновление поля с выбором компьютера
            computerChoiceTextBox.Text = $"{computerChoice}";

            // Определение результата
            string result;
            if (userChoice == computerChoice)
            {
                result = "Ничья";
            }
            else if ((userChoice == "камень" && computerChoice == "ножницы") ||
                     (userChoice == "бумага" && computerChoice == "камень") ||
                     (userChoice == "ножницы" && computerChoice == "бумага"))
            {
                result = $"{nameTextBox.Text} Выиграл!";
            }
            else
            {
                result = $"{nameTextBox.Text} Проиграл!";
            }

            // Обновление поля результата
            resultTextBox.Text = result;

            //resultTextBox = new TextBox
            //{
            //    Location = new Point(30, 400),
            //    Width = 440,
            //    ReadOnly = true,
            //    Font = new Font("Arial", 24),
            //    TextAlign = HorizontalAlignment.Center
            //};
            //this.Controls.Add(resultTextBox);


        }

        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    
    
    
     
    
    
    
    }



}