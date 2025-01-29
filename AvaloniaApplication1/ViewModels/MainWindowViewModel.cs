using System;
using AvaloniaApplication1.Data;
using AvaloniaApplication1.Factories;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AvaloniaApplication1.ViewModels;

public partial class MainWindowViewModel : ObservableObject
{
    private PageFactory _pageFactory;
    
    [ObservableProperty] private PageViewModel _activePage;
    
    public bool DashBoardIsActive => ActivePage.PageName == PageNames.Dashboard;
    public bool SettingsIsActive => ActivePage.PageName == PageNames.Settings;
    public bool PracticeIsActive => ActivePage.PageName == PageNames.Practice;
    public bool DecksIsActive => ActivePage.PageName == PageNames.Decks;
    
    // this is a generic navigate function
   // [RelayCommand]
   // private void Navigate(PageNames pageName) => ActivePage = _pageFactory.GetPageViewModel(pageName);
    
    [RelayCommand] private void GoToDashboard() => ActivePage = _pageFactory.GetPageViewModel(pageName: PageNames.Dashboard);
    [RelayCommand] private void GoToSettings() => ActivePage = _pageFactory.GetPageViewModel(pageName: PageNames.Settings);
    [RelayCommand] private void GoToPractice() => ActivePage = _pageFactory.GetPageViewModel(pageName: PageNames.Practice);
    [RelayCommand] private void GoToDecks() => ActivePage = _pageFactory.GetPageViewModel(pageName: PageNames.Decks);

    public MainWindowViewModel(PageFactory pageFactory)
    {
        _pageFactory = pageFactory;
        GoToDashboard();
    }
    
}