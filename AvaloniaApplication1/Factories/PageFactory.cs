using System;
using AvaloniaApplication1.Data;
using AvaloniaApplication1.ViewModels;

namespace AvaloniaApplication1.Factories;

public class PageFactory(Func<PageNames, PageViewModel> factory)
{
    public PageViewModel GetPageViewModel(PageNames pageName) => factory.Invoke(pageName);
   
}