using System;
namespace minefield.ECommerce
{
    public delegate void ProductSoldEventHandler(object sender, EventArgs args);

    public class SellingService
    {
        public event ProductSoldEventHandler ProductSold;

        // TODO rest of code...
    }
}
