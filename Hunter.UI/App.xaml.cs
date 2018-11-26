using AutoMapper;
using Hunter.UI.Base;
using Hunter.UI.ViewModels;
using Quacker_Hunter;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Hunter.UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        /*public void Create()
        {
            Mapper.Initialize(cfg =>cfg.CreateMap<DataModel, DataViewModel>());
            Mapper.Initialize(cfg => cfg.CreateMap<DataViewModel, DataModel>());
            Mapper.Initialize(cfg => cfg.CreateMap<Quacker_Hunter.Profile, ProfileViewModel>());
            Mapper.Initialize(cfg => cfg.CreateMap<ProfileViewModel, Quacker_Hunter.Profile>());
        }*/

        private DataViewModel _viewModel;
        private DataModel _model;
        public App()
        {
            Mapping mapping = new Mapping();
            mapping.Create();
            _model = DataModel.Load();
            _viewModel = Mapper.Map<DataModel, DataViewModel>(_model);
            var menu = new MainWindow() { DataContext = _viewModel };
            menu.Show();
        }

    }
}
