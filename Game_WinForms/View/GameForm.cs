using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Game_WinForms.Model;
using Game_WinForms.Persistence;

namespace Game_WinForms.View
{
    public partial class GameForm : Form
    {

        #region private fields
        private GameModel _model;
        private IGameDataAccess _dataAccess;
        private Timer _timer;

        #endregion

        #region constructors
        public GameForm()
        {
            InitializeComponent();
            //fájl elérés
            _dataAccess = new GameDataAccess();
            //model példányosítása
            _model = new GameModel(_dataAccess);

            //játék vége esemény lekezelése a form-on
            _model.OnGameOver += _model_OnGameOver;
            //kosár felvétel esemény lekezelése a form-on
            _model.OnBasketFound += _model_OnBasketFound;
        }

        #endregion

        #region form event handlers

        //Összegyűjtött kosarak számának frissítése
        private void _model_OnBasketFound(object sender, EventArgs e)
        {
            _toolStripLabelStepCount.Text = "Kosarak száma: " + _model.BasketCount;
        }

        
        //Játék végének lekezelése győztes és vesztes esetben is
        private void _model_OnGameOver(object sender, GameOverEventArgs e)
        {
            _timer.Stop();
            if (e.IsWon)
            {
                MessageBox.Show("Gratulálok, nyertél!" + Environment.NewLine
                    + "Összegyűjtötted mind a(z) " + _model.BasketCount + " kosarat és összesen " 
                     + TimeSpan.FromSeconds(Math.Floor(_model.ElapsedSeconds + (DateTime.Now - _model.StartTime).TotalSeconds)).ToString() + " ideig játszottál!", "Játék vége",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Vesztettél" + Environment.NewLine
                    + "A(z) (" + (e?.Hunter.CoordX + 1) + "," + (e?.Hunter.CoordY + 1) + ") koordinátán lévő vadász meglátott!", "Játék vége",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            _continueToolStripMenuItem.Enabled = false; //ne lehessen folytatni ha vége
            _saveToolStripMenuItem.Enabled = false; // ne is lehessen elmenteni ha vége
        }

        //játékos helyének a frissítése, ha a játéknak vége van vagy szünetel akkor nem történik semmi
        private void Player_OnPlayerMove(object sender, MoveEventArgs e)
        {
            if (_model.GameOver || _model.Paused)
            {
                return;
            }
            var player = sender as Player;
            Control labelActualPosition = _tableLayoutPanel.GetControlFromPosition(player.X, player.Y);
            labelActualPosition.BackColor = Color.LightGreen;
            Control labelNextPosition = _tableLayoutPanel.GetControlFromPosition(e.NextPosition.X,e.NextPosition.Y);
            labelNextPosition.BackColor = Color.Brown;
            
        }

        private void GameForm_Load(object sender, EventArgs e)
        {
            _continueToolStripMenuItem.Enabled = false; // üres játékot ne lehessen folytatni
            _saveToolStripMenuItem.Enabled = false; // üres játékot sem lehet elmenteni
            _timer = new Timer();
            _timer.Enabled = false;
            _timer.Tick += _timer_Tick;
            _timer.Interval = 1000;
            _toolStripLabelTime.Text = "A játék kezdéséhez válassz játékmódot!";
            _toolStripLabelStepCount.Text = string.Empty;
            _continueToolStripMenuItem.Text = "Szünet";

        }

        //vadászok mozgásának frissítése a felületen, ha áll a játék vagy vége akkor nem történik semmi
        private void Model_OnHunterMove(object sender, MoveEventArgs e)
        {
            if (_model.GameOver || _model.Paused)
            {
                return;
            }
            
            Hunter hunter = sender as Hunter;
            Control labelActualPosition = _tableLayoutPanel.GetControlFromPosition(hunter.CoordX, hunter.CoordY);
            if (_model.checkHunterAndBasketOnSameField(hunter))
            {
                labelActualPosition.BackColor = Color.Gold;
            }
            else
            {
                labelActualPosition.BackColor = Color.LightGreen;
            }
            
            Control labelNextPosition = _tableLayoutPanel.GetControlFromPosition(e.NextPosition.X, e.NextPosition.Y);
            labelNextPosition.BackColor = Color.Red;
        }

        private void EasyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Initialize(_model.GetGeneratedFieldCountEasy, "EasyMode.txt");
        }

        private void MediumToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Initialize(_model.GetGeneratedFieldCountMedium, "MediumMode.txt");
        }

        private void HardToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Initialize(_model.GetGeneratedFieldCountHard, "HardMode.txt");

        }

        //reagál a gombnyomásokra és a játékost lépteti a megfelelő irányba egyel, ha áll a játék vagy vége akkor nem történik semmi
        private void GameForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (_model.GameOver || _model.Paused)
            {
                return;
            }

