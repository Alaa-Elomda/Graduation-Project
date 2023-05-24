using AbilitySystem.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbilitySystem.BL;

public class EditCartRequest
{
    public CartToBeEdited cartToBeEdited { get; set; }
    public editCartDto EditedCart { get; set; }
}
