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
            GetNumberChildren();
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
        public void GetNumberChildren()
        {
            NumberChildren = ChildrenModel.GetChildrenData(DateCalculation, DateCalculation);
        }
        public void GetStocks()
        {
            Stocks = PartyModel.GetParty();

            //Переводим единицы измерения в граммы
            Stocks.ForEach(x => { x.Quantity *= 1000; });
        }

        public void GetMenu()
        {
            MenuModel.GetMenus(SelectedMenu.Id);
        }

        public void Calculation()
        {
            GetNumberChildren();
            DataGridProducts = new List<DataGridProduct>();
            List<DishItem> dishItems = new List<DishItem>();
            List<Dish> dishes = new List<Dish>();

            if (SelectedMenu != null && NumberChildren.Count == 1)
            {
                var menu = MenuModel.GetMenus(SelectedMenu.Id);
                

                if (menu != null)
                {
                    ICollection<Dish> dishes1 = menu[0].Dishes;                   

                    #region Get dish from menu

                    foreach (var item in dishes1)
                    {
                        dishes.Add(item);
                    }

                    List<Precalc> precalcs = new List<Precalc>();
                    #endregion //Get dish from menu

                    dishes.ForEach(x => 
                    {          
                        #region Get dishitems from menu
                        ICollection<DishItem> dishItems1 = x.DishItems;

                        foreach (var item in dishItems1)
                        {
                            dishItems.Add(item);
                        }
                        #endregion //Get dishitem from menu

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
                                DataGridProducts.Add(new DataGridProduct(y.Product, x.QuantityTotal - y.Quantity));
                            }
                        });
                    });

                    if (DataGridProducts.Count == 0)
                    {
                        MessageBox.Show("Продуктов достаточно!", "Успех!", MessageBoxButton.OK, MessageBoxImage.Information);

                        //Создаем переменные для сборки фактического меню для дальнейшего сохранения в базу
                        List<DishItemFact> dishItemFact = new List<DishItemFact>();
                        List<DishFact> dish = new List<DishFact>();
                        MenuFact menuFact = new MenuFact();

                        //Из имеющихся блюд соберём фактические блюда, которые будут состоять из фактических ингредиентов которые соберутся из шаблонных
                        dishes.ForEach(x => 
                        {
                            //Список ингредиентов для текущего блюда
                            List<DishItem> di = new List<DishItem>();

                            //Собираем текущие игредиенты
                            foreach (var item in dishItems)
                            {
                                if (item.DishId == x.Id)
                                {
                                    di.Add(item);
                                }
                            }

                            //Из текущих ингредиентов собираем списко фактических ингредиентов
                            di.ForEach(y =>
                            {
                                dishItemFact.Add(new DishItemFact
                                {
                                    ProductId = y.ProductId,
                                    YardNorm = y.YardNorm,
                                    NurseryNorm = y.NurseryNorm
                                });
                            });

                            //Собираем фактические блюда
                            dish.Add(new DishFact
                            {
                                DishItemFacts = (ICollection<DishItemFact>)dishItemFact,
                                Name = x.Name,
                                DishNurseryNorm = x.DishNurseryNorm,
                                DishYardNorm = x.DishYardNorm
                            });
                        });

                        //Собираем фактическое меню
                        menuFact.Name = SelectedMenu.Name;
                        menuFact.DishFacts = dish;



                    }
                    else
                    {
                        MessageBox.Show("Продуктов недостаточно!", "Меню не сформировано!", MessageBoxButton.OK, MessageBoxImage.Information);
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
            public DataGridProduct()
            {

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
