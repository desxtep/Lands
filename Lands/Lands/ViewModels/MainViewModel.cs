﻿namespace Lands.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using Lands.Models;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Windows.Input;
    using Views;
    using static System.Net.Mime.MediaTypeNames;

    public class MainViewModel
    {
        #region Properties
        public List<Land> LandsList {
            get;
            set;
        }


        public TokenResponse Token
        {
            get;
            set;
        }

        public ObservableCollection<MenuItemViewModel> Menus
        {
            get;
            set;
        }
        #endregion

        #region ViewModels
        public LoginViewModel Login
        {
            get;
            set;
        }

        public LandsViewModel Lands
        {
            get;
            set;
        }



        public LandViewModel Land
        {
            get;
            set;
        }
        #endregion

        #region Constructors
        public MainViewModel()
        {
            instance = this;
            this.Login = new LoginViewModel();
            this.LoadMenu();
        }
        #endregion

        #region Singleton
        private static MainViewModel instance;

        public static MainViewModel GetInstance()
        {
            if (instance == null)
            {
                return new MainViewModel();
            }

            return instance;
        }
        #endregion

        #region Methods
        private void LoadMenu()
        {
            this.Menus = new ObservableCollection<MenuItemViewModel>();

            this.Menus.Add(new MenuItemViewModel
            {
                Icon = "ic_settings",
                PageName = "MyProfilePage",
                Title = "Mi perfil",
            });

            this.Menus.Add(new MenuItemViewModel
            {
                Icon = "ic_insert_chart_outlined",
                PageName = "StaticsPage",
                Title = "Estadisticas",
            });

            this.Menus.Add(new MenuItemViewModel
            {
                Icon = "ic_exit_to_app",
                PageName = "LoginPage",
                Title = "Salir"
            }); ;
        }
        #endregion

    }
}