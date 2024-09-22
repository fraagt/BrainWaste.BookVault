using CommunityToolkit.Mvvm.ComponentModel;

namespace BrainWaste.BookVault.Maui.PageModels
{
    public abstract partial class BasePageModel : ObservableObject
    {
        public BasePageModel()
        {
        }

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(IsNotBusy))]
        bool isBusy;

        [ObservableProperty]
        string title;

        public bool IsNotBusy => !IsBusy;
    }
}