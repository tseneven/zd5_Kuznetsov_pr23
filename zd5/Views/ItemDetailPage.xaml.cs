using System.ComponentModel;

using Xamarin.Forms;

using zd5.ViewModels;

namespace zd5.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}