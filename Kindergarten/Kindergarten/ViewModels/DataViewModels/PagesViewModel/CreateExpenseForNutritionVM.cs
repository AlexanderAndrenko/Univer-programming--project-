﻿using Kindergarten.Models;
using Kindergarten.Models.Entities;
using Kindergarten.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace Kindergarten.ViewModels.DataViewModels.PagesViewModel
{
    public class CreateExpenseForNutritionVM : BaseVM
    {
        #region Constructor
        private static CreateExpenseForNutritionVM instanse;
        public static CreateExpenseForNutritionVM GetInstanse()
        {
            if (instanse == null)
                instanse = new CreateExpenseForNutritionVM();
            return instanse;
        }

        private CreateExpenseForNutritionVM()
        {
            DateCalculation = DateTime.Today;
            NumberChildren = ChildrenModel.GetChildrenData(DateCalculation, DateCalculation);
            GetStocks();
            ListMenu = MenuModel.GetMenus();
            Calculate = new OwnCommand(Calculation);
        }
        #endregion //Constructor

        #region Properties

        public List<NumberChildren> NumberChildren { get; set; }

        private DateTime dateCalculation { get; set; }
        public DateTime DateCalculation 
        { 
            get => dateCalculation;
            set
            {
                dateCalculation = value;
                RaisePropertyChanged();
            } 
        }

        public Menu SelectedMenu { get; set; }

        public List<Menu> ListMenu { get; set; }

        public List<Party> Stocks { get; set; }
        public OwnCommand Calculate { get; set; }
        #endregion //Properties

        #region Methods

        public void GetStocks()
        {
            Stocks = PartyModel.GetParty();
        }

        public void GetMenu()
        {
            MenuModel.GetMenus(SelectedMenu.Id);
        }

        public void Calculation()
        {
            if (SelectedMenu != null && NumberChildren.Count == 1)
            {
                var menu = MenuModel.GetMenus(SelectedMenu.Id);
                

                if (menu != null)
                {
                    List<Dish> dishes = (List<Dish>)menu[0].Dishes;
                    List<Precalc> precalcs = new List<Precalc>();

                    dishes.ForEach(x => 
                    {
                        List<DishItem> dishItems = (List<DishItem>)x.DishItems;

                        dishItems.ForEach(y => 
                        {
                            bool flag = false;
                            precalcs.ForEach(z => 
                            {
                                if (z.ProductId == y.ProductId)
                                {
                                    z.Quantity += y.NurseryNorm + y.YardNorm;
                                    flag = true;
                                }
                            });

                            if (!flag)
                            {
                                precalcs.Add(
                                    new Precalc
                                    { 
                                        ProductId = y.ProductId,
                                        Quantity = y.NurseryNorm + y.YardNorm 
                                    });
                            }

                        });
                        
                    });                    
                }
            }
            else
            {
                MessageBox.Show("Не выбрано меню или не установлено кол-во детей!", "Расчет не произошел!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }

        public class Precalc
        {
            public Precalc(int productId, float quantity)
            {
                ProductId = productId;
                Quantity = quantity;
            }

            public int ProductId { get; set; }
            public float Quantity { get; set; }
        }

        #endregion //Methods

    }
}
