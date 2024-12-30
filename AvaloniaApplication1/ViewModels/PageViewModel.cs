using AvaloniaApplication1.Data;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AvaloniaApplication1.ViewModels;

public partial class PageViewModel : ViewModelBase
{
    [ObservableProperty] private PageNames _pageName;
    
}