            switch (e.KeyCode)
            {
                case Keys.Up:
                    _model.playerMove(Direction.Up);
                    break;
                case Keys.Down:
                    _model.playerMove(Direction.Down);
                    break;
                case Keys.Left:
                    _model.playerMove(Direction.Left);
                    break;
                case Keys.Right:
                    _model.playerMove(Direction.Right);
                    break;
            }

        }

        //ha áll a játék akkor folytatjuk, ha pedig megy a játék akkor megállítja azt
        private void _continueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!_model.Paused)
            {
                _model.PauseGame();
                _timer.Stop();
                _continueToolStripMenuItem.Text = "Folytatás";
            }
            else
            {
                _model.ContinueGame();
                _timer.Start();
                _continueToolStripMenuItem.Text = "Szünet";
            }
        }

        //fájl megnyitása
        private async void _openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _model.PauseGame();
            _timer.Stop();
            _openFileDialog.Filter = "Game Info files (*.txt)|*.txt|All files (*.*)|*.*"; ;
            if (_openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    _saveToolStripMenuItem.Enabled = true;
                    _continueToolStripMenuItem.Enabled = true;
                    _continueToolStripMenuItem.Text = "Szünet";
                    await _model.LoadNewGameAsync(_openFileDialog.FileName);
                    GenerateTable(_model.GameInfos.TableSize);
                    _model.Player.OnPlayerMove += Player_OnPlayerMove;
                    
                    foreach (Hunter item in _model.GameInfos.Hunters)
                    {
                        item.OnHunterMove += Model_OnHunterMove;
                    }
                    drawDefaultGame();
                    _toolStripLabelStepCount.Text = $"Kosarak száma: {_model.BasketCount}";
                    if (!_timer.Enabled)
                    {
                        _timer.Enabled = true;
                    }

                }
                catch(Exception)
                {
                    MessageBox.Show(" Játék betöltése sikertelen!" + Environment.NewLine + "Hibás az elérési út, vagy a könyvtár nem olvasható.", "Hiba!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                _model.ContinueGame();
                _timer.Start();
            }
        }

        //fájl mentése
        private async void _saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _model.PauseGame();
            _timer.Stop();
            _saveFileDialog.Filter = "Game Info files (*.txt)|*.txt|All files (*.*)|*.*";
            if (_saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    await _model.SaveGameAsync(_saveFileDialog.FileName);
                    _continueToolStripMenuItem.Text = "Folytatás";

                }
                catch (Exception)
                {
                    MessageBox.Show("Játék mentése sikertelen!" + Environment.NewLine + "Hibás az elérési út, vagy a könyvtár nem írható.", "Hiba!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                _model.ContinueGame();
                _timer.Start();
            }
        }

        //Az idő telésével frissíti az időt és lépteti az összes vadászt egyel a megfelelő irányba, ha áll a játék vagy
        //vége akkor nem történik semmi
        private void _timer_Tick(object sender, EventArgs e)
        {
            _toolStripLabelTime.Text = "Idő: " + TimeSpan.FromSeconds(Math.Floor(_model.ElapsedSeconds + (DateTime.Now - _model.StartTime).TotalSeconds)).ToString();
            if (_model.GameOver || _model.Paused)
            {
                return;
            }
            _model.huntersMove();
        }

        #endregion

        #region private helper methods

        //az adott méret szerint legenerálja a pálya kinézetét
        private void GenerateTable(int size)
        {

            _tableLayoutPanel.Controls.Clear();
            _tableLayoutPanel.ColumnCount = _tableLayoutPanel.RowCount = size;

            _tableLayoutPanel.ColumnStyles.Clear();
            _tableLayoutPanel.RowStyles.Clear();

            for(int i = 0; i < size; i++)
            {
                _tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, _tableLayoutPanel.Width / size));
                _tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, _tableLayoutPanel.Height / size));
            }

            //feltölti először üres mezőkkel a pályát
            for(int i = 0; i < size; i++)
            {
                for(int j = 0; j < size; j++)
                {
                    Label field = new Label();
                    field.Dock = DockStyle.Fill;
                    field.BackColor = Color.LightGreen;
                    field.BorderStyle = BorderStyle.FixedSingle;
                    field.Margin = Padding.Empty;
                    _tableLayoutPanel.Controls.Add(field,i,j);
                }
            }

        }

        //pálya inicializálása, betölti a model-be a fájlt a fájlnév alapján, majd összekapcsolja az összes
        //vadászt és a játékost a megfelelő eseményekhez
        private async void Initialize(int startSize, string fileToLoad)
        {
            _timer.Stop();
            _continueToolStripMenuItem.Text = "Szünet"; //ha elindítottuk először megállítani lehet
            _continueToolStripMenuItem.Enabled = true;
            _saveToolStripMenuItem.Enabled = true;
            GenerateTable(startSize);
            await _model.LoadNewGameAsync(fileToLoad);
            _model.Player.OnPlayerMove += Player_OnPlayerMove;
            foreach(Hunter item in _model.GameInfos.Hunters)
            {
                item.OnHunterMove += Model_OnHunterMove;
            }
            _toolStripLabelStepCount.Text = $"Kosarak száma: {_model.BasketCount}";
            drawDefaultGame();

            _timer.Start();
        }

        

        

        //A kezdőpozíciók alapján a megfelelő mezőket átírja
        private void drawDefaultGame()
        {
            Control field = _tableLayoutPanel.GetControlFromPosition(_model.Player.X,_model.Player.Y);
            field.BackColor = Color.Brown;

            foreach (var item in _model.GameInfos.Baskets)
            {
                field = _tableLayoutPanel.GetControlFromPosition(item.X, item.Y);
                field.BackColor = Color.Gold;
            }

            foreach(var item in _model.GameInfos.Hunters)
            {
                field = _tableLayoutPanel.GetControlFromPosition(item.CoordX, item.CoordY);
                field.BackColor = Color.Red;
            }

            foreach(var item in _model.GameInfos.Trees)
            {
                field = _tableLayoutPanel.GetControlFromPosition(item.X, item.Y);
                field.BackColor = Color.Gray;
            }
        }

        #endregion

        
    }
}
