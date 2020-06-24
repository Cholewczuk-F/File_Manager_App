using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace file_manager
{
    public partial class Formwindow : Form
    {
        string filepath = "";
        string filepath2 = "";
        string selectedFile = "";
        string selectedFile2 = "";

        bool isFile = false;

        List<string> filesList = new List<string>();
        List<string> filesList2 = new List<string>();
        List<string> dirsList = new List<string>();
        List<string> dirsList2 = new List<string>();

        public Formwindow()
        {
            InitializeComponent();
        }

        private void Formwindow_Load(object sender, EventArgs e)
        {
            DriveInfo[] drives = DriveInfo.GetDrives();
            refreshState();
            refreshState2();

            foreach(DriveInfo drive in drives)
            {
                if(drive.IsReady)
                {
                    discsCombo.Items.Add(drive.Name);
                    discsCombo2.Items.Add(drive.Name);
                }
            }
        }





        /// <summary>
        /// dir-view loading and icon selection
        /// </summary>
        private void loadFiles()
        {
            dirListView.Items.Clear();
            filesList.Clear();
            dirsList.Clear();

            try
            {
                foreach (string item in Directory.GetFiles(filepath))
                {
                    imageList.Images.Add(Icon.ExtractAssociatedIcon(item));
                    FileInfo info = new FileInfo(item);
                    filesList.Add(info.FullName);
                    dirListView.Items.Add(info.Name, imageList.Images.Count - 1);
                }
                
                foreach(string item in Directory.GetDirectories(filepath))
                {
                    DirectoryInfo info = new DirectoryInfo(item);
                    dirsList.Add(info.FullName);
                    dirListView.Items.Add(info.Name, imageList.Images.Keys[0]);
                }
            }catch(Exception) { }
        }

        private void loadFiles2()
        {
            dirListView2.Items.Clear();
            filesList2.Clear();
            dirsList2.Clear();

            try
            {
                foreach (string item in Directory.GetFiles(filepath2))
                {
                    imageList.Images.Add(Icon.ExtractAssociatedIcon(item));
                    FileInfo info = new FileInfo(item);
                    filesList2.Add(info.FullName);
                    dirListView2.Items.Add(info.Name, imageList.Images.Count - 1);
                }

                foreach (string item in Directory.GetDirectories(filepath2))
                {
                    DirectoryInfo info = new DirectoryInfo(item);
                    dirsList2.Add(info.FullName);
                    dirListView2.Items.Add(info.Name, imageList.Images.Keys[0]);
                }
            }
            catch (Exception) { }
        }

        /// <summary>
        /// Accessible button for resetting dir-view
        /// </summary>
        private void refreshState()
        {
            filepath = pathBox.Text;
            loadFiles();
            isFile = false;
        }

        private void refreshState2()
        {
            filepath2 = pathBox2.Text;
            loadFiles2();
            isFile = false;
        }

        /// <summary>
        /// Trigger for change of drive selected in views
        /// </summary>
        private void discsCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string getInfo = discsCombo.SelectedItem.ToString();
            DriveInfo driveInfo = new DriveInfo(getInfo);
            pathBox.Text = getInfo;
            String avaibleMemory = driveInfo.AvailableFreeSpace.ToString();
            spaceLabel.Text = "Space Avaible: " + avaibleMemory + " B";
            refreshState();
        }

        private void discsCombo2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string getInfo = discsCombo2.SelectedItem.ToString();
            DriveInfo driveInfo = new DriveInfo(getInfo);
            pathBox2.Text = getInfo;
            String avaibleMemory = driveInfo.AvailableFreeSpace.ToString();
            spaceLabel2.Text = "Space Available: " + avaibleMemory + " B";
            refreshState2();
        }

        /// <summary>
        /// File in-view selection
        /// </summary>
        private void dirListView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            try
            {
                selectedFile = e.Item.Text;

                FileAttributes attributes = File.GetAttributes(filepath + "\\" + selectedFile);
                if ((attributes & FileAttributes.Directory) == FileAttributes.Directory)
                {
                    isFile = false;
                } else
                {
                    isFile = true;
                }
            }
            catch (Exception) { }
        }

        private void dirListView2_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            try
            {
                selectedFile2 = e.Item.Text;

                FileAttributes attributes = File.GetAttributes(filepath2 + "\\" + selectedFile2);
                if ((attributes & FileAttributes.Directory) == FileAttributes.Directory)
                {
                    isFile = false;
                }
                else
                {
                    isFile = true;
                }
            }
            catch (Exception) { }
        }

        /// <summary>
        /// Folder navigation handlers
        /// </summary>
        private void dirListView_DoubleClick(object sender, EventArgs e)
        {
            string path = filepath + "\\" + selectedFile;
            if(Directory.Exists(path))
            {
                pathBox.Text = path;
                refreshState();
            }
        }

        private void dirListView2_DoubleClick(object sender, EventArgs e)
        {
            string path = filepath2 + "\\" + selectedFile2;
            if(Directory.Exists(path))
            {
                pathBox2.Text = path;
                refreshState2();
            }
        }

        /// <summary>
        /// Moving files between directories
        /// </summary>
        private void moveButton_Click(object sender, EventArgs e)
        {
            
            string source = "", destination = "";

            //source: left directory
            if (dirListView.SelectedItems.Count > 0 && dirListView2.SelectedItems.Count == 0)
            {
                ListView.SelectedListViewItemCollection selectedItems = dirListView.SelectedItems;

                foreach(ListViewItem file in selectedItems)
                {
                    string fileData = file.ToString();
                    string[] properties = fileData.Split('{');
                    string filename = properties[1];
                    filename = filename.Substring(0, filename.Length - 1);

                    source = pathBox.Text + '\\' + Path.GetFileName(filename);
                    destination = pathBox2.Text + '\\' + Path.GetFileName(filename);

                    //assert that destination exists/is chosen
                    if(Directory.Exists(pathBox2.Text))
                    {
                        if (File.Exists(destination))
                        {
                            DialogResult result = MessageBox.Show("Destination file already exists. Overwrite?", "File exists.", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                            if (result == DialogResult.Yes)
                            {
                                File.Delete(destination);
                                File.Move(source, destination);
                            }
                        }
                        else
                        {
                            File.Move(source, destination);
                        }
                    }else
                    {
                        MessageBox.Show("No destination directory chosen or doesn't exist.");
                    }


                }
            }//source: right directory
            else if (dirListView.SelectedItems.Count == 0 && dirListView2.SelectedItems.Count > 0)
            {
                ListView.SelectedListViewItemCollection selectedItems = dirListView2.SelectedItems;

                foreach (ListViewItem file in selectedItems)
                {
                    string fileData = file.ToString();
                    string[] properties = fileData.Split('{');
                    string filename = properties[1];
                    filename = filename.Substring(0, filename.Length - 1);


                    source = pathBox2.Text + '\\' + Path.GetFileName(filename);
                    destination = pathBox.Text + '\\' + Path.GetFileName(filename);

                    //assert that destination exists/is chosen
                    if (Directory.Exists(pathBox.Text))
                    {
                        if (File.Exists(destination))
                        {
                            DialogResult result = MessageBox.Show("Destination file already exists. Overwrite?", "File exists.", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                            if (result == DialogResult.Yes)
                            {
                                File.Delete(destination);
                                File.Move(source, destination);
                            }
                        }
                        else
                        {
                            File.Move(source, destination);
                        }
                    } else
                    {
                        MessageBox.Show("No destination directory chosen or doesn't exist.");
                    }
                }
            }//both directories have file selected
            else if (dirListView.SelectedItems.Count > 0 && dirListView2.SelectedItems.Count > 0)
            {
                MessageBox.Show("Selected files are in different directories.");
                return;
            }
            else //no file selected
            {
                MessageBox.Show("No files selected or directories chosen.");
                return;
            }

            refreshState();
            refreshState2();
        }

        /// <summary>
        /// Adding new folders
        /// </summary>
        private void addFolderButton_Click(object sender, EventArgs e)
        {
            TextBox pathBoxSelected;
            //left view selected
            if (!focusCheckbox.Checked)
            {
                pathBoxSelected = pathBox;
            } else//right view selected
            {
                pathBoxSelected = pathBox2;
            }

            if(Directory.Exists(pathBoxSelected.Text))
            {
                string folderName = Interaction.InputBox("What the folder should be called?", "New Folder", "New Folder");

                if (folderName != "")
                {

                    string folderPath = pathBoxSelected.Text + '\\' + folderName;
                    if (!Directory.Exists(folderPath))
                    {
                        Directory.CreateDirectory(folderPath);
                    }else
                    {
                        MessageBox.Show("Such directory already exists!");
                    }

                    if(!focusCheckbox.Checked)
                    {
                        refreshState();
                    }else
                    {
                        refreshState2();
                    }
                }
            }else
            {
                MessageBox.Show("No directory specified.");
            }
        }

        /// <summary>
        /// Selection of view to operate on
        /// </summary>
        private void focusCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if(focusCheckbox.Checked)
            {
                addFolderButton.Text = "Add Folder (R)";
                copyButton.Text = "Copy (R)";
                backButton.Text = "Back (R)";
                renameButton.Text = "Rename (R)";
                deleteFolderButton.Text = "Delete Folder (R)";
                infoButton.Text = "Info (R)";
                previewButton.Text = "Preview (R)";
                searchButton.Text = "(R)";
            }else
            {
                addFolderButton.Text = "Add Folder (L)";
                copyButton.Text = "Copy (L)";
                backButton.Text = "Back (L)";
                renameButton.Text = "Rename (L)";
                deleteFolderButton.Text = "Delete Folder (L)";
                infoButton.Text = "Info (L)";
                previewButton.Text = "Preview (L)";
                searchButton.Text = "(L)";
            }
        }

        /// <summary>
        /// Copying files
        /// </summary>
        private void copyButton_Click(object sender, EventArgs e)
        {
            string sourcePathTemplate = "";
            ListView sourceView;

            //source: left directory
            if (!focusCheckbox.Checked)
            {
                sourceView = dirListView;
                if(Directory.Exists(pathBox.Text))
                {
                    sourcePathTemplate = pathBox.Text + '\\';
                }else
                {
                    MessageBox.Show("There's no directory viewed.");
                    return;
                }
            }//source: right directory
            else
            {
                sourceView = dirListView2;
                if (Directory.Exists(pathBox.Text))
                {
                    sourcePathTemplate = pathBox2.Text + '\\';
                }
                else
                {
                    MessageBox.Show("There's no directory viewed.");
                    return;
                }
            }

            ListView.SelectedListViewItemCollection selectedItems = sourceView.SelectedItems;
            string sourcePath = "", destinationPath = "";

            foreach (ListViewItem file in selectedItems)
            {
                string fileData = file.ToString();
                string[] properties = fileData.Split('{');
                string baseFilename = properties[1];
                baseFilename = baseFilename.Substring(0, baseFilename.Length - 1);

                //assert it is a file and it exists
                sourcePath = sourcePathTemplate + Path.GetFileName(baseFilename);
                if(File.Exists(sourcePath))
                {
                    //append (copy) to copied file name
                    string[] baseName = { "", "" };
                    string filename;
                    if(baseFilename.Contains("."))
                    {
                        baseName = baseFilename.Split('.');
                        baseName[0] +="(copy)";
                        filename = baseName[0] + "." + baseName[1];
                    }
                    else
                    {
                        filename = baseFilename + "(copy)";
                    }
                    destinationPath = sourcePathTemplate + filename;    

                    //assert there isin't already such file
                    if (File.Exists(destinationPath))
                    {
                        DialogResult result = MessageBox.Show("Destination file already exists. Overwrite?", "File exists.", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (result == DialogResult.Yes)
                        {
                            File.SetAttributes(destinationPath, FileAttributes.Normal);
                            File.Delete(destinationPath);
                            File.Copy(sourcePath, destinationPath);
                        }
                    }
                    else
                    {
                        File.Copy(sourcePath, destinationPath);
                    }

                    //successful, refresh view
                    refreshState();
                    refreshState2();
                }
                else
                {
                    MessageBox.Show("File doesn't exist or is a directory.");
                }
            }
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            string path; string orgPath; TextBox focusedBox;
            if(!focusCheckbox.Checked)
            {
                focusedBox = pathBox;
                path = pathBox.Text;
                
            }else
            {
                focusedBox = pathBox2;
                path = pathBox2.Text;
            }
            orgPath = path;

            if(path == "")
            {
                MessageBox.Show("There is no directory open");
                return;
            }

            try
            {
                if(path.LastIndexOf("\\") != 2)
                {
                    if(path.LastIndexOf("\\") == path.Length - 1)
                    {
                        path.Substring(0, path.Length - 1);
                    }
                    path = path.Substring(0, path.LastIndexOf("\\"));
                    this.isFile = false;
                    focusedBox.Text = path;

                    refreshState();
                    refreshState2();
                }else
                {
                    MessageBox.Show("No parent directory ahead.");
                }
            }
            catch(Exception)
            {
                MessageBox.Show("No parent directory ahead.");
                focusedBox.Text = orgPath;
                refreshState();
                refreshState2();
            }
    }

    /// <summary>
    /// Tab-Controlled directory focus change
    /// </summary>
    private void Formwindow_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.ControlKey)
            {
                if(focusCheckbox.Checked)
                {
                    focusCheckbox.Checked = false;
                }
                else
                {
                    focusCheckbox.Checked = true;
                }
            }
        }

        /// <summary>
        /// Rename files
        /// </summary>
        private void renameButton_Click(object sender, EventArgs e)
        {
            ListView focusView;
            string path;
            if(!focusCheckbox.Checked)
            {
                focusView = dirListView;
                path = pathBox.Text;
            }else
            {
                focusView = dirListView2;
                path = pathBox2.Text;
            }

            if(path != "")
            {
                ListView.SelectedListViewItemCollection selectedItems = focusView.SelectedItems;

                foreach (ListViewItem file in selectedItems)
                {
                    string fileData = file.ToString();
                    string[] properties = fileData.Split('{');
                    string filename = properties[1];
                    filename = filename.Substring(0, filename.Length - 1);

                    //assert it is a file and it exists
                    string sourceFilePath = path + "\\" + Path.GetFileName(filename);
                    if (File.Exists(sourceFilePath) || Directory.Exists(sourceFilePath))
                    {
                        string[] splitFilename = { "", "" };
                        string baseFilename;
                        if (filename.Contains("."))
                        {
                            splitFilename[0] = filename.Substring(0, filename.LastIndexOf("."));
                            splitFilename[1] = filename.Substring(filename.LastIndexOf(".") + 1, filename.Length - filename.LastIndexOf(".") - 1);

                            baseFilename = splitFilename[0];
                        }
                        else { baseFilename = filename; }
                        string newName = Interaction.InputBox("How should the file be renamed?", "New Folder", baseFilename);
                        if(splitFilename[1] != "")
                        {
                            newName += "." + splitFilename[1];
                        }

                        if(newName != "")
                        {
                            if (File.Exists(sourceFilePath))
                            {
                                File.Move(sourceFilePath, path + "\\" + newName);
                            }
                            else if (Directory.Exists(sourceFilePath))
                            {
                                //MessageBox.Show(path + "\\" + newName + "\n" + path);
                                Directory.Move(sourceFilePath, path + "\\" + newName);
                            }
                        }
                        refreshState();
                        refreshState2();
                    }
                }
            }else
            {
                MessageBox.Show("No directory open.");
            }
        }

        private void deleteFolderButton_Click(object sender, EventArgs e)
        {
            ListView focusView;
            string path;

            if (!focusCheckbox.Checked)
            {
                focusView = dirListView;
                path = pathBox.Text;
            } else
            {
                focusView = dirListView2;
                path = pathBox2.Text;
            }

            ListView.SelectedListViewItemCollection selectedFolders = focusView.SelectedItems;

            foreach(ListViewItem folder in selectedFolders)
            {
                string fileData = folder.ToString();
                string[] properties = fileData.Split('{');
                string filename = properties[1];
                filename = filename.Substring(0, filename.Length - 1);

                string pathDirName = path + "\\" + filename;
                if (Directory.Exists(pathDirName))
                {
                    DialogResult result = MessageBox.Show("Are you sure you'd like to delete directory: " + filename + " - with all it's contents?", "Delete directory.", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        RecursiveDelete(pathDirName);
                        refreshState();
                        refreshState2();
                    }
                }
            }
        }

        public void RecursiveDelete(string baseDir)
        {
            string[] files = Directory.GetFiles(baseDir);
            string[] dirs = Directory.GetDirectories(baseDir);

            foreach(string file in files)
            {
                File.SetAttributes(file, FileAttributes.Normal);
                File.Delete(file);
            }

            foreach(string dir in dirs)
            {
                RecursiveDelete(dir);
            }
            Directory.Delete(baseDir, false);
        }

        private void infoButton_Click(object sender, EventArgs e)
        {
            ListView focusView;
            string path;
            if (!focusCheckbox.Checked)
            {
                focusView = dirListView;
                path = pathBox.Text;
            }
            else
            {
                focusView = dirListView2;
                path = pathBox2.Text;
            }

            ListView.SelectedListViewItemCollection selectedItems = focusView.SelectedItems;

            foreach (ListViewItem item in selectedItems)
            {
                string fileData = item.ToString();
                string[] properties = fileData.Split('{');
                string filename = properties[1];
                filename = filename.Substring(0, filename.Length - 1);

                string filePath = path + "\\" + filename;
                if (File.Exists(filePath))
                {
                    FileInfo info = new FileInfo(filePath);
                    MessageBox.Show("Name: " + info.Name + "\nType: " + info.Extension + "\nSize: " + info.Length + "B" + "\nCreated at: " + info.CreationTime + "\nLast modified at: " + info.LastWriteTime);
                }
                else if (Directory.Exists(filePath))
                {
                    DirectoryInfo info = new DirectoryInfo(filePath);
                    MessageBox.Show("Name: " + info.Name + "\nCreated at: " + info.CreationTime + "\nAttributes: " + info.Attributes);
                }
            }
        }

        private void previewButton_Click(object sender, EventArgs e)
        {
            ListView focusView;
            string path;
            if (!focusCheckbox.Checked)
            {
                focusView = dirListView;
                path = pathBox.Text;
            }
            else
            {
                focusView = dirListView2;
                path = pathBox2.Text;
            }

            ListView.SelectedListViewItemCollection selectedItems = focusView.SelectedItems;

            foreach (ListViewItem item in selectedItems)
            {
                string fileData = item.ToString();
                string[] properties = fileData.Split('{');
                string filename = properties[1];
                filename = filename.Substring(0, filename.Length - 1);

                string filePath = path + "\\" + filename;
                if (File.Exists(filePath))
                {
                    //filePath = path + "\\" + Path.GetFileName(filename);
                    //File.SetAttributes(filePath, FileAttributes.Normal);
                    string text = File.ReadAllText(filePath);
                    MessageBox.Show(text, filename);
                }
                else if (Directory.Exists(filePath))
                {
                    string[] directories = Directory.GetFiles(filePath);
                    string text = "";
                    string tmpFilename;
                    foreach (var directory in directories)
                    {
                        tmpFilename = directory.Substring(directory.LastIndexOf("\\") + 1, directory.Length - 1 - directory.LastIndexOf("\\"));
                        text += tmpFilename + ", ";
                    }
                    MessageBox.Show(text, filename);
                }
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            string path; TextBox focusBox;
            if (!focusCheckbox.Checked)
            {
                path = pathBox.Text;
                focusBox = pathBox;
            }
            else
            {
                path = pathBox2.Text;
                focusBox = pathBox2;
            }
            try
            {
                string pattern = searchBox.Text;
                string[] files = Directory.GetFiles(path, pattern, SearchOption.AllDirectories);

                foreach (string file in files)
                {
                    string znaleziony = file;
                    int dlugosc = Path.GetFileName(znaleziony).Length;
                    focusBox.Text = znaleziony.Substring(0, znaleziony.Length - dlugosc - 1);
                    refreshState();
                    refreshState2();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("File with specified pattern not found.\n" + ex.Message);
            }
        }
    }
}
