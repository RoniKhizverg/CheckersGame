using Client.Model;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class checkersBoard : Form
    {
        clientDbDataContext _context = new clientDbDataContext();
        private static HttpClient client = new HttpClient();
        private const string BaseUrl = "https://localhost:44359/";
        public List<(GamePosition, int)> Positions = new List<(GamePosition, int)>();
        const int mapSize = 8;
        const int cellSize = 55;
        int eatenBlack = 0;
        int eatenWhite = 0;
        Player player;
        Model.Game gameRestore = null;
        private bool restoreGame = false;
        Stopwatch timer = new Stopwatch();
        int durationGame;

        int currentPlayer;

        List<PictureBox> simpleSteps = new List<PictureBox>();
        int server = 0;
        int countEatSteps = 0;
        PictureBox prevButton;
        PictureBox pressedButton;
        bool isContinue = false;
        bool endGame = false;
        bool isMoving;

        int[,] Board = new int[mapSize, mapSize];

        PictureBox[,] buttons = new PictureBox[mapSize, mapSize];

        Image whiteFigure;
        Image blackFigure;
        Image blackCheatFigure;
        Image whiteCheatFigure;
        Random srand = new Random();
        bool isServerTurn;
        public WinForm winform;
        private string winner;

        public checkersBoard(Player pl)
        {
            InitializeComponent();
            player = pl;
            restoreGame = false;
            whiteFigure = Properties.Resources.whiteSoldier;
            blackFigure = Properties.Resources.blackSoldier;
            blackCheatFigure = Properties.Resources.cheat;
            whiteCheatFigure = Properties.Resources.whiteCheat;
            this.startButton.Visible = true;
            client.BaseAddress = new Uri(BaseUrl);
            this.btnGamesList.Visible = true;

            this.Text = "Checkers";
            timer.Start();
            Init();
        }

        public checkersBoard(Player pl, Model.Game gameRestore)
        {
            InitializeComponent();
            player = pl;
            restoreGame = false;
            whiteFigure = Properties.Resources.whiteSoldier;
            blackFigure = Properties.Resources.blackSoldier;
            blackCheatFigure = Properties.Resources.cheat;
            whiteCheatFigure = Properties.Resources.whiteCheat;
            this.startButton.Visible = true;
            this.Text = "Checkers";
            if (client.BaseAddress == null)
            {
                client.BaseAddress = new Uri(BaseUrl);
            }
            this.btnGamesList.Visible = true;
            this.gameRestore = gameRestore;


            Init();
        }

        public void Init()
        {
            endGame = false;
            eatenBlack = 0;
            eatenWhite = 0;
            this.ScoreLableBlack.Text = eatenBlack.ToString();
            this.ScoreLableWhite.Text = eatenWhite.ToString();
            currentPlayer = srand.Next(1, 3);
            if (currentPlayer == 1)
                server = 2;
            else
                server = 1;
            if (server == 2)
            {
                nameTextBox2.Text = "server";
                nameTextBox1.Text = player.Name;
                textBox3.Text = player.NumOfGames.ToString();
                label3.Visible = false;
                textBox1.Visible = false;

            }
            else
            {
                nameTextBox1.Text = "Server";
                nameTextBox2.Text = player.Name;
                textBox1.Text = player.NumOfGames.ToString();
                label4.Visible = false;
                textBox3.Visible = false;



            }

            isMoving = false;
            prevButton = null;

            Board = new int[mapSize, mapSize] { // 0 represent blank square, 1 represent white soldier, 2 represent black soldier.
                { 0,1,0,1,0,1,0,1 },
                { 1,0,1,0,1,0,1,0 },
                { 0,1,0,1,0,1,0,1 },
                { 0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0 },
                { 2,0,2,0,2,0,2,0 },
                { 0,2,0,2,0,2,0,2 },
                { 2,0,2,0,2,0,2,0 }
            };

            CreateMap();
        }

        public void ResetGame()
        {
            bool player1 = false;
            bool player2 = false;

            for (int i = 0; i < mapSize; i++)
            {
                for (int j = 0; j < mapSize; j++)
                {
                    if (Board[i, j] != server && Board[i, j] != 0)
                        player1 = true;
                    if (Board[i, j] == server)
                        player2 = true;
                }
            }
            if (!player2)
            {
                timer.Stop();
                durationGame = (int)(timer.ElapsedMilliseconds / 1000);
                winner = player.Name;
                endGame = true;
                winform = new WinForm(player);
                winform.decalreTheWinner(winner);
                PostEndGame();
                saveGame();
                winform.Show();
                this.Visible = false;
                timer.Reset();

            }
            if (!player1)
            {
                timer.Stop();
                durationGame = (int)(timer.ElapsedMilliseconds / 1000);
                endGame = true;
                winform = new WinForm(player);
                winform.decalreTheWinner("server");
                winform.Show();
                this.Visible = false;
                timer.Reset();

            }



        }

        public void CreateMap()
        {


            for (int i = 0; i < mapSize; i++)
            {
                for (int j = 0; j < mapSize; j++)
                {
                    PictureBox button = new PictureBox();
                    button.Location = new Point(j * cellSize, i * cellSize);
                    button.Size = new Size(cellSize, cellSize);
                    button.Click += new EventHandler(OnFigurePress);
                    if (Board[i, j] == 1)
                        button.Image = whiteFigure;
                    else if (Board[i, j] == 2) button.Image = blackFigure;
                    button.SizeMode = PictureBoxSizeMode.StretchImage;

                    button.BackColor = GetPrevButtonColor(button);
                    button.ForeColor = Color.Gray;

                    buttons[i, j] = button;

                    this.panel1.Controls.Add(button);
                }
            }
            DeactivateAllButtons();
        }

        public void SwitchPlayer()
        {

            currentPlayer = currentPlayer == 1 ? 2 : 1;
            ResetGame();
        }
        public void checkIfServerTurn()
        {
            int canMoove = 0;
            EventArgs e = new EventArgs();
            PictureBox p2 = new PictureBox();

            if (currentPlayer == server)
            {

                do
                {
                    int i = srand.Next(0, mapSize);
                    int j = srand.Next(0, mapSize);
                    PictureBox p = new PictureBox();
                    p = buttons[i, j];
                    if (p.Enabled == true)
                    {
                        OnFigurePress(p, e);
                        for (int x = 0; x < mapSize; x++)
                        {
                            for (int y = 0; y < mapSize; y++)
                            {
                                if (buttons[x, y].BackColor == Color.Yellow)
                                {
                                    p2 = buttons[x, y];
                                    OnFigurePress(p2, e);
                                    canMoove = 1;
                                    x = 0;
                                    y = 0;
                                }

                            }
                        }

                        if (canMoove == 0)
                        {
                            OnFigurePress(p, e);

                        }
                    }


                }
                while (canMoove == 0);
            }

        }




        public Color GetPrevButtonColor(PictureBox prevButton)
        {
            if ((prevButton.Location.Y / cellSize % 2) != 0)
            {
                if ((prevButton.Location.X / cellSize % 2) == 0)
                {
                    return Color.Black;
                }
            }
            if ((prevButton.Location.Y / cellSize) % 2 == 0)
            {
                if ((prevButton.Location.X / cellSize) % 2 != 0)
                {
                    return Color.Black;
                }
            }
            return Color.White;
        }

        public void OnFigurePress(object sender, EventArgs e)
        {
            isServerTurn = false;

            if (prevButton != null)
                prevButton.BackColor = GetPrevButtonColor(prevButton);

            pressedButton = sender as PictureBox;
            if (!restoreGame)
            {
                GamePosition position = new GamePosition { x = pressedButton.Location.Y / cellSize, y = pressedButton.Location.X / cellSize };
                Positions.Add((position, currentPlayer));
            }

            //we check if the pressed picturebox is not blank square and the soldier belongs to player 
            if (Board[pressedButton.Location.Y / cellSize, pressedButton.Location.X / cellSize] != 0 && Board[pressedButton.Location.Y / cellSize, pressedButton.Location.X / cellSize] == currentPlayer)
            {
                ClearSteps();
                pressedButton.BackColor = Color.Gray; // sign the picturebox pressed.
                DeactivateAllButtons(); // deactivate all the picturebox except the pressed button
                pressedButton.Enabled = true;
                countEatSteps = 0;
                if (pressedButton.Text == "D")
                    ShowSteps(pressedButton.Location.Y / cellSize, pressedButton.Location.X / cellSize, false);
                else ShowSteps(pressedButton.Location.Y / cellSize, pressedButton.Location.X / cellSize);

                // enable us to press again on the same sqaure pressed              
                if (isMoving)
                {
                    ClearSteps();
                    pressedButton.BackColor = GetPrevButtonColor(pressedButton);
                    ShowPossibleSteps();
                    isMoving = false;
                }
                else

                    isMoving = true;
            }
            // ןf we did a legal step.
            else
            {
                if (isMoving)
                {
                    isContinue = false;
                    if (Math.Abs(pressedButton.Location.X / cellSize - prevButton.Location.X / cellSize) > 1) // we eat a tasty soldier.
                    {
                        isContinue = true; // we have one more step!! (:
                        DeleteEaten(pressedButton, prevButton); // delete the eaten soldier


                    }
                    if (currentPlayer == server)
                        System.Threading.Thread.Sleep(1000);
                    int temp = Board[pressedButton.Location.Y / cellSize, pressedButton.Location.X / cellSize];// the position of the pressed button

                    //like swap -> update the new position of the soldier.
                    Board[pressedButton.Location.Y / cellSize, pressedButton.Location.X / cellSize] = Board[prevButton.Location.Y / cellSize, prevButton.Location.X / cellSize];
                    Board[prevButton.Location.Y / cellSize, prevButton.Location.X / cellSize] = temp; // now its blank square
                    pressedButton.Image = prevButton.Image;
                    prevButton.Image = null;
                    pressedButton.Text = prevButton.Text;
                    prevButton.Text = "";


                    SwitchButtonToCheat(pressedButton);// check if cheat or not

                    countEatSteps = 0;
                    isMoving = false;
                    ClearSteps();
                    DeactivateAllButtons();
                    //check if we have additions eat steps
                    if (pressedButton.Text == "D")
                        ShowSteps(pressedButton.Location.Y / cellSize, pressedButton.Location.X / cellSize, false);
                    else ShowSteps(pressedButton.Location.Y / cellSize, pressedButton.Location.X / cellSize);
                    //if there are no eat steps
                    if (countEatSteps == 0 || !isContinue)
                    {
                        ClearSteps();
                        SwitchPlayer();
                        ShowPossibleSteps();
                        isContinue = false;
                        prevButton = pressedButton;
                        if (!endGame)
                            checkIfServerTurn();
                        if (currentPlayer == server)
                            isServerTurn = true;


                    }
                    // if there are eat steps 
                    else if (isContinue)
                    {
                        pressedButton.BackColor = Color.Gray;
                        pressedButton.Enabled = true;
                        isMoving = true;
                    }
                }
            }
            if (isServerTurn == false)
                prevButton = pressedButton;


        }

        public void ShowPossibleSteps()
        {
            bool isOneStep = true;
            bool isEatStep = false;
            DeactivateAllButtons();
            for (int i = 0; i < mapSize; i++)
            {
                for (int j = 0; j < mapSize; j++)
                {
                    if (Board[i, j] == currentPlayer)
                    {
                        if (buttons[i, j].Text == "D")
                            isOneStep = false;
                        else
                            isOneStep = true;
                        if (IsButtonHasEatStep(i, j, isOneStep, new int[2] { 0, 0 }))
                        {
                            isEatStep = true;
                            buttons[i, j].Enabled = true;
                        }
                    }
                }
            }
            if (!isEatStep)
            {
                ActivateAllButtons();

            }
        }

        public void SwitchButtonToCheat(PictureBox button)
        {
            //if we reach to the last y of the board and there is white soldier
            if (Board[button.Location.Y / cellSize, button.Location.X / cellSize] == 1 && button.Location.Y / cellSize == mapSize - 1)
            {
                button.Image = whiteCheatFigure;
                button.SizeMode = PictureBoxSizeMode.StretchImage;
                button.BackColor = Color.Black;
                button.Text = "D";// D represent the cheat.

            }
            //if we reach to the first y of the board and there is black soldier
            if (Board[button.Location.Y / cellSize, button.Location.X / cellSize] == 2 && button.Location.Y / cellSize == 0)
            {
                button.Image = blackCheatFigure;
                button.SizeMode = PictureBoxSizeMode.StretchImage;
                button.BackColor = Color.Black;
                button.Text = "D";// D represent the cheat.
            }
        }

        public void DeleteEaten(PictureBox endButton, PictureBox startButton)
        {
            int count = Math.Abs(endButton.Location.Y / cellSize - startButton.Location.Y / cellSize); // the total distance that the soldeir pass.
            int startIndexX = endButton.Location.Y / cellSize - startButton.Location.Y / cellSize;
            int startIndexY = endButton.Location.X / cellSize - startButton.Location.X / cellSize;
            startIndexX = startIndexX < 0 ? -1 : 1;// if the step is with the y-axis direction start index x =1
            startIndexY = startIndexY < 0 ? -1 : 1;// if the step is with the x-axis direction start index x =2
            int currCount = 0;
            // i, j are the coords of the eaten soldier.
            int i = startButton.Location.Y / cellSize + startIndexX;
            int j = startButton.Location.X / cellSize + startIndexY;
            //delete the eaten soldier
            if (Board[i, j] == 1)//for updateing eaten White soldier
            {
                eatenWhite++;
                this.ScoreLableWhite.Text = eatenWhite.ToString();
            }
            else//for updateing eaten Black soldier
            {
                eatenBlack++;
                this.ScoreLableBlack.Text = eatenBlack.ToString();
            }

            while (currCount < count - 1)
            {
                Board[i, j] = 0; // blank sqaure
                buttons[i, j].Image = null; // no soldier
                buttons[i, j].Text = ""; // no text
                i += startIndexX;
                j += startIndexY;
                currCount++;


            }

        }



        public void ShowSteps(int iCurrFigure, int jCurrFigure, bool isOnestep = true)
        {
            simpleSteps.Clear();
            ShowDiagonal(iCurrFigure, jCurrFigure, isOnestep);
            if (countEatSteps > 0)
                CloseSimpleSteps(simpleSteps);
        }

        public void ShowDiagonal(int IcurrFigure, int JcurrFigure, bool isOneStep = false)
        {
            int j = JcurrFigure + 1;
            for (int i = IcurrFigure - 1; i >= 0; i--)
            {
                if (currentPlayer == 1 && isOneStep && !isContinue) break;
                if (IsInsideBorders(i, j))
                {
                    if (!DeterminePath(i, j))
                        break;
                }
                if (j < 7)
                    j++;
                else break;

                if (isOneStep)
                    break;
            }

            j = JcurrFigure - 1;
            for (int i = IcurrFigure - 1; i >= 0; i--)
            {
                if (currentPlayer == 1 && isOneStep && !isContinue) break;
                if (IsInsideBorders(i, j))
                {
                    if (!DeterminePath(i, j))
                        break;
                }
                if (j > 0)
                    j--;
                else break;

                if (isOneStep)
                    break;
            }

            j = JcurrFigure - 1;
            for (int i = IcurrFigure + 1; i < 8; i++)
            {
                if (currentPlayer == 2 && isOneStep && !isContinue) break;
                if (IsInsideBorders(i, j))
                {
                    if (!DeterminePath(i, j))
                        break;
                }
                if (j > 0)
                    j--;
                else break;

                if (isOneStep)
                    break;
            }

            j = JcurrFigure + 1;
            for (int i = IcurrFigure + 1; i < 8; i++)
            {
                if (currentPlayer == 2 && isOneStep && !isContinue) break;
                if (IsInsideBorders(i, j))
                {
                    if (!DeterminePath(i, j))
                        break;
                }
                if (j < 7)
                    j++;
                else break;

                if (isOneStep)
                    break;
            }
        }

        public bool DeterminePath(int ti, int tj)
        {

            if (Board[ti, tj] == 0 && !isContinue)
            {
                buttons[ti, tj].BackColor = Color.Yellow;
                buttons[ti, tj].Enabled = true;
                simpleSteps.Add(buttons[ti, tj]);
            }
            else
            {

                if (Board[ti, tj] != currentPlayer)
                {
                    if (pressedButton.Text == "D")
                        ShowProceduralEat(ti, tj, false);
                    else ShowProceduralEat(ti, tj);
                }

                return false;
            }
            return true;
        }

        public void CloseSimpleSteps(List<PictureBox> simpleSteps)
        {
            if (simpleSteps.Count > 0)
            {
                for (int i = 0; i < simpleSteps.Count; i++)
                {
                    simpleSteps[i].BackColor = GetPrevButtonColor(simpleSteps[i]);
                    simpleSteps[i].Enabled = false;
                }
            }
        }
        public void ShowProceduralEat(int i, int j, bool isOneStep = true)
        {
            int dirX = i - pressedButton.Location.Y / cellSize;
            int dirY = j - pressedButton.Location.X / cellSize;
            dirX = dirX < 0 ? -1 : 1;
            dirY = dirY < 0 ? -1 : 1;
            int il = i;
            int jl = j;
            bool isEmpty = true;
            while (IsInsideBorders(il, jl))
            {
                if (Board[il, jl] != 0 && Board[il, jl] != currentPlayer)
                {
                    isEmpty = false;
                    break;
                }
                il += dirX;
                jl += dirY;

                if (isOneStep)
                    break;
            }
            if (isEmpty)
                return;
            List<PictureBox> toClose = new List<PictureBox>();
            bool closeSimple = false;
            int ik = il + dirX;
            int jk = jl + dirY;
            while (IsInsideBorders(ik, jk))
            {
                if (Board[ik, jk] == 0)
                {
                    if (IsButtonHasEatStep(ik, jk, isOneStep, new int[2] { dirX, dirY }))
                    {
                        closeSimple = true;
                    }
                    else
                    {
                        toClose.Add(buttons[ik, jk]);
                    }
                    buttons[ik, jk].BackColor = Color.Yellow;
                    buttons[ik, jk].Enabled = true;
                    countEatSteps++;
                }
                else break;
                if (isOneStep)
                    break;
                jk += dirY;
                ik += dirX;
            }
            if (closeSimple && toClose.Count > 0)
            {
                CloseSimpleSteps(toClose);
            }

        }

        public bool IsButtonHasEatStep(int IcurrFigure, int JcurrFigure, bool isOneStep, int[] dir)
        {
            bool eatStep = false;
            int j = JcurrFigure + 1;
            for (int i = IcurrFigure - 1; i >= 0; i--)
            {
                if (currentPlayer == 1 && isOneStep && !isContinue) break;
                if (dir[0] == 1 && dir[1] == -1 && !isOneStep) break;
                if (IsInsideBorders(i, j))
                {
                    if (Board[i, j] != 0 && Board[i, j] != currentPlayer)
                    {
                        eatStep = true;
                        if (!IsInsideBorders(i - 1, j + 1))
                            eatStep = false;
                        else if (Board[i - 1, j + 1] != 0)
                            eatStep = false;
                        else return eatStep;
                    }
                }
                if (j < 7)
                    j++;
                else break;

                if (isOneStep)
                    break;
            }

            j = JcurrFigure - 1;
            for (int i = IcurrFigure - 1; i >= 0; i--)
            {
                if (currentPlayer == 1 && isOneStep && !isContinue) break;
                if (dir[0] == 1 && dir[1] == 1 && !isOneStep) break;
                if (IsInsideBorders(i, j))
                {
                    if (Board[i, j] != 0 && Board[i, j] != currentPlayer)
                    {
                        eatStep = true;
                        if (!IsInsideBorders(i - 1, j - 1))
                            eatStep = false;
                        else if (Board[i - 1, j - 1] != 0)
                            eatStep = false;
                        else return eatStep;
                    }
                }
                if (j > 0)
                    j--;
                else break;

                if (isOneStep)
                    break;
            }

            j = JcurrFigure - 1;
            for (int i = IcurrFigure + 1; i < 8; i++)
            {
                if (currentPlayer == 2 && isOneStep && !isContinue) break;
                if (dir[0] == -1 && dir[1] == 1 && !isOneStep) break;
                if (IsInsideBorders(i, j))
                {
                    if (Board[i, j] != 0 && Board[i, j] != currentPlayer)
                    {
                        eatStep = true;
                        if (!IsInsideBorders(i + 1, j - 1))
                            eatStep = false;
                        else if (Board[i + 1, j - 1] != 0)
                            eatStep = false;
                        else return eatStep;
                    }
                }
                if (j > 0)
                    j--;
                else break;

                if (isOneStep)
                    break;
            }

            j = JcurrFigure + 1;
            for (int i = IcurrFigure + 1; i < 8; i++)
            {
                if (currentPlayer == 2 && isOneStep && !isContinue) break;
                if (dir[0] == -1 && dir[1] == -1 && !isOneStep) break;
                if (IsInsideBorders(i, j))
                {
                    if (Board[i, j] != 0 && Board[i, j] != currentPlayer)
                    {
                        eatStep = true;
                        if (!IsInsideBorders(i + 1, j + 1))
                            eatStep = false;
                        else if (Board[i + 1, j + 1] != 0)
                            eatStep = false;
                        else return eatStep;
                    }
                }
                if (j < 7)
                    j++;
                else break;

                if (isOneStep)
                    break;
            }
            return eatStep;
        }

        public void ClearSteps()
        {
            for (int i = 0; i < mapSize; i++)
            {
                for (int j = 0; j < mapSize; j++)
                {
                    buttons[i, j].BackColor = GetPrevButtonColor(buttons[i, j]);
                }
            }
        }

        public bool IsInsideBorders(int ti, int tj)
        {
            if (ti >= mapSize || tj >= mapSize || ti < 0 || tj < 0)
            {
                return false;
            }
            return true;
        }

        public void ActivateAllButtons()
        {
            for (int i = 0; i < mapSize; i++)
            {
                for (int j = 0; j < mapSize; j++)
                {
                    buttons[i, j].Enabled = true;
                }
            }
        }

        public void DeactivateAllButtons()
        {
            for (int i = 0; i < mapSize; i++)
            {
                for (int j = 0; j < mapSize; j++)
                {
                    buttons[i, j].Enabled = false;
                }
            }
        }

        private void XButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void winnerXButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void startButton_ClickAsync(object sender, EventArgs e)
        {
            this.btnGamesList.Visible = false;
            ActivateAllButtons();
            player.NumOfGames++;
            string apiPath = $"api/TblUsers/updateGame?id={player.Id}";
            this.startButton.Visible = false;
            HttpResponseMessage res = await client.PutAsJsonAsync(apiPath, 0);
            if (!res.IsSuccessStatusCode)
            {
                MessageBox.Show($"{res.Content.ToString()}");
                this.Close();
            }

            if (currentPlayer == 2)
            {
                currentPlayer = server;
                checkIfServerTurn();
            }
        }


        private void checkersBoard_Load(object sender, EventArgs e)
        {

        }


        private async void PostEndGame()
        {
            string apiPath = "api/TblGames";
            string jsonData = @"{
            'Date': '',
            'Winner': '',
            'UserId': '',
            'DurationGame':'',
            }";
            dynamic data = JObject.Parse(jsonData);
            data.Date = DateTime.Now;
            data.Winner = winner;
            data.UserId = player.Id;
            data.DurationGame = durationGame;
            var httpContent = new StringContent($"{data}", Encoding.UTF8, "application/json");
            HttpResponseMessage res = await client.PostAsync(apiPath, httpContent);
            if (res.IsSuccessStatusCode)
            {
                MessageBox.Show($"{res.Content.ToString()}");
                return;
            }
            else
            {
                MessageBox.Show("Something went wrong");
                Close();
            }
        }
        public void saveGame()
        {
            Guid guid = Guid.NewGuid();
            string guidStr = guid.ToString().Substring(0, 23);
            
            _context.TblGames.InsertOnSubmit(new TblGame
            {

                Winner = winner,
                Date = DateTime.Now,
                Board = 0,
                GameID = guidStr,
            });

            foreach (var position in this.Positions)
            {
                _context.TblPositions.InsertOnSubmit(new TblPosition { x = position.Item1.x , y = position.Item1.y, GameID = guidStr }) ;

            }
            _context.SubmitChanges();
        }

    }

}
