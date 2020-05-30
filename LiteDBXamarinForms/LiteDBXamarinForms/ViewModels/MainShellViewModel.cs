using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;

namespace LiteDBXamarinForms.ViewModels
{
    public class MainShellViewModel : BindableBase
    {
        private string _title="テスト2";
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }
    }
}
