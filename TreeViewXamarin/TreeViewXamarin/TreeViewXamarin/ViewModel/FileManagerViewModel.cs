using Syncfusion.TreeView.Engine;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Reflection;
using System.Text;
using Xamarin.Forms;

namespace TreeViewXamarin
{
    public class FileManagerViewModel : INotifyPropertyChanged
    {
        #region Fields

        private ObservableCollection<FileManager> imageNodeInfo;
        private object selectedNode;
        #endregion

        #region Constructor

        public FileManagerViewModel()
        {
            ItemTappedCommand = new Command<object>(OnItemTapped);
            GenerateSource();
        }

        #endregion

        #region Properties

        public ObservableCollection<FileManager> ImageNodeInfo
        {
            get { return imageNodeInfo; }
            set { this.imageNodeInfo = value; }
        }

        public Command<object> ItemTappedCommand { get; set; }

        public object SelectedNode
        {
            get
            {
                return selectedNode;
            }
            set
            {
                selectedNode = value;
                this.OnPropertyChanged("SelectedNode");
            }
        }
        #endregion

        #region Methods

        private void OnItemTapped(object obj)
        {
            this.SelectedNode = (obj as TreeViewNode).Content as FileManager;
            App.Current.MainPage.Navigation.PushAsync(new NewPage());
        }

        private void GenerateSource()
        {
            var nodeImageInfo = new ObservableCollection<FileManager>();
            Assembly assembly = typeof(MainPage).GetTypeInfo().Assembly;
            var doc = new FileManager() { ItemName = "Documents", ImageIcon = ImageSource.FromResource("TreeViewXamarin.Icons.treeview_folder.png", assembly), Id = 1 };
            var download = new FileManager() { ItemName = "Downloads", ImageIcon = ImageSource.FromResource("TreeViewXamarin.Icons.treeview_folder.png", assembly), Id = 2 };
            var mp3 = new FileManager() { ItemName = "Music", ImageIcon = ImageSource.FromResource("TreeViewXamarin.Icons.treeview_folder.png", assembly), Id = 3 };
            var pictures = new FileManager() { ItemName = "Pictures", ImageIcon = ImageSource.FromResource("TreeViewXamarin.Icons.treeview_folder.png", assembly), Id = 4 };
            var video = new FileManager() { ItemName = "Videos", ImageIcon = ImageSource.FromResource("TreeViewXamarin.Icons.treeview_folder.png", assembly), Id = 5 };

            var pollution = new FileManager() { ItemName = "Environmental Pollution.docx", ImageIcon = ImageSource.FromResource("TreeViewXamarin.Icons.treeview_word.png", assembly), Id = 11 };
            var globalWarming = new FileManager() { ItemName = "Global Warming.ppt", ImageIcon = ImageSource.FromResource("TreeViewXamarin.Icons.treeview_ppt.png", assembly), Id = 12 };
            var sanitation = new FileManager() { ItemName = "Sanitation.docx", ImageIcon = ImageSource.FromResource("TreeViewXamarin.Icons.treeview_word.png", assembly), Id = 13 };
            var socialNetwork = new FileManager() { ItemName = "Social Network.pdf", ImageIcon = ImageSource.FromResource("TreeViewXamarin.Icons.treeview_pdf.png", assembly), Id = 14 };
            var youthEmpower = new FileManager() { ItemName = "Youth Empowerment.pdf", ImageIcon = ImageSource.FromResource("TreeViewXamarin.Icons.treeview_pdf.png", assembly), Id = 15 };

            var games = new FileManager() { ItemName = "Game.exe", ImageIcon = ImageSource.FromResource("TreeViewXamarin.Icons.treeview_exe.png", assembly), Id = 21 };
            var tutorials = new FileManager() { ItemName = "Tutorials.zip", ImageIcon = ImageSource.FromResource("TreeViewXamarin.Icons.treeview_zip.png", assembly), Id = 22 };
            var typeScript = new FileManager() { ItemName = "TypeScript.7z", ImageIcon = ImageSource.FromResource("TreeViewXamarin.Icons.treeview_zip.png", assembly), Id = 23 };
            var uiGuide = new FileManager() { ItemName = "UI-Guide.pdf", ImageIcon = ImageSource.FromResource("TreeViewXamarin.Icons.treeview_pdf.png", assembly), Id = 24 };

            var song = new FileManager() { ItemName = "Gouttes", ImageIcon = ImageSource.FromResource("TreeViewXamarin.Icons.treeview_mp3.png", assembly), Id = 31 };

            var camera = new FileManager() { ItemName = "Camera Roll", ImageIcon = ImageSource.FromResource("TreeViewXamarin.Icons.treeview_folder.png", assembly), Id = 41 };
            var stone = new FileManager() { ItemName = "Stone.jpg", ImageIcon = ImageSource.FromResource("TreeViewXamarin.Icons.treeview_png.png", assembly), Id = 42 };
            var wind = new FileManager() { ItemName = "Wind.jpg", ImageIcon = ImageSource.FromResource("TreeViewXamarin.Icons.treeview_png.png", assembly), Id = 43 };

            var img0 = new FileManager() { ItemName = "WIN_20160726_094117.JPG", ImageIcon = ImageSource.FromResource("TreeViewXamarin.Icons.treeview_img0.png", assembly), Id = 411 };
            var img1 = new FileManager() { ItemName = "WIN_20160726_094118.JPG", ImageIcon = ImageSource.FromResource("TreeViewXamarin.Icons.treeview_img1.png", assembly), Id = 412 };

            var video1 = new FileManager() { ItemName = "Naturals.mp4", ImageIcon = ImageSource.FromResource("TreeViewXamarin.Icons.treeview_video.png", assembly), Id = 51 };
            var video2 = new FileManager() { ItemName = "Wild.mpeg", ImageIcon = ImageSource.FromResource("TreeViewXamarin.Icons.treeview_video.png", assembly), Id = 52 };

            doc.SubFiles = new ObservableCollection<FileManager>
            {
                pollution,
                globalWarming,
                sanitation,
                socialNetwork,
                youthEmpower
            };

            download.SubFiles = new ObservableCollection<FileManager>
            {
                games,
                tutorials,
                typeScript,
                uiGuide
            };

            mp3.SubFiles = new ObservableCollection<FileManager>
            {
                song
            };

            pictures.SubFiles = new ObservableCollection<FileManager>
            {
                camera,
                stone,
                wind
            };
            camera.SubFiles = new ObservableCollection<FileManager>
            {
                img0,
                img1
            };

            video.SubFiles = new ObservableCollection<FileManager>
            {
                video1,
                video2
            };

            nodeImageInfo.Add(doc);
            nodeImageInfo.Add(download);
            nodeImageInfo.Add(mp3);
            nodeImageInfo.Add(pictures);
            nodeImageInfo.Add(video);
            imageNodeInfo = nodeImageInfo;
        }

        #endregion

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
        #endregion
    }
}