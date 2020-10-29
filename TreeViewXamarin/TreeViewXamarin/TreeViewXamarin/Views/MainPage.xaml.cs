using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TreeViewXamarin
{
    public partial class MainPage : ContentPage
    {
        #region Constructor
        public MainPage()
        {
            InitializeComponent();
        }
        #endregion

        #region Override methods
        protected override void OnAppearing()
        {
            //Brind the selected item to the view.
            if (this.viewModel.SelectedNode != null)
                treeView.BringIntoView(this.viewModel.SelectedNode, true);
            
            base.OnAppearing();
        }
        #endregion
    }
}
