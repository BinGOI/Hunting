using AutoMapper;
using Hunter.UI.ViewModels;
using Quacker_Hunter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hunter.UI.Base
{
    public class Mapping
    {
        public void Create()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<DataModel, DataViewModel>());
            //Mapper.Initialize(cfg => cfg.CreateMap<DataViewModel, DataModel>());
            //Mapper.Initialize(cfg => cfg.CreateMap<Quacker_Hunter.Profile, ProfileViewModel>());
            //Mapper.Initialize(cfg => cfg.CreateMap<ProfileViewModel, Quacker_Hunter.Profile>());
        }
    }
}
