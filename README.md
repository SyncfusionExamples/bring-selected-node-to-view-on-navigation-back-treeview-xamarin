# How to bring the selected node to view when navigation back in Xamarin.Forms TreeView (SfTreeView) ?

You can bring the selected node to view when navigating to another page on selection and back to the [SfTreeView](https://help.syncfusion.com/xamarin/treeview/overview) page in Xamarin.Forms by using the [BringToView](https://help.syncfusion.com/cr/xamarin/Syncfusion.XForms.TreeView.SfTreeView.html#Syncfusion_XForms_TreeView_SfTreeView_BringIntoView_System_Object_System_Boolean_System_Boolean_Syncfusion_XForms_TreeView_ScrollToPosition_) method.

You can also refer our article.

https://www.syncfusion.com/kb/12004/how-to-bring-the-selected-node-to-view-when-navigation-back-in-xamarin-forms-treeview

**XAML**

Bind [SfTreeView.ItemTapped](https://help.syncfusion.com/cr/xamarin/Syncfusion.XForms.TreeView.SfTreeView.html) command to navigate to another page.
``` xml
<ContentPage xmlns="http://xamarin.com/schemas/2014/forms"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             xmlns:local="clr-namespace:TreeViewXamarin"
             xmlns:syncfusion="clr-namespace:Syncfusion.XForms.TreeView;assembly=Syncfusion.SfTreeView.XForms"
             x:Class="TreeViewXamarin.MainPage">
 
    <ContentPage.BindingContext>
        <local:FileManagerViewModel x:Name="viewModel"/>
    </ContentPage.BindingContext>
 
    <syncfusion:SfTreeView x:Name="treeView" ChildPropertyName="SubFiles" ItemTemplateContextType="Node" AutoExpandMode="AllNodesExpanded" TapCommand="{Binding ItemTappedCommand}" ItemsSource="{Binding ImageNodeInfo}" VerticalOptions="Center">
        <syncfusion:SfTreeView.ItemTemplate>
            <DataTemplate>
                <Grid x:Name="grid" RowSpacing="0" >
                    ...
                </Grid>
            </DataTemplate>
        </syncfusion:SfTreeView.ItemTemplate>
    </syncfusion:SfTreeView>
</ContentPage>
```
**C#**

In the command execution method, get the tapped node details from the command parameter and set it to the **ViewModel.SelectedNode** property.

``` c#
namespace TreeViewXamarin
{
    public class FileManagerViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<FileManager> imageNodeInfo;
        private object selectedNode;
 
        public FileManagerViewModel()
        {
            ItemTappedCommand = new Command<object>(OnItemTapped);
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
 
        private void OnItemTapped(object obj)
        {
            this.SelectedNode = (obj as TreeViewNode).Content as FileManager;
            App.Current.MainPage.Navigation.PushAsync(new NewPage());
        }
    }
}
```
**C#**

In the [OnAppearing](https://docs.microsoft.com/en-us/dotnet/api/xamarin.forms.page.onappearing) override method, invoke the **SfTreeView.BringIntoView** method to bring the selected item to the view by passing the **ViewModel.SelectedNode** property.

``` c#
namespace TreeViewXamarin
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
 
        protected override void OnAppearing()
        {
            //Brind the selected item to the view.
            if (this.viewModel.SelectedNode != null)
                treeView.BringIntoView(this.viewModel.SelectedNode, true);
            
            base.OnAppearing();
        }
    }
}
```
**Output**

![BringSelectedNodeToView](https://github.com/SyncfusionExamples/bring-selected-node-to-view-on-navigation-back-treeview-xamarin/blob/main/ScreenShots/BringSelectedNodeToView.gif)
