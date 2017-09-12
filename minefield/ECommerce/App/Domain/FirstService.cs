using System;
using minefield.ECommerce.App.Data;

namespace minefield.ECommerce.App.Domain
{
    public class FirstService
    {
        public FirstService()
        {
            var firstDao = new FirstDao();
            var secondDao = new SecondDao();
        }
    }
}
