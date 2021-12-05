using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Xml.XPath;
using System.Collections;
using System.Text.RegularExpressions;
using System.Net;
using Google.API.Search;
using System.Windows.Threading;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Microsoft.VisualBasic.FileIO;
using System.Diagnostics;

namespace ES_Manager
{
    public partial class MainForm : Form
    {
        private XmlDocument gameListXML;
        private XmlNode currentGameNode;
        private string currentEmulatorEnum;
        private string currentGameListXMLPath;
        private string currentPcPath;
        private string currentPiPath;
        private string currentSmbSharePath;
        private int currentCoverWidth;
        private int currentCoverHeight;
        private Form imagesWindow;

        private class ComboBoxItem
        {
            public string Text { get; set; }
            public object Value { get; set; }

            public override string ToString()
            {
                return Text;
            }
        }

        private class ListBoxItem
        {
            public string Text { get; set; }
            public object Value { get; set; }

            public override string ToString()
            {
                return Text;
            }
        }
        
        public MainForm()
        {
            InitializeComponent();

            foreach (string aValue in ConfigurationManager.AppSettings)
            {
                if (aValue.EndsWith("_pc_path"))
                {
                    if (ConfigurationManager.AppSettings[aValue] != String.Empty)
                    {
                        //Si le pc_path est rensigné, alors on pourra gérer les roms de la machine en question
                        var emulatorEnum = aValue.Replace("_pc_path", string.Empty);
                        cbMachine.Items.Add(new ComboBoxItem(){ 
                            Text = ConfigurationManager.AppSettings[emulatorEnum+"_name"],
                            Value = emulatorEnum,
                        });
                    }
                }
            }

            gameListXML = new XmlDocument();
            cbMachine.SelectedIndex = 0;
        }

        #region events

        private void cbMachine_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentEmulatorEnum = ((ComboBoxItem)cbMachine.SelectedItem).Value.ToString();
            currentPcPath = ConfigurationManager.AppSettings[currentEmulatorEnum + "_pc_path"];
            currentPiPath = ConfigurationManager.AppSettings[currentEmulatorEnum + "_pi_path"];
            currentSmbSharePath = ConfigurationManager.AppSettings[currentEmulatorEnum + "_smb_share_path"];
            currentGameListXMLPath = currentPcPath + "\\gamelist.xml";

            
            lbGames.Items.Clear();

            if (!File.Exists(currentGameListXMLPath))
            {
                using (StreamWriter sw = File.CreateText(currentGameListXMLPath))
                {
                    sw.WriteLine("<?xml version=\"1.0\"?>");
                    sw.WriteLine("<gameList></gameList>");
                }	
                //gameListXML.Load(currentGameListXMLPath);
                //gameListXML.AppendChild(gameListXML.CreateElement("gamelist"));
                //gameListXML.Save(currentGameListXMLPath);
                gameListXML = new XmlDocument();
            }

            gameListXML.Load(currentGameListXMLPath);
            var games = gameListXML.SelectNodes("gameList/game");

            for(int i = 0; i < games.Count; i++)
            {
                if (File.Exists(currentPcPath + "//" + Path.GetFileName(games[i].SelectSingleNode("path").InnerText)))
                {
                    string name = games[i].SelectSingleNode("name").InnerText;
                    lbGames.Items.Add(new ListBoxItem()
                    {
                        Text = games[i].SelectSingleNode("name").InnerText,
                        Value = Path.GetFileName(games[i].SelectSingleNode("path").InnerText)
                    });
                }
                else
                {
                    gameListXML.SelectSingleNode("gameList").RemoveChild(games[i]);
                }
            }

            var romsList = getFiles(currentPcPath+"\\");
            foreach(var rom in romsList)
            {
                if (gameListXML.SelectNodes("gameList/game/path[.=\"" + currentPiPath + Path.GetFileName(rom) + "\"]").Count == 0)
                {
                    //it's a new game !
                    var newGameNode = gameListXML.CreateElement("game");
                    
                    var newGamePath = gameListXML.CreateElement("path");
                    newGamePath.InnerText = currentPiPath + Path.GetFileName(rom);
                    newGameNode.AppendChild(newGamePath);

                    var newGameName = gameListXML.CreateElement("name");
                    newGameName.InnerText = clearRomName(Path.GetFileNameWithoutExtension(rom));
                    newGameNode.AppendChild(newGameName);

                    //var newGameDescription = gameListXML.CreateElement("desc");
                    //newGameNode.AppendChild(newGameDescription);

                    var newGameRating = gameListXML.CreateElement("rating");
                    newGameRating.InnerText = "0.000000";
                    newGameNode.AppendChild(newGameRating);

                    var newGameUserRating = gameListXML.CreateElement("userrating");
                    newGameUserRating.InnerText = "0.000000";
                    newGameNode.AppendChild(newGameUserRating);

                    var newGameTP = gameListXML.CreateElement("timesplayed");
                    newGameTP.InnerText = "0";
                    newGameNode.AppendChild(newGameTP);

                    var newGameLP = gameListXML.CreateElement("lastplayed");
                    newGameLP.InnerText = "0";
                    newGameNode.AppendChild(newGameLP);
                    
                    gameListXML.SelectSingleNode("gameList").AppendChild(newGameNode);
                    
                    lbGames.Items.Add(new ListBoxItem()
                    {
                        Text = Path.GetFileNameWithoutExtension(rom),
                        Value = Path.GetFileName(rom)
                    });
                }
            }

