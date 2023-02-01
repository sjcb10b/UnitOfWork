using UnitOfWork.Data.Cart;

namespace UnitOfWork.Data.ViewModels
{
    public class ShoppingCartVM
    {

        public ShoppingCart ShoppingCart { get; set; }
        public double ShoppingCartTotal { get; set; }

        public int GetTotalCartItems { get; set; }


    }
}
