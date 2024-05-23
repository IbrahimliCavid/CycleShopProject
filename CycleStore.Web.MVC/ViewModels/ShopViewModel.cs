using Entities.Concrete.Dtos;

namespace CycleStore.Web.MVC.ViewModels
{
    public class ShopViewModel
    {

        public List<BestRacerDto> BestRacers { get; set; }

        public List<CycleDto> Cycles { get; set; }

        public List<BigSaleDto> BigSales { get; set; }

    }
}
