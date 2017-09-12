using System;
using minefield.ECommerce.App.Domain;

namespace minefield.ECommerce.App.View
{
    public class FirstView
    {
        public FirstView()
        {
            var firstService = new FirstService();
            var secondService = new SecondService();
        }
    }
}
