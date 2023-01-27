using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SKU_Generator.Core;

namespace SKU_Generator.MVMM.ViewModel
{

        class MainViewModel : ObservableObject
        {
           
        public RelayCommand SkuViewCommand { get; set; }
        public RelayCommand SkuSimCommand { get; set; }


        public NewSku NewSku { get; set; }
        public SkuSim skuSim { get; set; }



        private object _currentView;


            public object CurrentView
            {
                get { return _currentView; }
                set
                {
                    _currentView = value;
                    OnPropertyChanged();
                }
            }
            public MainViewModel()
            {
            
              NewSku = new NewSku();
              skuSim=new SkuSim();
               

                CurrentView = NewSku;

            //HomeViewCommand = new RelayCommand(o =>
            //{
            //    CurrentView = HomeVm;
            //});

                SkuViewCommand = new RelayCommand(o =>
                {
                    CurrentView = NewSku;
                });
                 SkuSimCommand = new RelayCommand(o =>
                {
                    CurrentView = skuSim;
                });




        }
    }
    }

