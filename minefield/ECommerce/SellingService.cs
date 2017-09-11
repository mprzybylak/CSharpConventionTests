using System;
namespace minefield.ECommerce
{
    public delegate void ProductSoldEventHandler(object sender, EventArgs args);

    public class SellingService
    {
        public event ProductSoldEventHandler ProductSold;

        private void importantLogic() {
            // ...
        }

		// TODO rest of code...
	}
}