            btnOpenSmbShare.Enabled = true;
            btnCopyToPi.Enabled = true;
            if(String.IsNullOrEmpty(currentSmbSharePath))
            {
                btnCopyToPi.Enabled = false;
                btnOpenSmbShare.Enabled = false;
            }

            gameListXML.Save(currentGameListXMLPath);
            lbGames.SelectedIndex = 0;
        }

        private void lbGames_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbTitle.Text = String.Empty;
            tbDescription.Text = String.Empty;
            tbFilename.Text = ((ListBoxItem)lbGames.SelectedItem).Value.ToString();
            pbCover.ImageLocation = null;

            rbSize1.Text = ConfigurationManager.AppSettings[currentEmulatorEnum + "_cover_width"] + "x" + ConfigurationManager.AppSettings[currentEmulatorEnum + "_cover_height"];
            rbSize2.Text = ConfigurationManager.AppSettings[currentEmulatorEnum + "_cover_width_alternate"] + "x" + ConfigurationManager.AppSettings[currentEmulatorEnum + "_cover_height_alternate"];
            rbSize1.Select();

            tbSpecificScraperSearch.Text = String.Empty;


            currentGameNode = gameListXML.SelectSingleNode("gameList/game/path[.=\"" + currentPiPath + ((ListBoxItem)lbGames.SelectedItem).Value + "\"]").ParentNode;
            tbTitle.Text = currentGameNode.SelectSingleNode("name").InnerText;
            if (currentGameNode.SelectNodes("desc").Count > 0)
            {
                tbDescription.Text = currentGameNode.SelectSingleNode("desc").InnerText;
            }
            if (currentGameNode.SelectNodes("image").Count > 0)
            {
                var coverPath = currentPcPath + "\\" + Path.GetFileName(currentGameNode.SelectSingleNode("image").InnerText);
                pbCover.ImageLocation = coverPath;
            }
            lbGames.Focus();
        }

        private void tbTitle_TextChanged(object sender, EventArgs e)
        {
            if (tbTitle.Text.Trim() == String.Empty)
                return;

            if(currentGameNode.SelectNodes("name").Count == 0)
            {
                currentGameNode.AppendChild(gameListXML.CreateElement("name"));
            }
            currentGameNode.SelectSingleNode("name").InnerText = tbTitle.Text;

            gameListXML.Save(currentGameListXMLPath);
        }

        private void tbDescription_TextChanged(object sender, EventArgs e)
        {
            if (tbTitle.Text.Trim() == String.Empty)
                return;
            
            if (currentGameNode.SelectNodes("desc").Count == 0)
            {
                currentGameNode.AppendChild(gameListXML.CreateElement("desc"));
            }
            currentGameNode.SelectSingleNode("desc").InnerText = tbDescription.Text;
            gameListXML.Save(currentGameListXMLPath);
        }

        private void MainForm_DragDrop(object sender, DragEventArgs e)
        {
            int x = this.PointToClient(new Point(e.X, e.Y)).X;
            int y = this.PointToClient(new Point(e.X, e.Y)).Y;

            if (x >= pbCover.Location.X && x <= pbCover.Location.X + pbCover.Width && y >= pbCover.Location.Y && y <= pbCover.Location.Y + pbCover.Height)
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);


                updateCover(Image.FromFile(files[0]));
            }
        }

        private void MainForm_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void btnRemoveCover_Click(object sender, EventArgs e)
        {
            if (currentGameNode.SelectNodes("image").Count > 0)
            {
                string imgLoc = pbCover.ImageLocation;
                pbCover.Image = null;
                File.Delete(imgLoc);
                currentGameNode.RemoveChild(currentGameNode.SelectSingleNode("image"));
            }
            else
            {
                MessageBox.Show("Already has no cover !");
            }
            gameListXML.Save(currentGameListXMLPath);
        }

        private void btnScrapeGamesDb_Click(object sender, EventArgs e)
        {
            btnScrapeGamesDb.Enabled = false;
            
            string searchString = tbTitle.Text;
            if(tbSpecificScraperSearch.Text.Trim() != String.Empty)
            {
                searchString = tbSpecificScraperSearch.Text;
            }

            

            var scraperdoc = new XmlDocument();
            scraperdoc.Load("http://thegamesdb.net/api/GetGame.php?name=" + searchString + "&platform=" + ConfigurationManager.AppSettings[currentEmulatorEnum + "_gamesdb_machine_name"]);
            var scrappedgames = scraperdoc.SelectSingleNode("Data").SelectNodes("Game");
            int bestmatch = -1;
            int lastdistance = 1000000;
            for (int i = 0; i < scrappedgames.Count; i++)
            {
                if (lastdistance > LevenshteinDistance(searchString, scrappedgames[i].SelectSingleNode("GameTitle").InnerText))
                {
                    lastdistance = LevenshteinDistance(searchString, scrappedgames[i].SelectSingleNode("GameTitle").InnerText);
                    bestmatch = i;
                }
            }

            if(bestmatch < 0)
            {
                btnScrapeGamesDb.Enabled = true;
                MessageBox.Show("No results !");
                return;
            }

            if (scrappedgames[bestmatch].SelectNodes("Overview").Count > 0)
            {
                tbDescription.Text = scrappedgames[bestmatch].SelectSingleNode("Overview").InnerText;
            }

            var request = WebRequest.Create("http://thegamesdb.net/banners/" + scrappedgames[bestmatch].SelectSingleNode("Images").SelectSingleNode("boxart[@side='front']").InnerText);

            using (var response = request.GetResponse())
            using (var stream = response.GetResponseStream())
            {
                updateCover(Bitmap.FromStream(stream));
            }

            gameListXML.Save(currentGameListXMLPath);

            btnScrapeGamesDb.Enabled = true;
        }

        private void rbSize1_CheckedChanged(object sender, EventArgs e)
        {
            currentCoverWidth = Convert.ToInt32(ConfigurationManager.AppSettings[currentEmulatorEnum + "_cover_width"]);
            currentCoverHeight = Convert.ToInt32(ConfigurationManager.AppSettings[currentEmulatorEnum + "_cover_height"]);
        }

        private void rbSize2_CheckedChanged(object sender, EventArgs e)
        {
            currentCoverWidth = Convert.ToInt32(ConfigurationManager.AppSettings[currentEmulatorEnum + "_cover_width_alternate"]);
            currentCoverHeight = Convert.ToInt32(ConfigurationManager.AppSettings[currentEmulatorEnum + "_cover_height_alternate"]);
        }

        private void btnBrowseCover_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            //openFile.DefaultExt = "mif";
            openFile.Filter = "JPG (*.jpg,*.jpeg)|*.jpg;*.jpeg|PNG (*.png)|*.png|BMP (*.bmp)|*.bmp";
            openFile.ShowDialog();
            if (openFile.FileNames.Length > 0)
            {
                foreach (string filename in openFile.FileNames)
                {
                    updateCover(Image.FromFile(filename));
                }
            }
        }

        private void btnGoogleSearch_Click(object sender, EventArgs e)
        {
            btnGoogleSearch.Enabled = false;

            GimageSearchClient client = new GimageSearchClient("http://www.google.com");


            string searchString = tbTitle.Text;
            if (tbSpecificScraperSearch.Text.Trim() != String.Empty)
            {
                searchString = tbSpecificScraperSearch.Text;
            }

            var gImages = client.Search(searchString + " Cover " + currentEmulatorEnum, 80).ToList();

            imagesWindow = new Form();
            imagesWindow.AutoScroll = true;
            imagesWindow.Text = "Google Images";

            var imageHeight = 150;
            var imageWidth = 150;
            var resultsPerLine = 5;

            imagesWindow.Height = 800;
            imagesWindow.Width = 800;


            int i = 1;
            foreach (var gImage in gImages)
            {
                var pbGoogleImage = new PictureBox();
                pbGoogleImage.ImageLocation = gImage.Url;
                pbGoogleImage.SizeMode = PictureBoxSizeMode.Zoom;
                pbGoogleImage.Height = imageHeight;
                pbGoogleImage.Width = imageWidth;
                pbGoogleImage.Left = ((i - 1) % resultsPerLine) * imageWidth;
                pbGoogleImage.Top = (int)(Math.Ceiling((double)(i) / resultsPerLine) - 1) * imageHeight;
                pbGoogleImage.Cursor = Cursors.Hand;
                imagesWindow.Controls.Add(pbGoogleImage);
                pbGoogleImage.Click += pbGoogleImage_Click;
                i++;
            }


            imagesWindow.Show();


            btnGoogleSearch.Enabled = true;

        }


        private void pbGoogleImage_Click(object sender, EventArgs e)
        {
            var pbGoogleImage = (PictureBox)sender;
            HttpWebRequest httpWebRequest = (HttpWebRequest)HttpWebRequest.Create(pbGoogleImage.ImageLocation);
            HttpWebResponse httpWebReponse = (HttpWebResponse)httpWebRequest.GetResponse();
            Stream stream = httpWebReponse.GetResponseStream();
            updateCover(Image.FromStream(stream));
            imagesWindow.Hide();
        }


        private void btnCopyToPi_Click(object sender, EventArgs e)
        {
            try
            {
                FileSystem.CopyDirectory(currentPcPath, currentSmbSharePath, UIOption.AllDialogs);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnOpenSmbShare_Click(object sender, EventArgs e)
        {
            btnOpenSmbShare.Enabled = false;
            try
            {
                Process.Start(currentSmbSharePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            btnOpenSmbShare.Enabled = true;
        }

        private void btnOpenRomFolder_Click(object sender, EventArgs e)
        {
            btnOpenRomFolder.Enabled = false;
            try
            {
                Process.Start(currentPcPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            btnOpenRomFolder.Enabled = true;
        }

        #endregion

        #region utilities

        private void updateCover(Image newCover)
        {
            Bitmap myBitmap;
            ImageCodecInfo myImageCodecInfo;
            System.Drawing.Imaging.Encoder myEncoder;
            EncoderParameter myEncoderParameter;
            EncoderParameters myEncoderParameters;

            myBitmap = new Bitmap(newCover, new Size(currentCoverWidth, currentCoverHeight));

            myImageCodecInfo = GetEncoderInfo("image/jpeg");
            myEncoder = System.Drawing.Imaging.Encoder.Quality;
            myEncoderParameters = new EncoderParameters(1);
            myEncoderParameter = new EncoderParameter(myEncoder, 75L);
            myEncoderParameters.Param[0] = myEncoderParameter;
            myBitmap.Save(currentPcPath + "\\" + Path.GetFileNameWithoutExtension(currentGameNode.SelectSingleNode("path").InnerText) + ".jpg", myImageCodecInfo, myEncoderParameters);

            if (currentGameNode.SelectNodes("image").Count == 0)
            {
                currentGameNode.AppendChild(gameListXML.CreateElement("image"));
            }
            currentGameNode.SelectSingleNode("image").InnerText = currentPiPath + "//" + Path.GetFileNameWithoutExtension(currentGameNode.SelectSingleNode("path").InnerText) + ".jpg";

            pbCover.ImageLocation = currentPcPath + "\\" + Path.GetFileNameWithoutExtension(currentGameNode.SelectSingleNode("path").InnerText) + ".jpg";

            gameListXML.Save(currentGameListXMLPath);
        }

        private List<string> getFiles(string path)
        {
            string[] filePaths = Directory.GetFiles(path);
            var filesList = new List<string>();
            var extensionsList = ConfigurationManager.AppSettings[currentEmulatorEnum + "_rom_extension"].Split(',').ToList();
            for (int i = 0; i < filePaths.Length; i++)
            {
                if (extensionsList.Contains(Path.GetExtension(filePaths[i]).ToLower().Replace(".", String.Empty)))
                {
                    filesList.Add(filePaths[i]);
                }
            }
            return filesList;
        }

        private string clearRomName(string filename)
        {
            Regex rgx = new Regex(@"\([^\(\)]*\)|\[[^\[\]]*\]");
            filename = rgx.Replace(filename, String.Empty);
            return filename.Trim();
        }

        public static int LevenshteinDistance(string s, string t)
        {
            int n = s.Length;
            int m = t.Length;
            int[,] d = new int[n + 1, m + 1];

            // Step 1
            if (n == 0)
            {
                return m;
            }

            if (m == 0)
            {
                return n;
            }

            // Step 2
            for (int i = 0; i <= n; d[i, 0] = i++)
            {
            }

            for (int j = 0; j <= m; d[0, j] = j++)
            {
            }

            // Step 3
            for (int i = 1; i <= n; i++)
            {
                //Step 4
                for (int j = 1; j <= m; j++)
                {
                    // Step 5
                    int cost = (t[j - 1] == s[i - 1]) ? 0 : 1;

                    // Step 6
                    d[i, j] = Math.Min(
                        Math.Min(d[i - 1, j] + 1, d[i, j - 1] + 1),
                        d[i - 1, j - 1] + cost);
                }
            }
            // Step 7
            return d[n, m];
        }

        private static ImageCodecInfo GetEncoderInfo(String mimeType)
        {
            int j;
            ImageCodecInfo[] encoders;
            encoders = ImageCodecInfo.GetImageEncoders();
            for (j = 0; j < encoders.Length; ++j)
            {
                if (encoders[j].MimeType == mimeType)
                    return encoders[j];
            }
            return null;
        }

        #endregion 
        

    }
}
