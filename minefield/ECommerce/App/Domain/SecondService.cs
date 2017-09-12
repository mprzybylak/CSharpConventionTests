using System;
using minefield.ECommerce.App.Data;

namespace minefield.ECommerce.App.Domain
{
    public class SecondService
    {
        public SecondService()
        {
            var secondDao = new SecondDao();
            var thirdDao = new ThirdDao();
        }
    }
}
