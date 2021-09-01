using Kindergarten.Models;
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

        private List<DataGridProduct> dataGridProducts;
        public List<DataGridProduct> DataGridProducts 
        { 
            get => dataGridProducts;
            set
            {
                dataGridProducts = value;
                RaisePropertyChanged();
            }
        }
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
                                    z.QuantityNursery += y.NurseryNorm;
                                    z.QuantityYard += y.YardNorm;
                                    flag = true;
                                }
                            });

                            if (!flag)
                            {
                                precalcs.Add(
                                    new Precalc(
                                        y.ProductId,
                                        y.NurseryNorm,
                                        y.YardNorm
                                        )
                                    );
                            }
                        });                        
                    });

                    precalcs.ForEach(x =>
                    {
                        x.QuantityTotal = x.QuantityNursery * NumberChildren[0].QuantityNursery + x.QuantityYard * NumberChildren[0].QuantityYard;
                    });


                    
                    precalcs.ForEach(x =>
                    {
                        Stocks.ForEach(y =>
                        {
                            if (x.ProductId == y.ProductId && x.QuantityTotal > y.Quantity)
                            {
                                dataGridProducts.Add(new DataGridProduct(y.Product, x.QuantityTotal - y.Quantity));
                            }
                        });
                    });

                    if (dataGridProducts.Count != 0)
                    {
                        MessageBox.Show("Продуктов достаточно!", "Успех!", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            }
            else
            {
                MessageBox.Show("Не выбрано меню или не установлено кол-во детей!", "Расчет не произошел!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }
        #endregion //Methods

        public class DataGridProduct
        {
            public DataGridProduct(Product product, float lack)
            {
                Product = product;
                Lack = lack;
            }

            public Product Product { get; set; }
            public float Lack { get; set; }
        }

        public class Precalc
        {
            public Precalc(int productId, float quantityYard, float quantityNursery)
            {
                ProductId = productId;
                QuantityNursery = quantityNursery;
                QuantityYard = quantityYard;
            }

            public int ProductId { get; set; }
            public float QuantityNursery { get; set; }
            public float QuantityYard { get; set; }
            public float QuantityTotal { get; set; }
        }

    }
}
