﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Lands.ViewModels
{
    using Models;
    using System.Collections.ObjectModel;
    using System.Linq;

    public class LandViewModel : BaseViewModel
    { 
        #region Attributes
        private ObservableCollection<Border> borders;
        private ObservableCollection<Currency> currencies;
        private ObservableCollection<Language> languages;
        #endregion

        #region Properties
        public Land Land {
            get;
            set;
        }

        public ObservableCollection<Border> Borders
        {
            get { return this.borders; }
            set { SetValue(ref this.borders, value); }
        }

        public ObservableCollection<Currency> Currencies
        {
            get { return this.currencies; }
            set { SetValue(ref this.currencies, value); }
        }
        public ObservableCollection<Language> Languages
        {
            get { return this.languages; }
            set { SetValue(ref this.languages, value); }
        }
        #endregion

        #region Contructors
        public LandViewModel(Land land)
        {
            this.Land = land;
            this.LoadBorder();
            this.currencies = new ObservableCollection<Currency>(this.Land.Currencies);
            this.languages = new ObservableCollection<Language>(this.Land.Languages);
        }
        #endregion

        #region Methods
        private void LoadBorder() {
            this.Borders = new ObservableCollection<Border>();
            foreach (var border in this.Land.Borders) {
                var land = MainViewModel.GetInstance().LandsList
                    .Where(l =>l.Alpha3Code == border)
                    .FirstOrDefault();
                if (land != null) {
                    this.Borders.Add(new Border
                    {
                        Code = land.Alpha3Code,
                        Name = land.Name,
                    });
                }
            }
        }
        #endregion
    }
}
