using System.Collections.Generic;

namespace CosmeticsShop.Commands
{
    public interface ICommand
    {
        string Execute(List<string> parameters);
    }
}
