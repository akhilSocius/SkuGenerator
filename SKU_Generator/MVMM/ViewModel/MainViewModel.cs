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
           

            public NewSku NewSku { get; set; }

          

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
               

                CurrentView = NewSku;

            //HomeViewCommand = new RelayCommand(o =>
            //{
            //    CurrentView = HomeVm;
            //});

            SkuViewCommand = new RelayCommand(o =>
                {
                    CurrentView = NewSku;
                });

               

            }
        }
    }

