using Client.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        GamesDataContext _context = new GamesDataContext();
        private static HttpClient client = new HttpClient();
        private const string BaseUrl = "https://localhost:44359/";
        const int mapSize = 8;
        const int cellSize = 55;
        int eatenBlack = 0;
        int eatenWhite = 0;
        Player player;
        Game gameRestore = null;
        private bool restoreGame = false;

        int currentPlayer;

        List<PictureBox> simpleSteps = new List<PictureBox>();
        int server = 0;
        int countEatSteps = 0;
        PictureBox prevButton;
        PictureBox pressedButton;
        bool isContinue = false;
        bool endGame = false;
        bool isMoving;

        int[,] map = new int[mapSize, mapSize];

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
            player = pl;
            InitializeComponent();

             whiteFigure = Properties.Resources.whiteSoldier;
            blackFigure = Properties.Resources.blackSoldier;
            blackCheatFigure = Properties.Resources.cheat;
            whiteCheatFigure = Properties.Resources.whiteCheat;          
            this.startButton.Visible = true;
            client.BaseAddress = new Uri(BaseUrl);
            this.btnGamesList.Visible = true;

            this.Text = "Checkers";

            Init();
        }

        public void Init()
        {
            endGame = false;
            eatenBlack = 0;
            eatenWhite = 0;
            this.ScoreLableBlack.Text = eatenBlack.ToString();
            this.ScoreLableWhite.Text = eatenWhite.ToString();
            currentPlayer = srand.Next(1,3);
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

            map = new int[mapSize, mapSize] { // 0 represent blank square, 1 represent white soldier, 2 represent black soldier.
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
                    if (map[i, j] != server && map[i, j] != 0 )
                        player1 = true;
                    if (map[i, j] == server)
                        player2 = true;
                }
            }
            if (!player2)
            {
                endGame = true;
                winform = new WinForm(player);
                winform.decalreTheWinner(player.Name);
                winform.Show();
                this.Visible = false;
            }
            if (!player1)
            {
                endGame = true;
                winform = new WinForm(player);
                winform.decalreTheWinner("server");
                winform.Show();
                this.Visible = false;

            }



        }

        public void CreateMap()
        {
            

            for (int i = 0; i < mapSize; i++)
            {
                for (int j = 0; j < mapSize; j++)
                {
                    PictureBox button = new PictureBox();
                    button.Location = new Point(j * cellSize, i * cellSize ) ;
                    button.Size = new Size(cellSize, cellSize);
                    button.Click += new EventHandler(OnFigurePress);
                    if (map[i, j] == 1)
                        button.Image = whiteFigure;
                    else if (map[i, j] == 2) button.Image = blackFigure;
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

            if (currentPlayer == server )
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

        public void resetMap()
        {
            for( int i=0; i < mapSize; i++)
            {
                for(int j=0; j < mapSize; j++)
                {
                    if (i % 2 == 0)
                    {
                        if (j % 2 == 0)
                            buttons[i, j].BackColor = Color.White;
                        else
                            buttons[i, j].BackColor = Color.Black;
                    }
                    else
                    {
                        if (j % 2 == 0)
                            buttons[i, j].BackColor = Color.Black;
                        else
                            buttons[i, j].BackColor = Color.White;
                    }
                }
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
            isServerTurn = false ;

            if (prevButton != null)
                prevButton.BackColor = GetPrevButtonColor(prevButton);

            pressedButton = sender as PictureBox;

            //we check if the pressed picturebox is not blank square and the soldier belongs to player 
            if (map[pressedButton.Location.Y / cellSize, pressedButton.Location.X / cellSize] != 0 && map[pressedButton.Location.Y / cellSize, pressedButton.Location.X / cellSize] == currentPlayer) 
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
                    if(currentPlayer == server)
                        System.Threading.Thread.Sleep(1000);
                    int temp = map[pressedButton.Location.Y / cellSize, pressedButton.Location.X / cellSize];// the position of the pressed button
                    
                    //like swap -> update the new position of the soldier.
                    map[pressedButton.Location.Y / cellSize, pressedButton.Location.X / cellSize] = map[prevButton.Location.Y / cellSize, prevButton.Location.X / cellSize];
                    map[prevButton.Location.Y / cellSize, prevButton.Location.X / cellSize] = temp; // now its blank square
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
                        if(!endGame)
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
            if(isServerTurn == false)
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
                    if (map[i, j] == currentPlayer)
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
            if (map[button.Location.Y / cellSize, button.Location.X / cellSize] == 1 && button.Location.Y / cellSize == mapSize - 1)
            {
                button.Image = whiteCheatFigure;
                button.SizeMode = PictureBoxSizeMode.StretchImage;
                button.BackColor = Color.Black;
                button.Text = "D";// D represent the cheat.

            }
            //if we reach to the first y of the board and there is black soldier
            if (map[button.Location.Y / cellSize, button.Location.X / cellSize] == 2 && button.Location.Y / cellSize == 0)
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
            if (map[i, j] == 1)//for updateing eaten White soldier
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
                map[i, j] = 0; // blank sqaure
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

            if (map[ti, tj] == 0 && !isContinue)
            {
                buttons[ti, tj].BackColor = Color.Yellow;
                buttons[ti, tj].Enabled = true;
                simpleSteps.Add(buttons[ti, tj]);
            }
            else
            {

                if (map[ti, tj] != currentPlayer)
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
                if (map[il, jl] != 0 && map[il, jl] != currentPlayer)
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
                if (map[ik, jk] == 0)
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
                    if (map[i, j] != 0 && map[i, j] != currentPlayer)
                    {
                        eatStep = true;
                        if (!IsInsideBorders(i - 1, j + 1))
                            eatStep = false;
                        else if (map[i - 1, j + 1] != 0)
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
                    if (map[i, j] != 0 && map[i, j] != currentPlayer)
                    {
                        eatStep = true;
                        if (!IsInsideBorders(i - 1, j - 1))
                            eatStep = false;
                        else if (map[i - 1, j - 1] != 0)
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
                    if (map[i, j] != 0 && map[i, j] != currentPlayer)
                    {
                        eatStep = true;
                        if (!IsInsideBorders(i + 1, j - 1))
                            eatStep = false;
                        else if (map[i + 1, j - 1] != 0)
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
                    if (map[i, j] != 0 && map[i, j] != currentPlayer)
                    {
                        eatStep = true;
                        if (!IsInsideBorders(i + 1, j + 1))
                            eatStep = false;
                        else if (map[i + 1, j + 1] != 0)
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

        private void startButton_Click(object sender, EventArgs e)
        {
            this.btnGamesList.Visible = false;
            ActivateAllButtons();
            this.startButton.Visible = false;
            if (currentPlayer == 2)
            {
                currentPlayer = server;
                checkIfServerTurn();
            }
        }

        private void checkersBoard_Load(object sender, EventArgs e)
        {

        }
    }
}